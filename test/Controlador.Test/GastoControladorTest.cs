using Controlador;
using GestorDatos.Interfaces;
using Modelo;
using Moq;

namespace Tests.Controlador
{
    [TestClass]
    public class GastosControladorTests
    {
        private Mock<IGestorDatosGastos>? mockGastos;
        private Mock<IGestorDatosUsuario>? mockUsuarios;
        private GastosControlador? controlador;

        [TestInitialize]
        public void Setup()
        {
            mockGastos = new Mock<IGestorDatosGastos>();
            mockUsuarios = new Mock<IGestorDatosUsuario>();
            controlador = new GastosControlador(mockGastos.Object, mockUsuarios.Object);
        }

        [TestMethod]
        public void GuardarGastoRetornarTrueCuandoSeGuarda()
        {
            // Arrange
            var grupo = new Grupo("11111", "logo.png", "Amigos");
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");
            var integrantes = new List<string> { "U2" };

            mockGastos?
                .Setup(x => x.GuardarGasto(It.IsAny<Gasto>(), It.IsAny<List<string>>(), usuario.Identificacion, grupo))
                .Returns(true);

            // Act
            var result = controlador?.guardarGasto(grupo, usuario, "Cena", "Pizza", "link", 100, integrantes, DateTime.Now);

            // Assert
            Assert.IsTrue(result);
            mockGastos?.Verify(x => x.GuardarGasto(It.IsAny<Gasto>(),
                It.Is<List<string>>(l => l.Contains("U1")),
                usuario.Identificacion, grupo), Times.Once);
        }

        [TestMethod]
        public void ActualizarGastoRetornarTrueCuandoSeActualiza()
        {
            // Arrange
            var grupo = new Grupo("11111", "logo.png", "Amigos");
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");
            var integrantes = new List<string> { "U2" };

            mockGastos?
                .Setup(x => x.ActualizarGasto(It.IsAny<Gasto>(), It.IsAny<List<string>>(), usuario.Identificacion, grupo))
                .Returns(true);

            // Act
            var result = controlador?.ActualizarGasto(10, grupo, usuario, "Cena", "Pizza", "link", 200, integrantes, DateTime.Now);

            // Assert
            Assert.IsTrue(result);
            mockGastos?.Verify(x => x.ActualizarGasto(It.IsAny<Gasto>(),
                It.Is<List<string>>(l => l.Contains("U1")),
                usuario.Identificacion, grupo), Times.Once);
        }

        [TestMethod]
        public void EliminarGastoRetornarTrueCuandoSeElimina()
        {
            // Arrange
            int idGasto = 10;
            int idGrupo = 1;

            mockGastos?.Setup(x => x.EliminarGasto(idGasto, idGrupo)).Returns(true);

            // Act
            var result = controlador?.EliminarGasto(idGasto, idGrupo);

            // Assert
            Assert.IsTrue(result);
            mockGastos?.Verify(x => x.EliminarGasto(idGasto, idGrupo), Times.Once);
        }

        [TestMethod]
        public void ConsultarGastosPorUsuarioRetornarLista()
        {
            // Arrange
            var usuarioId = "U1";
            var gastos = new List<Gasto> { new Gasto("Cena", "Pizza", "link", 100, "U1", DateTime.Now) };
            mockGastos?.Setup(x => x.ConsultarGastosPorUsuario(usuarioId)).Returns(gastos);

            // Act
            var result = controlador?.ConsultarGastosPorUsuario(usuarioId);

            // Assert
            Assert.AreEqual(1, result?.Count);
        }

        [TestMethod]
        public void ConsultarGastosPorGrupoyUsuarioCalcularTotalesCorrectamente()
        {
            // Arrange
            var grupo = new Grupo("11111", "logo.png", "Amigos");
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");

            var gastos = new List<Gasto>
            {
                new Gasto(1, "Cena", "Pizza", "link", 100, "U1", DateTime.Now),
                new Gasto(2, "Taxi", "Viaje", "link", 50, "U2", DateTime.Now)
            };
            var relacionesGrupo = new List<RelacionGrupoGasto>
            {
                new RelacionGrupoGasto { GastoId = 1, GrupoId = 1 },
                new RelacionGrupoGasto { GastoId = 2, GrupoId = 1 }
            };
            var relacionesUsuario = new List<RelacionUsuarioGasto>
            {
                new RelacionUsuarioGasto { GastoId = 1, UsuarioId = "U1" },
                new RelacionUsuarioGasto { GastoId = 2, UsuarioId = "U2" }
            };
            var usuariosGrupo = new List<Usuario>
            {
                new Usuario("U1", "1234", "Pedro", "Ramirez"),
                new Usuario("U2", "4321", "Juan", "Lopez")
            };

            mockGastos?.Setup(x => x.ConsultarGastosPorGrupoyUsuario(usuario, grupo))
                      .Returns((relacionesGrupo, relacionesUsuario, gastos));
            mockUsuarios?.Setup(x => x.CargarUsuarioPorGrupos(grupo.Id)).Returns(usuariosGrupo);

            // Act
            var result = controlador?.ConsultarGastosPorGrupoyUsuario(usuario, grupo);

            // Assert
            Assert.AreEqual(150, result?.TotalGastosGrupo);
            Assert.AreEqual(100, result?.TotalGastosPorUsuario);
            Assert.AreEqual(75, result?.TotalGastosPorIntegrante);
            Assert.AreEqual(2, result?.CantidadIntegrantes);
            Assert.AreEqual("Pedro", result?.NombreUsuario);
            Assert.AreEqual("Amigos", result?.NombreGrupo);
        }

        [TestMethod]
        public void GenerarReportePorFechasRetornarReporte()
        {
            // Arrange
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");
            var reporte = new Reporte();
            var desde = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            var hasta = new DateTime(2025, 1, 31, 0, 0, 0, DateTimeKind.Unspecified);
            mockGastos?.Setup(x => x.ObtenerReportePorUsuario(usuario.Identificacion, desde, hasta)).Returns(reporte);

            // Act
            var result = controlador?.GenerarReportePorFechas(desde, hasta, usuario);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GenerarReportePorMesRetornarReporte()
        {
            // Arrange
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");
            var reporte = new Reporte();
            var fecha = new DateTime(2025, 2, 15, 0, 0, 0, DateTimeKind.Unspecified);
            mockGastos?.Setup(x => x.ObtenerReportePorUsuario(usuario.Identificacion, new DateTime(2025, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 28, 0, 0, 0, DateTimeKind.Unspecified)))
                      .Returns(reporte);

            // Act
            var result = controlador?.GenerarReportePorMes(fecha, usuario);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GenerarReportePorAnno_DeberiaRetornarReporte()
        {
            // Arrange
            var usuario = new Usuario("U1", "1234", "Pedro", "Ramirez");
            var reporte = new Reporte();
            var fecha = new DateTime(2025, 3, 10, 0, 0, 0, DateTimeKind.Unspecified);
            mockGastos?.Setup(x => x.ObtenerReportePorUsuario(usuario.Identificacion, new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 31, 0, 0, 0, DateTimeKind.Unspecified)))
                      .Returns(reporte);

            // Act
            var result = controlador?.GenerarReportePorAnno(fecha, usuario);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CargarGastoPorUsuarioEnGrupoRetornarTotales()
        {
            // Arrange
            var integrantes = new List<Usuario>
            {
                new Usuario("U1", "1234", "Pedro", "Ramirez"),
                new Usuario("U2", "4321", "Juan", "Lopez")
            };
            var gastos = new List<Gasto>
            {
                new Gasto(1, "Cena", "Pizza", "link", 100, "U1", DateTime.Now),
                new Gasto(2, "Taxi", "Viaje", "link", 50, "U2", DateTime.Now),
                new Gasto(3, "Cine", "Pelicula", "link", 30, "U1", DateTime.Now)
            };
            mockGastos?.Setup(x => x.CargarGastosXGrupo(1)).Returns(gastos);

            // Act
            var result = controlador?.CargarGastoPorUsuarioEnGrupo(1, integrantes);

            // Assert
            Assert.AreEqual(2, result?.Count);
            Assert.AreEqual(130, result?["U1"]);
            Assert.AreEqual(50, result?["U2"]);
        }

        [TestMethod]
        public void CargarGastoPorGrupoRetornarListaDeGastos()
        {
            // Arrange
            var gastos = new List<Gasto>
            {
                new Gasto("Cena", "Pizza", "link", 100, "U1", DateTime.Now)
            };
            mockGastos?.Setup(x => x.CargarGastosXGrupo(1)).Returns(gastos);

            // Act
            var result = controlador?.CargarGastoPorGrupo(1);

            // Assert
            Assert.AreEqual(1, result?.Count);
        }
    }
}
