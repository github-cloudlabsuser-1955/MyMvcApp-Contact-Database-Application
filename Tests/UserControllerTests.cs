using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Controllers;
using MyMvcApp.Models;
using Xunit;

namespace MyMvcApp.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(UserController.userlist, result.Model);
        }

        [Fact]
        public void Details_UserExists_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(user, result.Model);

            // Cleanup
            UserController.userlist.Clear();
        }

        [Fact]
        public void Details_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Details(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "Jane Doe", Email = "jane.doe@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Contains(user, UserController.userlist);

            // Cleanup
            UserController.userlist.Clear();
        }

        [Fact]
        public void Create_InvalidModel_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            controller.ModelState.AddModelError("Name", "Required");
            var user = new User { Id = 1, Email = "jane.doe@example.com" };

            // Act
            var result = controller.Create(user) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(user, result.Model);
        }

        [Fact]
        public void Edit_UserExists_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(user, result.Model);

            // Cleanup
            UserController.userlist.Clear();
        }

        [Fact]
        public void Edit_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Edit(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Edit_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            UserController.userlist.Add(user);
            var updatedUser = new User { Id = 1, Name = "John Updated", Email = "john.updated@example.com" };

            // Act
            var result = controller.Edit(1, updatedUser) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("John Updated", UserController.userlist.First().Name);

            // Cleanup
            UserController.userlist.Clear();
        }

        [Fact]
        public void Delete_UserExists_ReturnsViewWithUser()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Delete(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            Assert.Equal(user, result.Model);

            // Cleanup
            UserController.userlist.Clear();
        }

        [Fact]
        public void Delete_UserDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteConfirmed_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" };
            UserController.userlist.Add(user);

            // Act
            var result = controller.Delete(1, null) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.DoesNotContain(user, UserController.userlist);
        }
    }
}