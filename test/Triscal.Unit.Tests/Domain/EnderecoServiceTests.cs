using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Domain.Interfaces.Services;
using Triscal.Domain.Services;
using Triscal.Domain.Validation;
using Xunit;

namespace Triscal.Unit.Tests.Domain
{
    public class EnderecoServiceTests
    {
        private readonly EnderecoValidation enderecoValidation;
        private readonly Mock<IEnderecoRepository> enderecoRepository;
        private readonly EnderecoService enderecoService;

        public EnderecoServiceTests()
        {
            enderecoValidation = new EnderecoValidation();
            enderecoRepository = new Mock<IEnderecoRepository>();
            enderecoService = new EnderecoService(enderecoRepository.Object);
        }

        [Fact]
        public async void GetAllAsync_Enderecos_Test()
        {
            // Arrange
            var enderecos = new List<Endereco>()
            {
                new Endereco
                {
                    Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                    Logradouro = "Avenida Atlantica, 4",
                    Bairro = "Copacabana",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
                },
                new Endereco
                {
                    Id = Guid.Parse("f245a61e-dd49-44c8-a1fb-f57247d244c2"),
                    Logradouro = "Rua Haddock Lobo, 27",
                    Bairro = "Tijuca",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    ClienteId = Guid.Parse("8b90ec7b-20ea-413a-a4fc-2dbd40f7d2ed")
                },
                new Endereco
                {
                    Id = Guid.Parse("08c0fecb-1866-47e2-b059-0b61518bc6c4"),
                    Logradouro = "Avenida Ataulfo de Paiva, 128",
                    Bairro = "Leblon",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    ClienteId = Guid.Parse("57e8dd30-01ef-48ba-baaf-3358fb2c0a81")
                },
            };

            // Valid
            foreach (var endereco in enderecos)
            {
                enderecoValidation.Validate(endereco).Errors.Should().BeNullOrEmpty();
            }

            // Moq
            enderecoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(enderecos);

            // Act
            var result = await enderecoService.GetAllAsync();

            // Assert
            result.Should().HaveCount(3);
        }

        [Fact]
        public async void GetByIdAsync_Endereco_Test()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                Logradouro = "Avenida Atlantica, 4",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
            };

            // Valid
            enderecoValidation.Validate(endereco).Errors.Should().BeNullOrEmpty();

            // Moq
            enderecoRepository.Setup(x => x.GetByIdAsync(endereco.Id)).ReturnsAsync(endereco);

            // Act
            var result = await enderecoService.GetByIdAsync(endereco.Id);

            // Assert
            result.Should().Be(endereco);
        }

        [Fact]
        public async void InsertAsync_Endereco_Test()
        {
            // Arrange
            var endereco = new Endereco
            {
                Logradouro = "Avenida Atlantica, 4",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
            };

            // Valid
            enderecoValidation.Validate(endereco).Errors.Should().BeNullOrEmpty();

            // Moq
            enderecoRepository.Setup(x => x.InsertAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await enderecoService.InsertAsync(endereco);

            // Assert
            result.Should().Be(endereco);
        }

        [Fact]
        public async void UpdateAsync_Endereco_Test()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                Logradouro = "Avenida Atlantica, 4",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
            };

            // Valid
            enderecoValidation.Validate(endereco).Errors.Should().BeNullOrEmpty();

            // Moq
            enderecoRepository.Setup(x => x.UpdateAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await enderecoService.UpdateAsync(endereco);

            // Assert
            result.Should().Be(endereco);
        }

        [Fact]
        public async void DeleteAsync_Endereco_Test()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                Logradouro = "Avenida Atlantica, 4",
                Bairro = "Copacabana",
                Cidade = "Rio de Janeiro",
                Estado = "Rio de Janeiro",
                ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
            };

            // Valid
            enderecoValidation.Validate(endereco).Errors.Should().BeNullOrEmpty();

            // Moq
            enderecoRepository.Setup(x => x.DeleteAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await enderecoService.DeleteAsync(endereco);

            // Assert
            result.Should().Be(endereco);
        }
    }
}
