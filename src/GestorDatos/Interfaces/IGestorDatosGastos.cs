using Modelo;
using System;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    public interface IGestorDatosGastos
    {
        bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo);
        void guardarGrupoGasto(Grupo grupo, Gasto gasto);
        List<Gasto>? ConsultarGastosPorUsuario(string idUsuario);
        List<Gasto> CargarGastos();
        Reporte ObtenerReportePorUsuario(string idUsuario, DateTime fechaDesde, DateTime fechaHasta);
        (List<RelacionGrupoGasto>, List<RelacionUsuarioGasto>, List<Gasto>) ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo);

    }
}