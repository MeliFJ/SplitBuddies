using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Controlador;
using GestorDatos.Interfaces;
using Modelo;

namespace Controlador.Tests
{
    [TestClass]
    public class LoginControladorTests
    {
        private Mock<IGestorDatosUsuario> mockUserManager;
        private LoginControlador loginController;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            mockUserManager = new Mock<IGestorDatosUsuario>();
            loginController = new LoginControlador(mockUserManager.Object);
        }

        [TestMethod]
        public void ConstructorShouldInitializeInstance()
        {
            // Arrange
            var mock = new Mock<IGestorDatosUsuario>();

            // Act
            var controller = new LoginControlador(mock.Object);

            // Assert
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void ValidateLoginCorrectCredentials_ReturnsUser()
        {
            // Arrange
            var id = "123";
            var password = "pass";
            var user = new Usuario(id, password, "Juan", "Perez");
            mockUserManager.Setup(m => m.BuscarUsuario(id)).Returns(user);

            // Act
            var result = loginController.ValidarLogin(id, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void ValidateLoginWrongPasswordReturnsNull()
        {
            // Arrange
            var id = "123";
            var user = new Usuario(id, "otherPass", "Juan", "Perez");
            mockUserManager.Setup(m => m.BuscarUsuario(id)).Returns(user);

            // Act
            var result = loginController.ValidarLogin(id, "wrongPass");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ValidateLoginUserNotFound_ReturnsNull()
        {
            // Arrange
            var id = "999";
            mockUserManager.Setup(m => m.BuscarUsuario(id)).Returns((Usuario?)null);

            // Act
            var result = loginController.ValidarLogin(id, "anyPass");

            // Assert
            Assert.IsNull(result);
        }
    }
}
