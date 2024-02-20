using Microsoft.AspNetCore.Mvc;
using Moq;
using VirtualLearningAcademic.API.Controllers.Grade;
using VirtualLearningAcademic.API.Controllers.User;
using VirtualLearningAcademic.API.Utility;
using VirtualLearningAcademic.BLL.Services.Contracts.Grade;
using VirtualLearningAcademic.BLL.Services.Contracts.User;
using VirtualLearningAcademic.DTO.Grade;
using VirtualLearningAcademic.DTO.User;

namespace VirtualLearningAcademic.Test
{
    public class UnitControllers
    {
        [Fact]
        public async Task GetUsers_ReturnsOkWithUsersList()
        {
            var userServiceMock = new Mock<IUserService>();
            var expectedUsers = new List<GetUserDTO> { /* Mock your expected users here */ };
            userServiceMock.Setup(service => service.GetAllUser()).ReturnsAsync(expectedUsers);

            var controller = new UsersController(userServiceMock.Object);

            var result = await controller.GetUsers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<List<GetUserDTO>>>(okResult.Value);

            Assert.True(response.status);
            Assert.Same(expectedUsers, response.value);
            Assert.Null(response.mensage);
        }

        [Fact]
        public async Task GetUsers_ReturnsInternalServerErrorOnError()
        {
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(service => service.GetAllUser()).ThrowsAsync(new Exception("Some error"));

            var controller = new UsersController(userServiceMock.Object);

            var result = await controller.GetUsers();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<List<GetUserDTO>>>(okResult.Value);

            Assert.False(response.status);
            Assert.Null(response.value);
            Assert.NotNull(response.mensage);
        }

        [Fact]
        public async Task SaveGrade_ReturnsOkWithCreatedGrade()
        {
            var gradeServiceMock = new Mock<IGradeService>();
            var createGradeDTO = new CreateGradeDTO { };

            var expectedGrade = new GetGradeDTO { };

            gradeServiceMock.Setup(service => service.CreateGrade(It.IsAny<CreateGradeDTO>())).ReturnsAsync(expectedGrade);

            var controller = new GradeController(gradeServiceMock.Object);

            var result = await controller.SaveGrade(createGradeDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<GetGradeDTO>>(okResult.Value);

            Assert.True(response.status);
            Assert.Same(expectedGrade, response.value);
            Assert.Null(response.mensage);
        }

        [Fact]
        public async Task SaveGrade_ReturnsInternalServerErrorOnError()
        {
            var gradeServiceMock = new Mock<IGradeService>();
            gradeServiceMock.Setup(service => service.CreateGrade(It.IsAny<CreateGradeDTO>())).ThrowsAsync(new Exception("Some error"));

            var controller = new GradeController(gradeServiceMock.Object);

            var result = await controller.SaveGrade(new CreateGradeDTO());

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response<GetGradeDTO>>(okResult.Value);

            Assert.False(response.status);
            Assert.Null(response.value);
            Assert.NotNull(response.mensage);

        }

    }

}