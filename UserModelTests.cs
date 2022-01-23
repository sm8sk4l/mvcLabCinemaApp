using KinoProject.Data.Services;
using KinoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KinoProjectTests
{
    public class UserModelTest
    {
        [Fact]
        public void UserValidation_ForNullUser_ReturnFalse()
        {
            // Arrange
            User user = null;

            // Act
            bool result = UserService.ValidateUser(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UserValidation_ForWithoutMail_ReturnFalse()
        {
            // Arrange
            User user = new User()
            {
                Id = 2,
                Password = "SomePassword",
                Name = "Andrzej"
            };

            // Act
            bool result = UserService.ValidateUser(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void UserValidation_ForCorrectData_ReturnTrue()
        {
            // Arrange
            User user = new User()
            {
                Id = 2,
                Password = "SomePassword",
                Name = "Andrzej",
                Mail = "Andrzej@mail.com"
            };

            // Act
            bool result = UserService.ValidateUser(user);

            // Assert
            Assert.True(result);
        }
    }
}
