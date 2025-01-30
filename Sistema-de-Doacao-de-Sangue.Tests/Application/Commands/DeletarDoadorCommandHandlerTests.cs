using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Moq;
using Org.BouncyCastle.Asn1.Misc;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.DeletarDoador;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;
using Xunit;

namespace Sistema_de_Doacao_de_Sangue.Tests.Application.Commands
{
    public class DeletarDoadorCommandHandlerTests
    {
        private readonly Mock<IDoadoresRepository> _doadoresRepositoryMock;
        private readonly Faker _faker;

        public DeletarDoadorCommandHandlerTests()
        {
            _doadoresRepositoryMock = new Mock<IDoadoresRepository>();
            _faker = new Faker();
        }

        [Fact]
        public async Task Handle_DeletarDoador_DeveChamarDeletarDoadorAsyncComIdCorreto()
        {
            //Arrange
            int doadorId = _faker.Random.Int();
            var command = new DeletarDoadorCommand(doadorId);
            var handler = new DeletarDoadorCommandHandler(_doadoresRepositoryMock.Object);

            //Act 
            await handler.Handle(command, CancellationToken.None);

            //Assert
            _doadoresRepositoryMock.Verify(repo => repo.DeletarDoadorAsync(doadorId), Times.Once);


        }
    }
}