using Microsoft.EntityFrameworkCore;
using Ambiental.Controllers;
using Ambiental.Data.Context;
using Ambiental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Ambiental.Test
{
    public class UnitTest1
    {
            private readonly DatabaseContext _context;
            private readonly QualidadeArController _controller;

            public UnitTest1()
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;

                _context = new DatabaseContext(options);
                _controller = new QualidadeArController(_context);

                // Mock HttpContext if necessary
                _controller.ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                };

                SeedDatabase();
            }

            private void SeedDatabase()
            {
                if (!_context.QualidadeArModels.Any())
                {
                    _context.QualidadeArModels.AddRange(
                        new QualidadeArModel { Id = 1, Localizacao = "São Paulo", IndiceQualidade = "Alta", DataLeitura = 2024 },
                        new QualidadeArModel { Id = 2, Localizacao = "Manaus", IndiceQualidade = "Média", DataLeitura = 2023 },
                        new QualidadeArModel { Id = 3, Localizacao = "Rio de Janeiro", IndiceQualidade = "Baixa", DataLeitura = 2023 }
                    );
                    _context.SaveChanges();
                }
            }

            [Fact]
            public void retornoCreateTest()
            {
                // Act
                var result = _controller.Create();

                // Assert
                Assert.IsType<ViewResult>(result);
            }

            [Fact]
            public void retornoIndexTest()
            {
                // Act
                var result = _controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);

            }

            [Fact]
            public void retornoEditTest()
            {
                // Act
                var result = _controller.Edit(1);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);

            }

            [Fact]
            public void Edit_Post_ReturnsARedirectAndUpdatesQualidadeArModel()
            {
                // Arrange
                var qualidadeArModel = _context.QualidadeArModels.First();
                qualidadeArModel.Localizacao = "Updated Location";

                // Act
                var result = _controller.Edit(qualidadeArModel);

                // Assert
                Assert.IsType<RedirectToActionResult>(result);
                var updatedModel = _context.QualidadeArModels.Find(qualidadeArModel.Id);
                Assert.Equal("Updated Location", updatedModel.Localizacao);
            }

            [Fact]
            public void retornoDeleteTest()
            {
                // Act
                var result = _controller.Delete(1);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);

            }

            [Fact]
            public void Delete_Post_ReturnsARedirectAndRemovesQualidadeArModel()
            {
                // Act
                var result = _controller.DeleteConfirmed(1);

                // Assert
                Assert.IsType<RedirectToActionResult>(result);
                var deletedModel = _context.QualidadeArModels.Find(1);
                Assert.Null(deletedModel);
            }
        }
    }
