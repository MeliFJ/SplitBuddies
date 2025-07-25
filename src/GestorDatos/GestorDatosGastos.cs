using GestorDatos.Interfaces;
using Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GestorDatos
{
    public class GestorDatosGastos : GestorDatosBase, IGestorDatosGastos
    {
        public bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo)
        {
            List<Grupo> grupos = CargarDesdeJson<Grupo>(rutaArchivoGrupos);
            if (!grupos.Any(g => g.Id == grupo.Id))
            {
                return false; // El grupo no existe
            }

            List<Gasto> gastos = CargarDesdeJson<Gasto>(rutaArchivoGastos);

            //Obetener el id del nuevo
            int nuevoId = 1;
            if (gastos.Count > 0)
            {
                nuevoId = gastos.Max(g => g.Id) + 1;
            }
            gasto.Id = nuevoId;

            gastos.Add(gasto);

            // Se guarda el gasto en el archivo JSON
            this.EscribirEnJson(rutaArchivoGastos, gastos);

            // Se guarda la relacion entre el gasto y el grupo
            this.guardarGrupoGasto(grupo, gasto);

            this.guardarUsuarioGasto(gasto, integrantes);

            return true;
        }

        private void guardarUsuarioGasto(Gasto gasto, List<string> integrantes)
        {
            List<RelacionUsuarioGasto> relacionGrupoGastos = CargarDesdeJson<RelacionUsuarioGasto>(rutaRelacionUsuarioGasto);

            foreach (string integranteId in integrantes)
            {
                // Se crea una nueva relacion entre el usuario y el gasto
                RelacionUsuarioGasto nuevaRelacion = new RelacionUsuarioGasto(integranteId, gasto.Id);
                relacionGrupoGastos.Add(nuevaRelacion);
            }

            this.EscribirEnJson(rutaRelacionUsuarioGasto, relacionGrupoGastos);
        }


        public void guardarGrupoGasto(Grupo grupo, Gasto gasto)
        {
            List<RelacionGrupoGasto> relacionGrupoGastos = CargarDesdeJson<RelacionGrupoGasto>(rutaRelacionGrupoGasto);
            RelacionGrupoGasto nuevaRelacion = new RelacionGrupoGasto(grupo.Id, gasto.Id);
            relacionGrupoGastos.Add(nuevaRelacion);

            this.EscribirEnJson(rutaRelacionGrupoGasto, relacionGrupoGastos);

        }

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

            return resul?.ToList();
        }
        public List<Gasto> CargarGastos()
        {
            if (!File.Exists(rutaArchivoGastos))
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

            // Busc gastos del usuario en el rango de fechas
            var gastos = CargarGastos()
                         .Where(g => g.FechaSeleccionada >= fechaDesde && g.FechaSeleccionada <= fechaHasta)
                         .ToList();

            // Gastos pagados por el usuario
            var gastosPagados =
                (from gasto in gastos
                join gastoUsuario in gastoDelUsuario
                on gasto.QuienPagoId equals gastoUsuario.UsuarioId
                select gasto).Distinct().ToList(); //Se hace un Distinct para evitar duplicados y dess convertir a lista

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
