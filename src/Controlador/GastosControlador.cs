using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controlador
{
    /// <summary>
    /// Controlador encargado de la gestión de gastos dentro de grupos y usuarios.
    /// Implementa la lógica para guardar gastos, consultar gastos por usuario o grupo,
    /// y generar diferentes tipos de reportes.
    /// </summary>
    public class GastosControlador : IGastosControlador
    {
        IGestorDatosGastos gestorGastos;
        IGestorDatosUsuario gestorDatosusuario;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GastosControlador"/>.
        /// </summary>
        /// <param name="gestorGastos">Instancia para la gestión de datos de gastos.</param>
        /// <param name="gestorDatosUsuario">Instancia para la gestión de datos de usuarios.</param>
        public GastosControlador(IGestorDatosGastos gestorGastos, IGestorDatosUsuario gestorDatosUsuario)
        {
            this.gestorGastos = gestorGastos;
            this.gestorDatosusuario = gestorDatosUsuario;
        }

        /// <summary>
        /// Guarda un nuevo gasto para un grupo.
        /// </summary>
        /// <param name="grupo">El grupo al que pertenece el gasto.</param>
        /// <param name="quienPago">El usuario que realizó el pago.</param>
        /// <param name="nombreGasto">El nombre del gasto.</param>
        /// <param name="descripcionGasto">La descripción del gasto.</param>
        /// <param name="enlaceGasto">Un enlace relacionado con el gasto (por ejemplo, recibo o referencia).</param>
        /// <param name="montoGasto">El monto del gasto.</param>
        /// <param name="integrantes">Lista de identificadores de los integrantes involucrados en el gasto.</param>
        /// <param name="fechaSeleccionada">La fecha en que se realizó el gasto.</param>
        /// <returns>True si el gasto se guardó correctamente; de lo contrario, false.</returns>
        public bool guardarGasto(Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada)
        {
            Gasto nuevoGasto = new Gasto(nombreGasto, descripcionGasto, enlaceGasto, montoGasto, quienPago.Identificacion, fechaSeleccionada);
            //Verificar si el que pago esta como integrante del grupo
            integrantes = validarIntegrantes(integrantes, quienPago);

            return gestorGastos.GuardarGasto(nuevoGasto, integrantes, quienPago.Identificacion, grupo);
        }

        public bool actualizarGasto(int idGasto, Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada)
        {
            Gasto nuevoGasto = new Gasto(idGasto,nombreGasto, descripcionGasto, enlaceGasto, montoGasto, quienPago.Identificacion, fechaSeleccionada);
            //Verificar si el que pago esta como integrante del grupo
            integrantes = validarIntegrantes(integrantes, quienPago);

            return gestorGastos.actualizarGasto(nuevoGasto, integrantes, quienPago.Identificacion, grupo);
        }

        /// <summary>
        /// Obtiene la lista de gastos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <returns>Una lista de gastos para el usuario especificado.</returns>
        public List<Gasto> ConsultarGastosPorUsuario(string idUsuario)
        {
            return gestorGastos.ConsultarGastosPorUsuario(idUsuario) ?? new List<Gasto>();
        }

        /// <summary>
        /// Valida que el usuario logueado esté incluido en la lista de integrantes.
        /// </summary>
        /// <param name="integrantes">Lista de identificadores de integrantes.</param>
        /// <param name="usuarioLogeado">Usuario que está realizando la acción.</param>
        /// <returns>Lista de integrantes actualizada.</returns>
        private List<string> validarIntegrantes(List<string> integrantes, Usuario usuarioLogeado)
        {
            // Validar que el usuario logueado esté en la lista de integrantes
            if (!integrantes.Contains(usuarioLogeado.Identificacion))
            {
                integrantes.Add(usuarioLogeado.Identificacion);
            }
            return integrantes;
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
        /// </summary>
        /// <param name="usuario">El usuario cuyos gastos se consultan.</param>
        /// <param name="grupo">El grupo en el que se buscan los gastos.</param>
        /// <returns>Un objeto que contiene los detalles de los gastos del usuario en el grupo.</returns>
        public GastoGrupoUsuario ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo)
        {
            (List<RelacionGrupoGasto>, List<RelacionUsuarioGasto>, List<Gasto>) resultadogestor = gestorGastos.ConsultarGastosPorGrupoyUsuario(usuario, grupo);
            List<RelacionGrupoGasto> grupoGastos = resultadogestor.Item1;
            List<RelacionUsuarioGasto> usuariogastos = resultadogestor.Item2;
            List<Gasto> gastos = resultadogestor.Item3;
            var gastosPorgrupoUsuario = from gasto
                                       in gastos
                                        join relaciongastousuario in usuariogastos
                                        on gasto.QuienPagoId equals relaciongastousuario.UsuarioId
                                        join relaciongastogrupo in grupoGastos
                                        on relaciongastousuario.GastoId equals relaciongastogrupo.GastoId
                                       //on new { relaciongastousuario.GastoId, relaciongastousuario.UsuarioId } equals new { relaciongastogrupo.GastoId, relaciongastogrupo.UsuarioId }
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
            var usuarios = gestorDatosusuario.CargarUsuarioPorGrupos(grupo.Id);
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

        /// <summary>
        /// Genera un reporte de gastos para un usuario dentro de un rango de fechas especificado.
        /// </summary>
        /// <param name="fechaDesde">La fecha de inicio del periodo del reporte.</param>
        /// <param name="fechaHasta">La fecha de fin del periodo del reporte.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el periodo y usuario especificados.</returns>
        public Reporte GenerarReportePorFechas(DateTime fechaDesde, DateTime fechaHasta, Usuario usuario)
        {
            Reporte gastosXUsuario = this.gestorGastos.ObtenerReportePorUsuario(usuario.Identificacion, fechaDesde, fechaHasta);
            return gastosXUsuario;
        }

        /// <summary>
        /// Genera un reporte de gastos para un usuario en un mes específico.
        /// </summary>
        /// <param name="fecha">Una fecha dentro del mes a reportar.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el mes y usuario especificados.</returns>
        public Reporte GenerarReportePorMes(DateTime fecha, Usuario usuario)
        {
            DateTime primerDia = new DateTime(fecha.Year, fecha.Month, 1); //   Primer día del mes
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1); // Último día del mes

            //Se obtiene los datos del reporte obteniendo el rango de fechas basado en el mes que se seleccionó
            Reporte gastosXUsuario = this.gestorGastos.ObtenerReportePorUsuario(usuario.Identificacion, primerDia, ultimoDia);
            return gastosXUsuario;
        }

        /// <summary>
        /// Genera un reporte de gastos para un usuario en un año específico.
        /// </summary>
        /// <param name="fecha">Una fecha dentro del año a reportar.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el año y usuario especificados.</returns>
        public Reporte GenerarReportePorAnno(DateTime fecha, Usuario usuario)
        {
            DateTime primerDia = new DateTime(fecha.Year, 1, 1); // Primer día del año
            DateTime ultimoDia = new DateTime(fecha.Year, 12, 31); // Último día del año

            //Se obtiene los datos del reporte obteniendo el rango de fechas basado en el año que se seleccionó
            Reporte gastosXUsuario = this.gestorGastos.ObtenerReportePorUsuario(usuario.Identificacion, primerDia, ultimoDia);
            return gastosXUsuario;
        }

        /// <summary>
        /// Calcula el total de gastos realizados por cada usuario integrante de un grupo específico.
        /// 
        /// Este método obtiene todos los gastos asociados al grupo indicado y suma el monto total pagado por cada usuario
        /// que forma parte de la lista de integrantes proporcionada. El resultado es un diccionario donde la clave es el
        /// identificador del usuario y el valor es la suma de los montos de los gastos que ha pagado en el grupo.
        /// 
        /// Consideraciones:
        /// - Solo se consideran los gastos cuyo pagador está en la lista de integrantes.
        /// - Si un integrante no ha realizado ningún gasto, no aparecerá en el diccionario resultante.
        /// </summary>
        /// <param name="idGrupo">Identificador único del grupo.</param>
        /// <param name="integrantes">Lista de usuarios integrantes del grupo.</param>
        /// <returns>
        /// Un diccionario donde la clave es el identificador del usuario y el valor es el total de gastos pagados por ese usuario en el grupo.
        /// </returns>
        public Dictionary<string, double> CargarGastoPorUsuarioEnGrupo(int idGrupo, List<Usuario> integrantes)
        {
            List<Gasto> gastosXGrupo = gestorGastos.CargarGastosXGrupo(idGrupo);
            var idsIntegrantes = integrantes.Select(i => i.Identificacion).ToHashSet();

            var gastosPorUsuario = gastosXGrupo
                .Where(g => idsIntegrantes.Contains(g.QuienPagoId))
                .GroupBy(g => g.QuienPagoId)
                .ToDictionary(
                    grupo => grupo.Key, // Esto es el QuienPagoId
                    grupo => grupo.Sum(g => g.MontoGasto)
                );

            return gastosPorUsuario;
        }

        public List<Gasto> CargarGastoPorGrupo(int idGrupo)
        {
            List<Gasto> gastosXGrupo = gestorGastos.CargarGastosXGrupo(idGrupo);
            return gastosXGrupo;
        }


    }
}
