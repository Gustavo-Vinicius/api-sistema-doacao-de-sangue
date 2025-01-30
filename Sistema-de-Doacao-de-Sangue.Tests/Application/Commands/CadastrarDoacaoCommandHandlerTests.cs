using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoacoesCommands.CadastrarDoacao;
using Sistema_de_Doacao_de_Sangue.Application.InputModels;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;
using Xunit;

namespace Sistema_de_Doacao_de_Sangue.Tests.Application.Commands
{
    public class CadastrarDoacaoCommandHandlerTests
    {
        private readonly Mock<IDoacaoRepository> _doacaoRepositoryMock;
        private readonly CadastrarDoacaoCommandHandler _handler;

        public CadastrarDoacaoCommandHandlerTests()
        {
            _doacaoRepositoryMock = new Mock<IDoacaoRepository>();
            _handler = new CadastrarDoacaoCommandHandler(_doacaoRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Call_AdicionarDoacaoAsync_When_ValidCommand()
        {
            // Arrange
            var doacaoInput = new CadastrarDoacaoInputModels
            {
                DoadorId = 1,
                DataDoacao = DateTime.Now,
                QuantidadeML = 500
            };

            var command = new CadastrarDoacaoCommand(doacaoInput);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result); // Comparando diretamente com Unit.Value
            _doacaoRepositoryMock.Verify(x => x.AdicionarDoacaoAsync(
                command.CadastrarDoacao.DoadorId,
                command.CadastrarDoacao.DataDoacao,
                command.CadastrarDoacao.QuantidadeML), Times.Once);
        }
    }
}