using Modelo;
using System;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    /// <summary>
    /// Define el contrato para la gestión de datos relacionados con los gastos.
    /// Proporciona métodos para guardar, consultar y reportar gastos asociados a usuarios y grupos.
    /// </summary>
    public interface IGestorDatosGastos
    {
        /// <summary>
        /// Guarda un gasto junto con la información de los integrantes, el usuario que pagó y el grupo asociado.
        /// </summary>
        /// <param name="gasto">El objeto <see cref="Gasto"/> a guardar.</param>
        /// <param name="integrantes">Lista de identificadores de los integrantes involucrados en el gasto.</param>
        /// <param name="quienPagoId">Identificador del usuario que realizó el pago.</param>
        /// <param name="grupo">El grupo al que pertenece el gasto.</param>
        /// <returns>True si el gasto se guardó correctamente; de lo contrario, false.</returns>
        bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo);

        /// <summary>
        /// Guarda la relación entre un grupo y un gasto.
        /// </summary>
        /// <param name="grupo">El grupo asociado al gasto.</param>
        /// <param name="gasto">El gasto a asociar con el grupo.</param>
        void guardarGrupoGasto(Grupo grupo, Gasto gasto);

        /// <summary>
        /// Consulta la lista de gastos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <returns>Una lista de objetos <see cref="Gasto"/> asociados al usuario, o null si no hay resultados.</returns>
        List<Gasto>? ConsultarGastosPorUsuario(string idUsuario);

        /// <summary>
        /// Carga la lista de todos los gastos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Gasto"/>.</returns>
        List<Gasto> CargarGastos();

        /// <summary>
        /// Obtiene un reporte de gastos para un usuario en un rango de fechas específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <param name="fechaDesde">Fecha de inicio del rango.</param>
        /// <param name="fechaHasta">Fecha de fin del rango.</param>
        /// <returns>Un objeto <see cref="Reporte"/> con los datos consolidados del usuario en el periodo indicado.</returns>
        Reporte ObtenerReportePorUsuario(string idUsuario, DateTime fechaDesde, DateTime fechaHasta);

        /// <summary>
        /// Consulta los gastos de un usuario dentro de un grupo específico, devolviendo las relaciones y los gastos encontrados.
        /// </summary>
        /// <param name="usuario">El usuario cuyos gastos se consultan.</param>
        /// <param name="grupo">El grupo en el que se buscan los gastos.</param>
        /// <returns>
        /// Una tupla con tres elementos:
        /// <list type="bullet">
        /// <item><description>Lista de relaciones grupo-gasto (<see cref="RelacionGrupoGasto"/>)</description></item>
        /// <item><description>Lista de relaciones usuario-gasto (<see cref="RelacionUsuarioGasto"/>)</description></item>
        /// <item><description>Lista de gastos encontrados (<see cref="Gasto"/>)</description></item>
        /// </list>
        /// </returns>
        (List<RelacionGrupoGasto>, List<RelacionUsuarioGasto>, List<Gasto>) ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo);


        /// <summary>
        /// Carga la lista de gastos asociados a un grupo específico.
        /// </summary>
        /// <param name="idGrupo">Identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="Gasto"/> asociados al grupo.</returns>
        List<Gasto> CargarGastosXGrupo(int idGrupo);

        /// <summary>
        /// Actualiza la información de un gasto existente, incluyendo los integrantes, el usuario que pagó y el grupo asociado.
        /// </summary>
        /// <param name="gasto">El objeto <see cref="Gasto"/> con los datos actualizados.</param>
        /// <param name="integrantes">Lista de identificadores de los integrantes involucrados en el gasto.</param>
        /// <param name="quienPagoId">Identificador del usuario que realizó el pago.</param>
        /// <param name="grupo">El grupo al que pertenece el gasto.</param>
        /// <returns>True si el gasto se actualizó correctamente; de lo contrario, false.</returns>
        bool ActualizarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo);

        /// <summary>
        /// Elimina un gasto específico de un grupo.
        /// </summary>
        /// <param name="idGasto">Identificador único del gasto a eliminar.</param>
        /// <param name="grupoId">Identificador único del grupo al que pertenece el gasto.</param>
        /// <returns>True si el gasto se eliminó correctamente; de lo contrario, false.</returns>
        bool EliminarGasto(int idGasto, int grupoId);
    }
}