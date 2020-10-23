﻿using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.Interfaces;
using Triscal.Domain.Entities;
using Xunit;

namespace Triscal.Unit.Tests.Application
{
    public class EnderecoAppServiceTests
    {
        private readonly Mock<IEnderecoAppService> _enderecoAppService;

        public EnderecoAppServiceTests()
        {
            _enderecoAppService = new Mock<IEnderecoAppService>();
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

            // Moq
            _enderecoAppService.Setup(r => r.GetAllAsync()).ReturnsAsync(enderecos);

            // Act
            var result = await _enderecoAppService.Object.GetAllAsync();

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

            // Moq
            _enderecoAppService.Setup(r => r.GetByIdAsync(Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"))).ReturnsAsync(endereco);

            // Act
            var result = await _enderecoAppService.Object.GetByIdAsync(Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889"));

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

            // Moq
            _enderecoAppService.Setup(r => r.InsertAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await _enderecoAppService.Object.InsertAsync(endereco);

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

            // Moq
            _enderecoAppService.Setup(r => r.UpdateAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await _enderecoAppService.Object.UpdateAsync(endereco);

            // Assert
            result.Should().Be(endereco);
        }

        [Fact]
        public async void DeleteAsync_Endereco_Test()
        {
            // Arrange
            var endereco = new Endereco
            {
                Id = Guid.Parse("c0b4493d-75dc-4f8f-8259-d10114831889")
            };

            // Moq
            _enderecoAppService.Setup(r => r.DeleteAsync(endereco)).ReturnsAsync(endereco);

            // Act
            var result = await _enderecoAppService.Object.DeleteAsync(endereco);

            // Assert
            result.Should().Be(endereco);
        }
    }
}