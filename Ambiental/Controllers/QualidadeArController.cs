using Ambiental.Data.Context;
using Ambiental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Drawing.Text;

namespace Ambiental.Controllers
{
    public class QualidadeArController : Controller
    {

        private List<QualidadeArModel> qualidadeArModels;

        private readonly DatabaseContext _databaseContext;

        public QualidadeArController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            
            //qualidadeArModels = databaseContext.QualidadeArModels.ToList();
            //qualidadeArModels = new List<QualidadeArModel>();
            //qualidadeArModels.Add(new QualidadeArModel(1, "São Paulo", "Alta", 2024));
            //qualidadeArModels.Add(new QualidadeArModel(2, "Manaus", "Média", 2023));
            //qualidadeArModels.Add(new QualidadeArModel(3, "Rio de Janeiro", "Baixa", 2023));


        }
    

        public IActionResult Index()
        {

            //SELECT DA TABELA QUALIDADE DE AR
            //var listaModelos = repository.GetAll();


            var listaModelos = _databaseContext.QualidadeArModels.ToList();

            return View(listaModelos);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(QualidadeArModel qualidadeArModel)
        {

            _databaseContext.QualidadeArModels.Add(qualidadeArModel);
            _databaseContext.SaveChanges();


            var mensagem = "Qualidade de ar inserida com sucesso.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var qualidadeArModel = _databaseContext.QualidadeArModels.Find(id);
            if (qualidadeArModel == null)
            {
                return NotFound();
            }
            return View("Edit");
        }

        [HttpPost]
        public IActionResult Edit(QualidadeArModel qualidadeArModel)
        {
            if (ModelState.IsValid)
            {
                _databaseContext.Update(qualidadeArModel);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do item {qualidadeArModel.Id} foram alterados com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View("Edit");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var qualidadeArModel = _databaseContext.QualidadeArModels.Find(id);
            if (qualidadeArModel == null)
            {
                return NotFound();
            }
            return View("Delete");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var qualidadeArModel = _databaseContext.QualidadeArModels.Find(id);
            if (qualidadeArModel != null)
            {
                _databaseContext.QualidadeArModels.Remove(qualidadeArModel);
                _databaseContext.SaveChanges();
                TempData["mensagemSucesso"] = $"Os dados do item {qualidadeArModel.Id} foram removidos com sucesso";
            }
            else
            {
                TempData["mensagemErro"] = "Item não encontrado.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}