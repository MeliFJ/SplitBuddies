using Controlador.Interfaces;
using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador
{
    public class GastosControlador :IGastosControlador
    {
        IGestorDatosGastos gestorGastos;
        public GastosControlador(IGestorDatosGastos gestorGastos )
        {
            this.gestorGastos = gestorGastos;
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
            return gestorGastos.ConsultarGastosPorUsuario(idUsuario) ?? new List<Gasto>();
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

        public Reporte GenerarReportePorFechas(DateTime fechaDesde, DateTime fechaHasta, Usuario usuario)
        {
            Reporte gastosXUsuario = gestorGastos.ObtenerReportePorUsuario(usuario.Identificacion, fechaDesde, fechaHasta);
            return gastosXUsuario;
        }
    }
}
