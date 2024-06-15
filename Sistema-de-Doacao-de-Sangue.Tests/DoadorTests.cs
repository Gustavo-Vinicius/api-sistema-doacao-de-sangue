using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using Sistema_de_Doacao_de_Sangue.API.Controllers;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador;
using Sistema_de_Doacao_de_Sangue.Application.InputModels;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoacoesPorDoador;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterDoadorPorId;
using Sistema_de_Doacao_de_Sangue.Application.Queries.DoadoresQueries.ObterListagemDeDoadores;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;

namespace Sistema_de_Doacao_de_Sangue.Tests
{
    public class DoadorTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly DoadorController _controller;

        public DoadorTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new DoadorController(_mediatorMock.Object);
        }

        [Fact]
        public async Task ObterDoadorPorIdAsync_ReturnsOkResult()
        {
            // Arrange
            var query = new ObterDoadorPorIdQuery { Id = 1 };
            _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(new DoadorDTO());

            // Act
            var result = await _controller.ObterDoadorPorIdAsync(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<DoadorDTO>(okResult.Value);
        }

        [Fact]
        public async Task ObterTodosDoadoresAsync_ReturnsOkResult()
        {
            // Arrange
            var query = new ObterListagemDeDoadoresQuery();
            _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(new List<DoadorDTO>());

            // Act
            var result = await _controller.ObterTodosDoadoresAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<DoadorDTO>>(okResult.Value);
        }

        [Fact]
        public async Task ObterDoacoesPorDoadorAsync_ReturnsOkResult()
        {
            // Arrange
            var query = new ObterDoacoesPorDoadorQuery { Id = 1 };
            _mediatorMock.Setup(m => m.Send(query, default)).ReturnsAsync(new List<DoacaoDTO>());

            // Act
            var result = await _controller.ObterDoacoesPorDoadorAsync(query);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<DoacaoDTO>>(okResult.Value);
        }

        [Fact]
        public async Task PostDoador_ReturnsOkResult()
        {
            // Arrange
            var inputModel = new CadastrarDoadorInputModels
            {
                NomeCompleto = "João Silva",
                Email = "joao.silva@example.com",
                DataNascimento = new DateTime(1990, 5, 24),
                Genero = "Masculino",
                Peso = 75.5,
                TipoSanguineo = "O",
                FatorRh = "+"
            };

            var command = new CadastrarDoadorCommand(inputModel);

            _mediatorMock.Setup(m => m.Send(command, default)).Returns(OkResult.Equals);

            // Act
            var result = await _controller.PostDoador(command);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task EditarDoadorAsync_ReturnsNoContentResult()
        {
            // Arrange
            var command = new EditarDoadorCommand
            {
                Id = 1,
                doadorDTO = new DoadorDTO
                {
                    NomeCompleto = "João Silva",
                    Email = "joao.silva@example.com",
                    DataNascimento = new DateTime(1990, 5, 24),
                    Genero = "Masculino",
                    Peso = 75.5,
                    TipoSanguineo = "O",
                    FatorRh = "+"
                }
            };
            _mediatorMock.Setup(m => m.Send(command, default)).Returns(OkResult.Equals);

            // Act
            var result = await _controller.EditarDoadorAsync(command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteDoadorAsync_ReturnsNoContentResult()
        {
            // Arrange
            var command = new DeletarDoadorCommand { Id = 1 };
            _mediatorMock.Setup(m => m.Send(command, default)).Returns(OkResult.Equals);

            // Act
            var result = await _controller.DeleteDoadorAsync(command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}