using User.Domain.Entities;
using User.Domain.Types;
using User.Service.Services;

namespace User.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
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
                EmployerType = EmployerType.Corporations, // Use the appropriate value
                EmployerName = "Test Employer"
            };

            // Act
            Assert.DoesNotThrow(() => new CostumerService().Register(costumer));

            // Assert
            // Here you should add code to retrieve the inserted record from the database and verify it matches the 'costumer' object.
        }

    }
}