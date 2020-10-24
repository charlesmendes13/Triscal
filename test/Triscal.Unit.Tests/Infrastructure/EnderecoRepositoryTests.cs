using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
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
    public class EnderecoRepositoryTests
    {
        public EnderecoRepositoryTests()
        {
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seeds(enderecos);

                // Act
                var enderecoRepository = new EnderecoRepository(dbContext);
                var result = await enderecoRepository.GetAllAsync();

                // Assert
                result.Should().HaveCount(3);
            }
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seeds(endereco);

                // Act
                var enderecoRepository = new EnderecoRepository(dbContext);
                var result = await enderecoRepository.GetByIdAsync(endereco.Id);

                // Assert
                result.Logradouro.Should().Be(endereco.Logradouro);
            }
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();

                // Act
                var enderecoRepository = new EnderecoRepository(dbContext);
                var result = await enderecoRepository.InsertAsync(endereco);

                // Assert
                result.Should().Be(endereco);
            }
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seeds(endereco);

                // Act
                var enderecoRepository = new EnderecoRepository(dbContext);
                var result = await enderecoRepository.UpdateAsync(endereco);

                // Assert
                result.Should().Be(endereco);
            }
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

            using (var database = new InMemoryDbContext())
            {
                // Moq
                var dbContext = database.DbContext();
                database.Seeds(endereco);

                // Act
                var enderecoRepository = new EnderecoRepository(dbContext);
                var result = await enderecoRepository.DeleteAsync(endereco);

                // Assert
                result.Should().Be(endereco);
            }
        }
    }
}
