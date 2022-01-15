using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Metadados.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class MapeamentoController : Controller
    {
        private readonly Mapeamento_Services _Mapeamento_Services;
        private readonly Pipeline_Services _Pipeline_Services;

       public MapeamentoController(Mapeamento_Services Mapeamento_Services, Pipeline_Services Pipeline_Services)
        {
            _Mapeamento_Services = Mapeamento_Services;
            _Pipeline_Services = Pipeline_Services; 
        }

        public IActionResult Index()
        {
            var list = _Mapeamento_Services.FindAll();

            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {
            MapeamentoViewModel oObjetoViewModel = new MapeamentoViewModel();

            // Listas que recebem MODEL
            List<Pipeline> oListPipeline = _Pipeline_Services.FindAll();

            // Testar sem a variavel OList
            oObjetoViewModel.oPipeline = oListPipeline;


            return View(oObjetoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mapeamento Mapeamento)
        {
            _Mapeamento_Services.Insert(Mapeamento);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Mapeamento_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _Mapeamento_Services.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Mapeamento_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Mapeamento> teste = _Mapeamento_Services.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Mapeamento Mapeamento)
        {
            if (id != Mapeamento.sky_mapeamento)
            {
                return BadRequest();
            }
            try
            {
                _Mapeamento_Services.Update(Mapeamento);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }


        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}
