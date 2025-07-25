using Modelo;
using System.Collections.Generic;

namespace GestorDatos.Interfaces
{
    public interface IGestorDatosGastos
    {
        bool GuardarGasto(Gasto gasto, List<string> integrantes, string quienPagoId, Grupo grupo);
        void guardarGrupoGasto(Grupo grupo, Gasto gasto);
    }
}