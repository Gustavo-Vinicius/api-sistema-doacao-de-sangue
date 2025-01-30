using Bogus;
using Moq;
using Sistema_de_Doacao_de_Sangue.Application.Commands.DoadoresCommands.EditarDoador;
using Sistema_de_Doacao_de_Sangue.Core.DTOs;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Tests.Application.Commands
{
    public class EditarDoadorCommandHandlerTests
    {
        private readonly Mock<IDoadoresRepository> _doadoresRepositoryMock;
        private readonly Faker _faker;

        public EditarDoadorCommandHandlerTests()
        {
            _doadoresRepositoryMock = new Mock<IDoadoresRepository>();
            _faker = new Faker(); // Inicializa o Bogus para gerar dados fictícios.
        }

        [Fact]
        public async Task Handle_EditarDoador_DeveChamarEditarDoadorAsyncComParametrosCorretos()
        {
            // Arrange
            var doadorId = _faker.Random.Int(); // Gera um ID fictício usando o Bogus
            var doadorDTO = new DoadorDTO // Gera dados fictícios para o doadorDTO
            {
                NomeCompleto = _faker.Name.FullName(),
                Email = _faker.Internet.Email(),
                DataNascimento = _faker.Date.Past(30, DateTime.Now.AddYears(-18)), // Gera data fictícia de nascimento com idade mínima de 18 anos
                Genero = _faker.PickRandom("M", "F"),
                Peso = _faker.Random.Double(50, 120), // Gera um peso entre 50kg e 120kg
                TipoSanguineo = _faker.PickRandom("A", "B", "O", "AB"),
                FatorRh = _faker.PickRandom("+", "-")
            };

            var command = new EditarDoadorCommand { Id = doadorId, doadorDTO = doadorDTO };
            var handler = new EditarDoadorCommandHandler(_doadoresRepositoryMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            _doadoresRepositoryMock.Verify(repo => repo.EditarDoadorAsync(doadorId, doadorDTO), Times.Once);
        }
    }
}