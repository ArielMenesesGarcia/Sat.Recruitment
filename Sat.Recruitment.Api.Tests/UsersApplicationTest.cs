using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Application.DTO;
using Sat.Recruitment.Application.Interface;
using Sat.Recruitment.Transversal.Common;

namespace Sat.Recruitment.Api.Tests
{
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", true, true)
                          .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.AddLogging().BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [Test]
        public async Task InsertAsync_NewUserWithoutErros_True()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange
            var newUser = new UserDTO();
            newUser.Name = "Olivia";
            newUser.Email = "oli@hotmail.com";
            newUser.Address = "Guanajuato, Mex";
            newUser.Phone = "3232323232";
            newUser.UserType = "Normal";
            newUser.Money = 109;
            // Act            
            Result<bool> result = await context.InsertAsync(newUser);
            var actual = result.Data;

            // Assert
            Assert.AreEqual(true, result.Data);
        }
        [Test]
        public async Task InsertAsync_NewUserWithSameInfo_False()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange
            var newUser = new UserDTO();
            newUser.Name = "Olivia";
            newUser.Email = "oli@hotmail.com";
            newUser.Address = "Guanajuato, Mex";
            newUser.Phone = "3232323232";
            newUser.UserType = "Normal";
            newUser.Money = 109;
            // Act            
            Result<bool> result = await context.InsertAsync(newUser);
            var actual = result.Data;

            // Assert
            Assert.AreEqual(false, result.Data);
        }
    }
}