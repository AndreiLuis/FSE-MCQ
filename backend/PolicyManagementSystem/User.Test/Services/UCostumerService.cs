using User.Domain.Entities;
using User.Domain.Types;
using User.Service.Services;

namespace User.Test.Services
{
    internal class UCostumerService
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterCostumerOK()
        {
            // Arrange
            CostumerEntity costumer = new CostumerEntity
            {
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = DateTime.Now,
                Address = "123 Test Street",
                ContactNumber = "1234567890",
                EmailAddress = "testuser@example.com",
                Salary = 1000.0m,
                PanNumber = 123456789,
                EmployerType = EmployerType.Corporations,
                EmployerName = "Test Employer"
            };

            // Act
            Assert.DoesNotThrow(() => new CostumerService().Register(costumer));
        }

        [Test]
        public void RegisterCostumerError()
        {
            // Arrange
            CostumerEntity costumer = new CostumerEntity();

            // Act
            Assert.Throws<Exception>(() => new CostumerService().Register(costumer));
        }
    }
}
