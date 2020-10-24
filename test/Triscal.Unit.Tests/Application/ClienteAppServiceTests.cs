using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.Interfaces;
using Triscal.Application.Services;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Services;
using Xunit;

namespace Triscal.Unit.Tests.Application
{
    public class ClienteAppServiceTests
    {
        public ClienteAppServiceTests()
        {
        }

        [Fact]
        public async void GetAllAsync_Clientes_Test()
        {
            // Arrange
            var clientes = new List<Cliente>()
            {
                new Cliente
                {
                   Id = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66"),
                   Nome = "Fulano de Tal",
                   DataNascimento = new DateTime(1990, 6, 18),
                   Cpf = "59479708051",
                   Endereco = new Endereco
                   {
                       Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                       Logradouro = "Avenida Atlantica, 4",
                       Bairro = "Copacabana",
                       Cidade = "Rio de Janeiro",
                       Estado = "Rio de Janeiro",
                       ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
                   }
                },
                new Cliente
                {
                   Id = Guid.Parse("8b90ec7b-20ea-413a-a4fc-2dbd40f7d2ed"),
                   Nome = "Siclano de Tal",
                   DataNascimento = new DateTime(1990, 6, 18),
                   Cpf = "95721344008",
                   Endereco = new Endereco
                   {
                       Id = Guid.Parse("f245a61e-dd49-44c8-a1fb-f57247d244c2"),
                       Logradouro = "Rua Haddock Lobo, 27",
                       Bairro = "Tijuca",
                       Cidade = "Rio de Janeiro",
                       Estado = "Rio de Janeiro",
                       ClienteId = Guid.Parse("8b90ec7b-20ea-413a-a4fc-2dbd40f7d2ed")
                   }
                },
                new Cliente
                {
                   Id = Guid.Parse("57e8dd30-01ef-48ba-baaf-3358fb2c0a81"),
                   Nome = "Beltrano de Tal",
                   DataNascimento = new DateTime(1990, 6, 18),
                   Cpf = "50164293086",
                   Endereco = new Endereco
                   {
                       Id = Guid.Parse("08c0fecb-1866-47e2-b059-0b61518bc6c4"),
                       Logradouro = "Avenida Ataulfo de Paiva, 128",
                       Bairro = "Leblon",
                       Cidade = "Rio de Janeiro",
                       Estado = "Rio de Janeiro",
                       ClienteId = Guid.Parse("57e8dd30-01ef-48ba-baaf-3358fb2c0a81")
                   }
                }
            };

            // Moq
            var clienteService = new Mock<IClienteService>();
            clienteService.Setup(x => x.GetAllAsync()).ReturnsAsync(clientes);

            // Act
            var clienteAppService = new ClienteAppService(clienteService.Object);
            var result = await clienteAppService.GetAllAsync();

            // Assert
            result.Should().HaveCount(3);
        }

        [Fact]
        public async void GetByIdAsync_Cliente_Test()
        {
            // Arrange
            var cliente = new Cliente
            {
                Id = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66"),
                Nome = "Fulano de Tal",
                DataNascimento = new DateTime(1990, 6, 18),
                Cpf = "59479708051",
                Endereco = new Endereco
                {
                    Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                    Logradouro = "Avenida Atlantica, 4",
                    Bairro = "Copacabana",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
                }
            };

            // Moq
            var clienteService = new Mock<IClienteService>();
            clienteService.Setup(x => x.GetByIdAsync(cliente.Id)).ReturnsAsync(cliente);

            // Act
            var clienteAppService = new ClienteAppService(clienteService.Object);
            var result = await clienteAppService.GetByIdAsync(cliente.Id);

            // Assert
            result.Should().Be(cliente);
        }

        [Fact]
        public async void InsertAsync_Cliente_Test()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Fulano de Tal",
                DataNascimento = new DateTime(1990, 6, 18),
                Cpf = "59479708051",
                Endereco = new Endereco
                {
                    Logradouro = "Avenida Atlantica, 4",
                    Bairro = "Copacabana",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                }
            };

            // Moq
            var clienteService = new Mock<IClienteService>();
            clienteService.Setup(x => x.InsertAsync(cliente)).ReturnsAsync(cliente);

            // Act
            var clienteAppService = new ClienteAppService(clienteService.Object);
            var result = await clienteAppService.InsertAsync(cliente);

            // Assert
            result.Should().Be(cliente);
        }

        [Fact]
        public async void UpdateAsync_Cliente_Test()
        {
            // Arrange
            var cliente = new Cliente
            {
                Id = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66"),
                Nome = "Fulano de Tal",
                DataNascimento = new DateTime(1990, 6, 18),
                Cpf = "59479708051",
                Endereco = new Endereco
                {
                    Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"),
                    Logradouro = "Avenida Atlantica, 4",
                    Bairro = "Copacabana",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                    ClienteId = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
                }
            };

            // Moq
            var clienteService = new Mock<IClienteService>();
            clienteService.Setup(x => x.UpdateAsync(cliente)).ReturnsAsync(cliente);

            // Act
            var clienteAppService = new ClienteAppService(clienteService.Object);
            var result = await clienteAppService.UpdateAsync(cliente);

            // Assert
            result.Should().Be(cliente);
        }

        [Fact]
        public async void DeleteAsync_Shopping_Test()
        {
            // Arrange
            var cliente = new Cliente
            {
                Id = Guid.Parse("3ce3c638-88fb-492a-b6db-ae3ac3910d66")
            };

            // Moq
            var clienteService = new Mock<IClienteService>();
            clienteService.Setup(x => x.DeleteAsync(cliente)).ReturnsAsync(cliente);

            // Act
            var clienteAppService = new ClienteAppService(clienteService.Object);
            var result = await clienteAppService.DeleteAsync(cliente);

            // Assert
            result.Should().Be(cliente);
        }
    }
}
