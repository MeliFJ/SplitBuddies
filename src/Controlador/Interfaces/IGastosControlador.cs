using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    public interface IGastosControlador
    {
        public bool guardarGasto(Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada);
        public List<Gasto> ConsultarGastosPorUsuario(string idUsuario);
        public GastoGrupoUsuario ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo);
        public Reporte GenerarReportePorFechas(DateTime fechaDesde, DateTime fechaHasta, Usuario usuario);
        public Reporte GenerarReportePorMes(DateTime fecha, Usuario usuario);
        public Reporte GenerarReportePorAnno(DateTime fecha, Usuario usuario);
    }
}