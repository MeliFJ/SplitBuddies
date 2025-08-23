using Controlador;
using GestorDatos.Interfaces;
using Modelo;
using Moq;
using System.Reflection;

namespace ControladorTest
{
    [TestClass]
    public class UsuarioControladorTest
    {
        private Mock<IGestorDatosUsuario>? mockUserManager;
        private UsuarioControlador? controller;

        [TestInitialize]
        public void Setup()
        {
            mockUserManager = new Mock<IGestorDatosUsuario>();

            // Limpia la instancia singleton antes de cada test
            var usuarioControladorType = typeof(UsuarioControlador);
            var instanciaField = usuarioControladorType.GetField("instancia", BindingFlags.Static | BindingFlags.NonPublic);
            instanciaField.SetValue(null, null);

            // Crea una nueva instancia con el mock usando el constructor internal
            var nuevaInstancia = Activator.CreateInstance(
                usuarioControladorType,
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                args: new object[] { mockUserManager.Object },
                culture: null
            );
            instanciaField.SetValue(null, nuevaInstancia);

            // Obtén el singleton para el test
            controller = (UsuarioControlador)UsuarioControlador.Instancia();
        }

        [TestMethod]
        public void SaveUser_UserDoesNotExist_ReturnsTrue()
        {
            // Arrange
            var user = new Usuario("1", "pass", "Juan", "Perez");

            // With this line to fix CS8603:
            // Replace this line:
            // With the following to fix CS8600 and CS8625:
            mockUserManager?.Setup(m => m.BuscarUsuario("1")).Returns(() => null!);
            // Act
            var result = controller?.GuardaUsuario(user);

            // Assert
            Assert.IsTrue(result);
            mockUserManager?.Verify(m => m.GuardarUsuario(user), Times.Once);
        }

        [TestMethod]
        public void SaveUser_UserAlreadyExists_ReturnsFalse()
        {
            // Arrange
            var user = new Usuario("1", "pass", "Juan", "Perez");
            mockUserManager?.Setup(m => m.BuscarUsuario("1")).Returns(user);

            // Act
            var result = controller?.GuardaUsuario(user);

            // Assert
            Assert.IsFalse(result);
            mockUserManager?.Verify(m => m.GuardarUsuario(It.IsAny<Usuario>()), Times.Never);
        }

        [TestMethod]
        public void SearchUser_ReturnsUser()
        {
            // Arrange
            var user = new Usuario("1", "pass", "Juan", "Perez");
            mockUserManager?.Setup(m => m.BuscarUsuario("1")).Returns(user);

            // Act
            var result = controller?.BuscarUsuario("1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void LoadUsersByGroup_ReturnsList()
        {
            // Arrange
            var userList = new List<Usuario> { new Usuario("1", "pass", "Juan", "Perez") };
            mockUserManager?.Setup(m => m.CargarUsuarioPorGrupos(5)).Returns(userList);

            // Act
            var result = controller?.CargarUsuarioPorGrupos(5);

            // Assert
            Assert.AreEqual(1, result?.Count);
            Assert.AreEqual("Juan", result?[0].Nombre);
        }

        [TestMethod]
        public void LoadAllUsers_ReturnsDictionary()
        {
            // Arrange
            var users = new Dictionary<string, Usuario>
            {
                { "1", new Usuario("1", "pass", "Juan", "Perez") }
            };
            mockUserManager?.Setup(m => m.CargarUsuarios()).Returns(users);

            // Act
            var result = controller?.CargarUsuarios();

            // Assert
            Assert.AreEqual(1, result?.Count);
            Assert.IsTrue(result?.ContainsKey("1"));
        }

        [TestMethod]
        public void LoadUsersByExpense_ReturnsList()
        {
            // Arrange
            var userList = new List<Usuario> { new Usuario("1", "pass", "Juan", "Perez") };
            mockUserManager?.Setup(m => m.CargarUsuariosPorGastoId(10)).Returns(userList);

            // Act
            var result = controller?.CargarUsuarioPorGastoId(10);

            // Assert
            Assert.AreEqual(1, result?.Count);
            Assert.AreEqual("Juan", result?[0].Nombre);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Limpia la instancia singleton después de cada test
            var usuarioControladorType = typeof(UsuarioControlador);
            var instanciaField = usuarioControladorType.GetField("instancia", BindingFlags.Static | BindingFlags.NonPublic);
            instanciaField?.SetValue(null, null);
        }
    }
}

