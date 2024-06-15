using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.API.Controllers;

namespace Sistema_de_Doacao_de_Sangue.Tests.Application.Queries
{
    public class ObterDoadorPorIdQueryHandlerTests
    {
        private readonly Mock<IUnityOfWork> _mockUnitOfWork;
        private readonly DoadoresController _controller;

        public ObterDoadorPorIdQueryHandlerTests()
        {
            _mockUnitOfWork = new Mock<IUnityOfWork>();
            _controller = new DoadoresController(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task BuscarDoador_RetornarNotFound_QuandoDoadorNaoForEncontrado()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Doadores.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Doador)null);

            // Act
            var result = await _controller.GetDoador(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}