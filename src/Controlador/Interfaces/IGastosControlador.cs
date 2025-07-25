using Modelo;
using System;
using System.Collections.Generic;

namespace Controlador.Interfaces
{
    public interface IGastosControlador
    {
        public bool guardarGasto(Grupo grupo, Usuario quienPago, string nombreGasto, string descripcionGasto, string enlaceGasto, double montoGasto, List<string> integrantes, DateTime fechaSeleccionada);
        void guardarGrupoGasto(Grupo grupo, Gasto gasto);
    }
}