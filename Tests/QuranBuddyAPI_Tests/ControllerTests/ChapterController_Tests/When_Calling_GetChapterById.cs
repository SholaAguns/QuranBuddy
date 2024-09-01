using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuranBuddyAPI.Controllers;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;
using QuranBuddyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuranBuddyAPI_Tests.ControllerTests.ChapterController_Tests
{
    public class When_Calling_GetChapterById
    {

        private readonly Mock<IChapterService> _chapterServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ChapterController _controller;

        public When_Calling_GetChapterById()
        {
            _chapterServiceMock = new Mock<IChapterService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ChapterController(_chapterServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Then_It_Returns_OkResult_WithChapterDto()
        {

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext() // Initialize with a DefaultHttpContext
            };

            // Arrange
            var chapter = new Chapter();
            var chapterDto = new ChapterDto();
            

            _chapterServiceMock.Setup(s => s.GetChapterByIdAsync(It.IsAny<int>())).ReturnsAsync(chapter);
            _mapperMock.Setup(m => m.Map<ICollection<ChapterDto>>(chapter)).Returns(new List<ChapterDto> { chapterDto });

            // Act
            var result = await _controller.GetChapterById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ChapterDto>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task Then_It_Returns_BadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Id", "Required");

            // Act
            var result = await _controller.GetChapterById(1);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(_controller.ModelState, badRequestResult.Value);
        }

        [Fact]
        public async Task Then_It_Returns_NotFound_WhenChapterDoesNotExist()
        {
            // Arrange
            _chapterServiceMock.Setup(s => s.GetChapterByIdAsync(It.IsAny<int>())).ReturnsAsync((Chapter)null);

            // Act
            var result = await _controller.GetChapterById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
