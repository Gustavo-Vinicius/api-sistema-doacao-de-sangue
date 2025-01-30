using Bogus;
using MediatR;
using Moq;
using Sistema_de_Doacao_de_Sangue.Application.Command.DoadoresCommands.CadastrarDoador;
using Sistema_de_Doacao_de_Sangue.Application.InputModels;
using Sistema_de_Doacao_de_Sangue.Core.Entities;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;

namespace Sistema_de_Doacao_de_Sangue.Tests.Application.Commands
{
    public class CadastrarDoadorCommandHandlerTests
    {
        private readonly Mock<IDoadoresRepository> _doadoresRespositoryMock;
        private readonly Mock<IUnityOfWork> _unityOfWorkMock;
        private readonly CadastrarDoadorCommandHandler _handler;
        private readonly Faker _faker = new("en");

        public CadastrarDoadorCommandHandlerTests()
        {
            _doadoresRespositoryMock = new Mock<IDoadoresRepository>();
            _unityOfWorkMock = new Mock<IUnityOfWork>();
            _handler = new CadastrarDoadorCommandHandler(_doadoresRespositoryMock.Object, _unityOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Email_Already_Cadastrado()
        {
            // Arrange
            var cadastrarDoadorInput = new CadastrarDoadorInputModels
            {
                NomeCompleto = _faker.Person.FullName,
                Email = $"{_faker.Person.FirstName.ToLower()}@example.com",
                DataNascimento = _faker.Date.Past(30, DateTime.Now.AddYears(-18)),
                Genero = _faker.PickRandom("Masculino", "Feminino"),
                Peso = _faker.Random.Int(50, 100),
                TipoSanguineo = _faker.PickRandom("A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-"),
                FatorRh = _faker.PickRandom("+", "-"),
            };

            var command = new CadastrarDoadorCommand(cadastrarDoadorInput);

            // Configura o mock para retornar uma lista vazia de doadores
            _unityOfWorkMock
                .Setup(x => x.Doadores.GetAllAsync())
                .ReturnsAsync(new List<Doador>() as IEnumerable<Doador>); // Alteração aqui


            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Unit.Value, result);
            _doadoresRespositoryMock.Verify(x => x.AdicionarUmDoadorAsync(
                cadastrarDoadorInput.NomeCompleto,
                cadastrarDoadorInput.Email,
                cadastrarDoadorInput.DataNascimento,
                cadastrarDoadorInput.Genero,
                cadastrarDoadorInput.Peso,
                cadastrarDoadorInput.TipoSanguineo,
                cadastrarDoadorInput.FatorRh), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Idade_Menor_Que_18()
        {
            // Arrange
            var cadastrarDoadorInput = new CadastrarDoadorInputModels
            {
                NomeCompleto = _faker.Person.FullName,
                Email = $"{_faker.Person.FirstName.ToLower()}@example.com",
                DataNascimento = DateTime.Now.AddYears(-16), // 16 anos
                Genero = _faker.PickRandom("Masculino", "Feminino"),
                Peso = _faker.Random.Int(50, 100),
                TipoSanguineo = _faker.PickRandom("A+", "A-", "B+", "B-", "O+", "O-", "AB+", "AB-"),
                FatorRh = _faker.PickRandom("+", "-"),
            };

            var command = new CadastrarDoadorCommand(cadastrarDoadorInput);

            _unityOfWorkMock
                .Setup(x => x.Doadores.GetAllAsync())
                .ReturnsAsync(new List<Doador>() as IEnumerable<Doador>); // Alteração aqui

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Menor de idade não pode doar sangue", exception.Message);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Peso_Menor_Que_50kg()
        {
            // Arrange
            var cadastrarDoadorInput = new CadastrarDoadorInputModels
            {
                NomeCompleto = "João Silva",
                Email = "joao.silva@example.com",
                DataNascimento = new DateTime(2000, 1, 1),
                Genero = "Masculino",
                Peso = 40, // 40 kg
                TipoSanguineo = "O+",
                FatorRh = "+",
            };

            var command = new CadastrarDoadorCommand(cadastrarDoadorInput);

            _unityOfWorkMock
                .Setup(x => x.Doadores.GetAllAsync())
                .ReturnsAsync(new List<Doador>() as IEnumerable<Doador>); // Alteração aqui

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Peso deve ser maior ou igual a 50KG", exception.Message);
        }
    }
}