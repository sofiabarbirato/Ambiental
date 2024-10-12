using Ambiental.Data.Context;
using Ambiental.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ambiental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {

        private readonly DatabaseContext _databaseContext;

        public ModelController(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;
        }


        //listar
        [HttpGet]
        public ActionResult<List<QualidadeArModel>> GetAll()
        {
            var lista = _databaseContext.QualidadeArModels.ToList();

            return Ok(lista);
        }


        [HttpGet("{id}")]
        public ActionResult<QualidadeArModel> Get([FromRoute] int id)
        {
            var m = _databaseContext.QualidadeArModels.Find(id);

            if (m == null)
            {
                return NotFound();
            }
            return Ok(m);
        }

        [HttpPost]
        public ActionResult Post([FromBody] QualidadeArModel qualidadeArModel)
        {
            _databaseContext.QualidadeArModels.Add(qualidadeArModel);
            _databaseContext.SaveChanges();


            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, [FromBody] QualidadeArModel qualidadeArModel)
        {
            _databaseContext.QualidadeArModels.Update(qualidadeArModel);
            _databaseContext.SaveChanges();


            return NoContent();
        }
    }
}
