using Entity_Layer;
using InterfaceLayer;
using ManagerLayer;
using Moq;

[TestClass]
public class PeopleManagerTests
{
    private Mock<IUserRepository> _mockUserRepository;
    private Mock<IAdministratorRepository> _mockAdministratorRepository;
    private PeopleManager _peopleManager;

    [TestInitialize]
    public void Setup()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockAdministratorRepository = new Mock<IAdministratorRepository>();
        _peopleManager = new PeopleManager(_mockUserRepository.Object, _mockAdministratorRepository.Object);
    }

    [TestMethod]
    public void AddPerson_WhenUserIsAdded_ReturnsTrue()
    {
        var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
        string errorMessage = string.Empty;
        _mockUserRepository.Setup(m => m.AddUser(It.IsAny<User>(), out errorMessage)).Returns(true);

        var result = _peopleManager.AddPerson(user, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void AddPerson_WhenAdminIsAdded_ReturnsTrue()
    {
        var admin = new Administrator(1, "admin@example.com", "password", "adminname", DateTime.Now, "1234567890", "salt");
        string errorMessage = string.Empty;
        _mockAdministratorRepository.Setup(m => m.AddAdmin(It.IsAny<Administrator>(), out errorMessage)).Returns(true);

        var result = _peopleManager.AddPerson(admin, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void RemovePerson_WhenUserIsRemoved_ReturnsTrue()
    {
        var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
        string errorMessage = string.Empty;
        _mockUserRepository.Setup(m => m.RemoveUser(It.IsAny<User>(), out errorMessage)).Returns(true);

        var result = _peopleManager.RemovePerson(user, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void RemovePerson_WhenAdminIsRemoved_ReturnsTrue()
    {
        var admin = new Administrator(1, "admin@example.com", "password", "adminname", DateTime.Now, "1234567890", "salt");
        string errorMessage = string.Empty;
        _mockAdministratorRepository.Setup(m => m.RemoveAdmin(It.IsAny<Administrator>(), out errorMessage)).Returns(true);

        var result = _peopleManager.RemovePerson(admin, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void UpdatePerson_WhenUserIsUpdated_ReturnsTrue()
    {
        var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
        string errorMessage = string.Empty;
        _mockUserRepository.Setup(m => m.UpdateUser(It.IsAny<User>(), out errorMessage)).Returns(true);

        var result = _peopleManager.UpdatePerson(user, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void UpdatePerson_WhenAdminIsUpdated_ReturnsTrue()
    {
        var admin = new Administrator(1, "admin@example.com", "password", "adminname", DateTime.Now, "1234567890", "salt");
        string errorMessage = string.Empty;
        _mockAdministratorRepository.Setup(m => m.UpdateAdmin(It.IsAny<Administrator>(), out errorMessage)).Returns(true);

        var result = _peopleManager.UpdatePerson(admin, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void AuthenticateUser_WhenCredentialsAreValid_ReturnsTrue()
    {
        var email = "user@example.com";
        var password = "password";
        var (hashedPassword, salt) = _peopleManager.HashPassword(password);

        var user = new User(1, email, hashedPassword, "username", DateTime.Now, 12345, salt, "/path/to/profile");

        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User> { user });

        string errorMessage = string.Empty;

        var result = _peopleManager.AuthenticateUser(email, password, out errorMessage);

        Assert.IsTrue(result);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    [TestMethod]
    public void AuthenticateUser_WhenPasswordIsInvalid_ReturnsFalse()
    {
        var email = "user@example.com";
        var password = "wrongpassword";
        var (hashedPassword, salt) = _peopleManager.HashPassword("password");

        var user = new User(1, email, hashedPassword, "username", DateTime.Now, 12345, salt, "/path/to/profile");

        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User> { user });

        string errorMessage = string.Empty;

        var result = _peopleManager.AuthenticateUser(email, password, out errorMessage);

        Assert.IsFalse(result);
        Assert.AreEqual("Invalid password.", errorMessage);
    }

    [TestMethod]
    public void AuthenticateUser_WhenEmailIsInvalid_ReturnsFalse()
    {
        string errorMessage = string.Empty;
        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User>());

        var result = _peopleManager.AuthenticateUser("invalid@example.com", "password", out errorMessage);

        Assert.IsFalse(result);
        Assert.AreEqual("User not found.", errorMessage);
    }

    [TestMethod]
    public void GetUser_WhenUserExists_ReturnsUser()
    {
        var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User> { user });

        var result = _peopleManager.GetUser("user@example.com");

        Assert.IsNotNull(result);
        Assert.AreEqual(user.Email, result.Email);
    }

    [TestMethod]
    public void GetUser_WhenUserDoesNotExist_ReturnsNull()
    {
        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User>());

        var result = _peopleManager.GetUser("user@example.com");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void GetAllPeople_ReturnsAllPeople()
    {
        var user = new User(1, "user@example.com", "password", "username", DateTime.Now, 12345, "salt", "/path/to/profile");
        var admin = new Administrator(1, "admin@example.com", "password", "adminname", DateTime.Now, "1234567890", "salt");
        _mockUserRepository.Setup(m => m.GetAllUsers()).Returns(new List<User> { user });
        _mockAdministratorRepository.Setup(m => m.GetAllAdministrators()).Returns(new List<Administrator> { admin });

        var result = _peopleManager.GetAllPeople();

        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(p => p is User));
        Assert.IsTrue(result.Any(p => p is Administrator));
    }
}
