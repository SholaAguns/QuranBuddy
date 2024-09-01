using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using AutoMapper;
using QuranBuddyAPI.Controllers;
using QuranBuddyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using QuranBuddyAPI.Entities;
using QuranBuddyAPI.Models;

namespace QuranBuddyAPI_Tests.ControllerTests.ChapterController_Tests
{
    public class When_Calling_GetChapters
    {
        private readonly Mock<IChapterService> _chapterServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ChapterController _controller;

        public When_Calling_GetChapters()
        {
            _chapterServiceMock = new Mock<IChapterService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new ChapterController(_chapterServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Then_It_Returns_OkResult_WithListOfChapterDtos()
        {
            // Arrange
            var chapters = new List<Chapter> { new Chapter(), new Chapter() };
            var chapterDtos = new List<ChapterDto> { new ChapterDto(), new ChapterDto() };

            _chapterServiceMock.Setup(s => s.GetAllChaptersAsync()).ReturnsAsync(chapters);
            _mapperMock.Setup(m => m.Map<ICollection<ChapterDto>>(chapters)).Returns(chapterDtos);

            // Act
            var result = await _controller.GetChapters();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ChapterDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}
