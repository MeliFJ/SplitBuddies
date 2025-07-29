using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    /// <summary>
    /// Define el contrato para la gestión de gastos dentro de grupos y usuarios.
    /// Proporciona métodos para guardar gastos, consultar gastos por usuario o grupo,
    /// y generar diferentes tipos de reportes.
    /// </summary>
    public interface IGastosControlador
    {
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
        bool guardarGasto(
            Grupo grupo,
            Usuario quienPago,
            string nombreGasto,
            string descripcionGasto,
            string enlaceGasto,
            double montoGasto,
            List<string> integrantes,
            DateTime fechaSeleccionada);

        /// <summary>
        /// Obtiene la lista de gastos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <returns>Una lista de gastos para el usuario especificado.</returns>
        List<Gasto> ConsultarGastosPorUsuario(string idUsuario);

        /// <summary>
        /// Obtiene los gastos de un usuario específico dentro de un grupo determinado.
        /// </summary>
        /// <param name="usuario">El usuario cuyos gastos se consultan.</param>
        /// <param name="grupo">El grupo en el que se buscan los gastos.</param>
        /// <returns>Un objeto que contiene los detalles de los gastos del usuario en el grupo.</returns>
        GastoGrupoUsuario ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo);

        /// <summary>
        /// Genera un reporte de gastos para un usuario dentro de un rango de fechas especificado.
        /// </summary>
        /// <param name="fechaDesde">La fecha de inicio del periodo del reporte.</param>
        /// <param name="fechaHasta">La fecha de fin del periodo del reporte.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el periodo y usuario especificados.</returns>
        Reporte GenerarReportePorFechas(DateTime fechaDesde, DateTime fechaHasta, Usuario usuario);

        /// <summary>
        /// Genera un reporte de gastos para un usuario en un mes específico.
        /// </summary>
        /// <param name="fecha">Una fecha dentro del mes a reportar.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el mes y usuario especificados.</returns>
        Reporte GenerarReportePorMes(DateTime fecha, Usuario usuario);

        /// <summary>
        /// Genera un reporte de gastos para un usuario en un año específico.
        /// </summary>
        /// <param name="fecha">Una fecha dentro del año a reportar.</param>
        /// <param name="usuario">El usuario para quien se genera el reporte.</param>
        /// <returns>Un reporte con los detalles de los gastos para el año y usuario especificados.</returns>
        Reporte GenerarReportePorAnno(DateTime fecha, Usuario usuario);
    }
}