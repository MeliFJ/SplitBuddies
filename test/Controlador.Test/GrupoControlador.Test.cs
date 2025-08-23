using Controlador;
using GestorDatos.Interfaces;
using Modelo;
using Moq;

namespace ControladorTests
{
    [TestClass]
    public class GrupoControladorTests
    {
        private Mock<IGestorDatosGrupos>? mockDataManager;
        private Mock<IGestorDatosUsuario>? mockUserManager;
        private GrupoControlador? controller;

        [TestInitialize]
        public void Setup()
        {
            // Arrange: create mocks and controller
            mockDataManager = new Mock<IGestorDatosGrupos>();
            mockUserManager = new Mock<IGestorDatosUsuario>();
            controller = new GrupoControlador(mockDataManager.Object, mockUserManager.Object);
        }

        [TestMethod]
        public void LoadPossibleMembers_ReturnsUsers()
        {
            // Arrange
            var users = new Dictionary<string, Usuario>
            {
                { "1", new Usuario("1", "pass123", "Juan", "Perez") }
            };
            mockUserManager?.Setup(m => m.CargarUsuarios()).Returns(users);

            // Act
            var result = controller?.cargarPosiblesIntegrantes();

            // Assert
            Assert.AreEqual(1, result?.Count);
            Assert.IsTrue(result?.ContainsKey("1"));
            Assert.AreEqual("Juan", result?["1"].Nombre);
        }

        [TestMethod]
        public void LoadUsersByGroup_ReturnsList()
        {
            // Arrange
            var userList = new List<Usuario>
            {
                new Usuario("1", "pass123", "Juan", "Perez")
            };
            mockUserManager?.Setup(m => m.CargarUsuarioPorGrupos(5)).Returns(userList);

            // Act
            var result = controller?.CargarUsuarioPorGrupos(5);

            // Assert
            Assert.AreEqual(1, result?.Count);
            Assert.AreEqual("Juan", result?[0].Nombre);
        }

        [TestMethod]
        public void SaveGroup_CallsMethods()
        {
            // Arrange
            string userId = "1";
            string groupName = "My Group";
            string filePath = Path.GetTempFileName();
            var members = new List<string> { "2" };
            mockDataManager?.Setup(m => m.GuardarUsuarioGrupo(It.IsAny<Grupo>(), members)).Returns(true);

            // Act
            bool? result = controller?.guardaGrupo(userId, groupName, filePath, members);

            // Assert
            Assert.IsTrue(result);
            mockDataManager?.Verify(m => m.GuardarGrupos(It.IsAny<Grupo>()), Times.Once);
            mockDataManager?.Verify(m => m.GuardarUsuarioGrupo(It.IsAny<Grupo>(), members), Times.Once);


        }

        [TestMethod]
        public void SaveLogo_CreatesFile()
        {
            // Arrange
            string sourceFile = Path.GetTempFileName();
            string newName = "logoTest.png";
            string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\assets\img\");
            string destFile = Path.Combine(destinationFolder, newName);
            if (File.Exists(destFile)) File.Delete(destFile);

            // Act
            controller?.guardaLogo(sourceFile, newName);

            // Assert
            Assert.IsTrue(File.Exists(destFile));
        }

        [TestMethod]
        public void LoadGroupsByUser_ReturnsGroups()
        {
            // Arrange
            var groups = new List<Grupo>
            {
                new Grupo(1, "1", "logo.png", "Grupo1")
            };
            mockDataManager?.Setup(m => m.CargarGruposPorUsuario("1")).Returns(groups);

            // Act
            var result = controller?.CargarGruposPorUsuario("1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Grupo1", result[0].Nombre);
        }

        [TestMethod]
        public void LoadUserGroups_ReturnsRelations()
        {
            // Arrange
            var relations = new List<RelacionUsuarioGrupo>
            {
                new RelacionUsuarioGrupo("1", 1)
            };
            mockDataManager?.Setup(m => m.CargarUsuarioGrupos()).Returns(relations);

            // Act
            var result = controller?.CargarUsuarioGrupos();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1", result[0].UsuarioId);
        }

        [TestMethod]
        public void LoadPossibleMembers_ReturnsEmptyWhenNoUsers()
        {
            // Arrange
            mockUserManager?.Setup(m => m.CargarUsuarios()).Returns(new Dictionary<string, Usuario>());

            // Act
            var result = controller?.cargarPosiblesIntegrantes();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void SaveGroup_ReturnsFalseOnFailure()
        {
            // Arrange
            string userId = "1";
            string groupName = "Mi Grupo";
            string filePath = Path.GetTempFileName();
            var members = new List<string> { "2" };
            mockDataManager?.Setup(m => m.GuardarUsuarioGrupo(It.IsAny<Grupo>(), members)).Returns(false);

            // Act
            bool? result = controller?.guardaGrupo(userId, groupName, filePath, members);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SaveLogo_ThrowsIfSourceFileDoesNotExist()
        {
            // Arrange
            string sourceFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".tmp");
            string newName = "logoTest.png";

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                controller?.guardaLogo(sourceFile, newName);
            });
        }

        [TestMethod]
        public void SaveLogo_ThrowsIfSourcePathIsNull()
        {
            // Arrange
            string newName = "logoTest.png";

            // Act & Assert
            Assert.ThrowsException<System.ArgumentException>(() =>
            {
                controller?.guardaLogo(string.Empty, newName); // Pass empty string instead of null
            });
        }

        [TestMethod]
        public void SaveGroup_WithEmptyIntegrantes_ReturnsFalse()
        {
            // Arrange
            string userId = "1";
            string groupName = "Grupo Vacio";
            string filePath = Path.GetTempFileName();
            var members = new List<string>();
            mockDataManager?.Setup(m => m.GuardarUsuarioGrupo(It.IsAny<Grupo>(), members)).Returns(false);

            // Act
            bool? result = controller?.guardaGrupo(userId, groupName, filePath, members);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
