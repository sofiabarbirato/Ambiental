using Ambiental.Controllers;
using Ambiental.Data.Context;
using Ambiental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambiental.Test
{
    public class QualidadeArControllerTest
    {

        private readonly Mock<DatabaseContext> _mockContext;

        private readonly QualidadeArController _qualidadeArController;

        private readonly DbSet<QualidadeArModel> _mockSet;

        public QualidadeArControllerTest() 
        {
            // Inicializa o mock do contexto
            _mockContext = new Mock<DatabaseContext>();
            // Cria e configura o mock DbSet
            _mockSet = MockDbSet();
            // Configura o contexto mock para retornar o DbSet mock quando a propriedade Clientes for acessada
            _mockContext.Setup(m => m.QualidadeArModels).Returns(_mockSet);
            // Inicializa o controller com o contexto mock
            _qualidadeArController = new QualidadeArController(_mockContext.Object);
        }

        private DbSet<QualidadeArModel> MockDbSet()
        { 

            var data = new List<QualidadeArModel>()
            {
                new QualidadeArModel { Id = 1, Localizacao = "São Paulo", IndiceQualidade = "Alta", DataLeitura = 2024 },
                new QualidadeArModel { Id = 2, Localizacao = "Manaus", IndiceQualidade = "Média", DataLeitura = 2023 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<QualidadeArModel>>();

            mockSet.As<IQueryable<QualidadeArModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<QualidadeArModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<QualidadeArModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<QualidadeArModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;


        }

        [Fact]
        public void Index_ReturnsViewWithQualidadeAr()
        {
            //Act
            var result = _qualidadeArController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<QualidadeArModel>>(viewResult.Model);

            Assert.Equal(2, model.Count());

           
        }

    }
}
