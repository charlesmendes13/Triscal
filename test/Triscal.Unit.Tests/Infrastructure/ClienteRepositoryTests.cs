using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;
using Triscal.Infrastructure.Data.Repository;
using Triscal.Unit.Tests.Infrastructure.DbContext;
using Xunit;

namespace Triscal.Unit.Tests.Infrastructure
{
    public class ClienteRepositoryTests
    {
        public ClienteRepositoryTests()
        {
        }

        [Fact]
        public async void GetAllAsync_Clientes_Test()
        {
            // Arrange
            var clientes = new List<Cliente>
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seed(clientes);

                // Act
                var clienteRepository = new ClienteRepository(dbContext);
                var result = await clienteRepository.GetAllAsync();

                // Assert
                result.Should().HaveCount(3);
            }
        }

        [Fact]
        public async void GetByIdAsync_Cliente_Test()
        {
            // Arrange
            var cliente = new Cliente
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
            };

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seed(cliente);

                // Act
                var clienteRepository = new ClienteRepository(dbContext);
                var result = await clienteRepository.GetByIdAsync(cliente.Id);

                // Assert
                result.Nome.Should().Be(cliente.Nome);
            }
        }

        [Fact]
        public async void InsertAsync_Cliente_Test()
        {
            // Arrange
            var cliente = new Cliente
            {
                Nome = "Tom Jobim",
                DataNascimento = new DateTime(1965, 2, 10),
                Cpf = "86237341064",
                Endereco = new Endereco
                {
                    Logradouro = "Avenida Jardim Botânico, 1",
                    Bairro = "Jardim Botânico",
                    Cidade = "Rio de Janeiro",
                    Estado = "Rio de Janeiro",
                }
            };

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();

                // Act
                var clienteRepository = new ClienteRepository(dbContext);
                var result = await clienteRepository.InsertAsync(cliente);

                // Assert
                result.Should().Be(cliente);
            }
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seed(cliente);

                // Act
                var clienteRepository = new ClienteRepository(dbContext);
                var result = await clienteRepository.UpdateAsync(cliente);

                // Assert
                result.Should().Be(cliente);
            }
        }

        [Fact]
        public async void DeleteAsync_Shopping_Test()
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seed(cliente);

                // Act
                var clienteRepository = new ClienteRepository(dbContext);
                var result = await clienteRepository.DeleteAsync(cliente);

                // Assert
                result.Should().Be(cliente);
            }
        }
    }
}
