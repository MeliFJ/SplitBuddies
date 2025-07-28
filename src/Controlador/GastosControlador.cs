using Controlador.Interfaces;
using GestorDatos;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class GastosControlador :IGastosControlador
    {
        IGestorDatosGastos gestorGastos;
        IGestorDatosUsuario gestorDatosusuario;
        public GastosControlador(IGestorDatosGastos gestorGastos, IGestorDatosUsuario gestorDatosUsuario )
        {
            this.gestorGastos = gestorGastos;
            this.gestorDatosusuario = gestorDatosUsuario;
        }

        public bool guardarGasto(Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada)
        {
            Gasto nuevoGasto = new Gasto(nombreGasto, descripcionGasto, enlaceGasto, montoGasto, quienPago.Identificacion, fechaSeleccionada);
            //Verificar si el que pago esta como integrante del grupo
            integrantes = validarIntegrantes(integrantes, quienPago);

            return gestorGastos.GuardarGasto(nuevoGasto, integrantes, quienPago.Identificacion, grupo);
        }

        public List<Gasto> ConsultarGastosPorUsuario(string idUsuario)
        {
            return gestorGastos.ConsultarGastosPorUsuario(idUsuario);
        }
        private List<string> validarIntegrantes(List<string> integrantes, Usuario usuarioLogeado)
        {
            // Validar que el usuario logueado esté en la lista de integrantes
            if (!integrantes.Contains(usuarioLogeado.Identificacion))
            {
                integrantes.Add(usuarioLogeado.Identificacion);
            }
            return integrantes;
        }

        public void guardarGrupoGasto(Grupo grupo, Gasto gasto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calcula los totales de gasto relacionados a un grupo y un usuario específico dentro de ese grupo.
        ///
        /// El método realiza lo siguiente:
        /// 1. Obtiene, mediante <c>gestorGastos</c>, las listas de relaciones de gasto por grupo y por usuario, junto con los gastos registrados.
        /// 2. Identifica los gastos del grupo y los gastos pagados por el usuario dentro de ese grupo.
        /// 3. Suma el total de gastos del grupo y del usuario.
        /// 4. Calcula el monto promedio por integrante del grupo (dividiendo el total del grupo entre los usuarios involucrados).
        /// 5. Retorna un objeto GastoGrupoUsuario con la información consolidada.
        ///
        /// Consideraciones:
        /// - Se asume que cada gasto puede estar relacionado con múltiples usuarios y grupos.
        /// - La cantidad de usuarios distintos se calcula con base en las relaciones de usuario-gasto.
        public GastoGrupoUsuario ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo)
        {
            (List<RelacionGrupoGasto>, List<RelacionUsuarioGasto>, List<Gasto>) resultadogestor =gestorGastos.ConsultarGastosPorGrupoyUsuario(usuario, grupo);
            List<RelacionGrupoGasto> grupoGastos = resultadogestor.Item1;
            List<RelacionUsuarioGasto> usuariogastos = resultadogestor.Item2;
            List<Gasto> gastos = resultadogestor.Item3;
           var gastosPorgrupoUsuario = from gasto
                                        in gastos
                                       join relaciongastousuario in usuariogastos
                                        on gasto.QuienPagoId equals relaciongastousuario.UsuarioId
                                        join relaciongastogrupo in grupoGastos
                                        on relaciongastousuario.GastoId equals relaciongastogrupo.GastoId
                                       
                                       select gasto;
            gastosPorgrupoUsuario = gastosPorgrupoUsuario.Distinct();
            var gastosPorgrupo = from gasto
                                 in gastos
                                 join relaciongastogrupo in grupoGastos
                                 on gasto.Id equals relaciongastogrupo.GastoId
                                 select gasto;
            gastosPorgrupo = gastosPorgrupo.Distinct();
            GastoGrupoUsuario resultado = new GastoGrupoUsuario();
            foreach (var gasto in gastosPorgrupo)
            {
                resultado.TotalGastosGrupo += gasto.MontoGasto;
            }
            foreach (var gasto in gastosPorgrupoUsuario)
            {
                resultado.TotalGastosPorUsuario += gasto.MontoGasto;
            }
            var usuarios= gestorDatosusuario.CargarUsuarioPorGrupos(grupo.Id);
            var cantidadusuarios = usuarios.Count();
            if (cantidadusuarios > 0)
            {
               
                resultado.TotalGastosPorIntegrante = (double)(resultado.TotalGastosGrupo / cantidadusuarios);
                resultado.NombreUsuario = usuario.Nombre;
                resultado.NombreGrupo = grupo.Nombre;
                resultado.Gastos = gastosPorgrupoUsuario.ToList();
                resultado.CantidadIntegrantes = (int)cantidadusuarios;
            }
           
            return resultado;
        }
    }
}
