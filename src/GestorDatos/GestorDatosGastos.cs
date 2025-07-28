using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestorDatos
{
    /// <summary>
    /// Clase encargada de la gestión de datos relacionados con los gastos.
    /// Implementa la lógica para guardar, consultar y reportar gastos asociados a usuarios y grupos,
    /// así como la administración de las relaciones entre gastos, usuarios y grupos.
    /// </summary>
    public class GestorDatosGastos : GestorDatosBase, IGestorDatosGastos
    {
        /// <summary>
        /// Guarda un gasto junto con la información de los integrantes, el usuario que pagó y el grupo asociado.
        /// </summary>
        /// <param name="gasto">El objeto <see cref="Gasto"/> a guardar.</param>
        /// <param name="integrantes">Lista de identificadores de los integrantes involucrados en el gasto.</param>
        /// <param name="quienPagoId">Identificador del usuario que realizó el pago.</param>
        /// <param name="grupo">El grupo al que pertenece el gasto.</param>
        /// <returns>True si el gasto se guardó correctamente; de lo contrario, false.</returns>
        public bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo)
        {
            List<Grupo> grupos = CargarDesdeJson<Grupo>(rutaArchivoGrupos);
            if (!grupos.Any(g => g.Id == grupo.Id))
            {
                return false; // El grupo no existe
            }

            List<Gasto> gastos = CargarDesdeJson<Gasto>(rutaArchivoGastos);

            // Obtener el id del nuevo gasto
            int nuevoId = 1;
            if (gastos.Count > 0)
            {
                nuevoId = gastos.Max(g => g.Id) + 1;
            }
            gasto.Id = nuevoId;

            gastos.Add(gasto);

            // Se guarda el gasto en el archivo JSON
            this.EscribirEnJson(rutaArchivoGastos, gastos);

            // Se guarda la relación entre el gasto y el grupo
            this.guardarGrupoGasto(grupo, gasto);

            // Se guarda la relación entre el gasto y los usuarios integrantes
            this.guardarUsuarioGasto(gasto, integrantes);

            return true;
        }

        /// <summary>
        /// Guarda la relación entre un gasto y los usuarios integrantes.
        /// </summary>
        /// <param name="gasto">El gasto a asociar con los usuarios.</param>
        /// <param name="integrantes">Lista de identificadores de los usuarios integrantes.</param>
        private void guardarUsuarioGasto(Gasto gasto, List<string> integrantes)
        {
            List<RelacionUsuarioGasto> relacionGrupoGastos = CargarDesdeJson<RelacionUsuarioGasto>(rutaRelacionUsuarioGasto);

            foreach (string integranteId in integrantes)
            {
                // Se crea una nueva relación entre el usuario y el gasto
                RelacionUsuarioGasto nuevaRelacion = new RelacionUsuarioGasto(integranteId, gasto.Id);
                relacionGrupoGastos.Add(nuevaRelacion);
            }

            this.EscribirEnJson(rutaRelacionUsuarioGasto, relacionGrupoGastos);
        }

        /// <summary>
        /// Guarda la relación entre un grupo y un gasto.
        /// </summary>
        /// <param name="grupo">El grupo asociado al gasto.</param>
        /// <param name="gasto">El gasto a asociar con el grupo.</param>
        public void guardarGrupoGasto(Grupo grupo, Gasto gasto)
        {
            List<RelacionGrupoGasto> relacionGrupoGastos = CargarDesdeJson<RelacionGrupoGasto>(rutaRelacionGrupoGasto);
            RelacionGrupoGasto nuevaRelacion = new RelacionGrupoGasto(grupo.Id, gasto.Id);
            relacionGrupoGastos.Add(nuevaRelacion);

            this.EscribirEnJson(rutaRelacionGrupoGasto, relacionGrupoGastos);
        }

        /// <summary>
        /// Consulta la lista de gastos asociados a un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <returns>Una lista de objetos <see cref="Gasto"/> asociados al usuario, o una lista vacía si no hay resultados.</returns>
        public List<Gasto>? ConsultarGastosPorUsuario(string idUsuario)
        {
            if (!File.Exists(rutaRelacionUsuarioGasto))
                return new List<Gasto>();

            string json = File.ReadAllText(rutaRelacionUsuarioGasto);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Gasto>();
            var relacionUsuarioGasto = JsonSerializer.Deserialize<List<RelacionUsuarioGasto>>(json)?.Where(x => x.UsuarioId == idUsuario).ToList();

            var gastos = CargarGastos();
            var resul = from gasto
                        in gastos
                        join relaciongastousuario in relacionUsuarioGasto
                        on gasto.QuienPagoId equals relaciongastousuario.UsuarioId
                        select gasto;
            
            return (resul?.Distinct().ToList()) as List<Gasto>;
        }

        /// <summary>
        /// Consulta y retorna la información base de gastos relacionados con un grupo y un usuario específico.
        ///
        /// El método realiza lo siguiente:
        /// 1. Carga las relaciones de gastos asociadas al grupo.
        /// 2. Carga las relaciones de gastos asociadas al usuario.
        /// 3. Carga la lista general de gastos registrados.
        /// 4. Retorna las tres listas en una tupla: 
        ///    - Relaciones de grupo-gasto
        ///    - Relaciones de usuario-gasto
        ///    - Lista completa de gastos
        ///
        /// Consideraciones:
        /// - Este método no realiza cálculos; solo recupera y agrupa los datos necesarios para análisis posteriores.
        /// - Útil como función auxiliar para separar la lógica de acceso a datos de la lógica de procesamiento.
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
        public (List<RelacionGrupoGasto>,List<RelacionUsuarioGasto>,List<Gasto>) ConsultarGastosPorGrupoyUsuario(Usuario usuario, Grupo grupo)
        {
            var relacionesGrupoGastos = CargarRelacionGastoGrupo(grupo.Id);
            var relacionesUsuarioGasto = CargarRelacionGastoUsuario(usuario.Identificacion);
            var gastos = CargarGastos();
            return (relacionesGrupoGastos, relacionesUsuarioGasto, gastos);
        }

        /// <summary>
        /// Carga la lista de todos los gastos registrados en el sistema.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="Gasto"/>.</returns>
        public List<Gasto> CargarGastos()
        {
            if (!File.Exists(rutaArchivoGrupos))
                return new List<Gasto>();

            string json = File.ReadAllText(rutaArchivoGastos);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Gasto>();
            var gastos = JsonSerializer.Deserialize<List<Gasto>>(json);
            if(gastos is null)
                return new List<Gasto>();
            else
                return gastos;
        }

        /// <summary>
        /// Carga la lista de relaciones grupo-gasto para un grupo específico.
        /// </summary>
        /// <param name="idGrupo">El identificador único del grupo.</param>
        /// <returns>Una lista de objetos <see cref="RelacionGrupoGasto"/> asociados al grupo.</returns>
        private List<RelacionGrupoGasto> CargarRelacionGastoGrupo(int idGrupo)
        {
            if (!File.Exists(rutaRelacionUsuarioGasto))
                return new List<RelacionGrupoGasto>();
            string json = File.ReadAllText(rutaRelacionGrupoGasto);
            if (string.IsNullOrWhiteSpace(json))
                return new List<RelacionGrupoGasto>();

            var relacionGrupoGasto = JsonSerializer.Deserialize<List<RelacionGrupoGasto>>(json)?.Where(x => x.GrupoId == idGrupo).ToList();
            return relacionGrupoGasto ?? new List<RelacionGrupoGasto>(); // Retorna una lista vacía si no hay datos o si la deserialización falla
        }

        /// <summary>
        /// Carga la lista de relaciones usuario-gasto para un usuario específico.
        /// </summary>
        /// <param name="idUsuario">El identificador único del usuario.</param>
        /// <returns>Una lista de objetos <see cref="RelacionUsuarioGasto"/> asociados al usuario.</returns>
        private List<RelacionUsuarioGasto> CargarRelacionGastoUsuario(string idUsuario)
        {
            if (!File.Exists(rutaRelacionUsuarioGasto))
                return new List<RelacionUsuarioGasto>();

            string json = File.ReadAllText(rutaRelacionUsuarioGasto);
            if (string.IsNullOrWhiteSpace(json))
                return new List<RelacionUsuarioGasto>();

            var relacionUsuarioGasto = JsonSerializer.Deserialize<List<RelacionUsuarioGasto>>(json)
                                     ?.Where(x => x.UsuarioId == idUsuario)
                                     .ToList();

            return relacionUsuarioGasto ?? new List<RelacionUsuarioGasto>(); // Retorna una lista vacía si no hay datos o si la deserialización falla
        }

        /// <summary>
        /// Obtiene un reporte de gastos para un usuario en un rango de fechas específico.
        /// </summary>
        /// <param name="idUsuario">El identificador del usuario.</param>
        /// <param name="fechaDesde">Fecha de inicio del rango.</param>
        /// <param name="fechaHasta">Fecha de fin del rango.</param>
        /// <returns>Un objeto <see cref="Reporte"/> con los datos consolidados del usuario en el periodo indicado.</returns>
        public Reporte ObtenerReportePorUsuario(string idUsuario, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (!File.Exists(rutaRelacionUsuarioGasto))
                return new Reporte();

            string json = File.ReadAllText(rutaRelacionUsuarioGasto);
            if (string.IsNullOrWhiteSpace(json))
                return new Reporte();

            var gastoDelUsuario = JsonSerializer.Deserialize<List<RelacionUsuarioGasto>>(json)
                                  ?.Where(x => x.UsuarioId == idUsuario)
                                  .ToList();

            // Busca gastos del usuario en el rango de fechas
            var gastos = CargarGastos()
                         .Where(g => g.FechaSeleccionada >= fechaDesde && g.FechaSeleccionada <= fechaHasta)
                         .ToList();

            // Gastos pagados por el usuario
            var gastosPagados =
                (from gasto in gastos
                 join gastoUsuario in gastoDelUsuario
                 on gasto.QuienPagoId equals gastoUsuario.UsuarioId
                 select gasto).Distinct().ToList(); // Se hace un Distinct para evitar duplicados y después convertir a lista

            List<Gasto> gastosPagos = gastosPagados;

            // Gastos adeudados por el usuario
            var gastosAdeudados = (from gasto in gastos
                                   join gastoUsuario in gastoDelUsuario
                                   on gasto.Id equals gastoUsuario.GastoId
                                   where gasto.QuienPagoId != gastoUsuario.UsuarioId
                                   select gasto).Distinct().ToList();

            List<Gasto> gastosAdeudadosList = gastosAdeudados.ToList();

            // Totales
            double totalPagados = gastosPagos.Sum(gasto => gasto.MontoGasto);
            double totalAdeudados = gastosAdeudadosList.Sum(gasto => gasto.MontoGasto);

            Reporte reporte = new Reporte(totalPagados, totalAdeudados);
            return reporte;
        }
    }
}
