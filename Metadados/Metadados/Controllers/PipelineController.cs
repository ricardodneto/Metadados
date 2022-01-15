using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class PipelineController: Controller
    {
    
            private readonly Pipeline_Services _Pipeline_Services;

            public PipelineController(Pipeline_Services Pipeline_Services)
            {
               
                _Pipeline_Services = Pipeline_Services;
            }

            public IActionResult Index()
            {
                var list = _Pipeline_Services.FindAll();

                return View(list);
            }


            //GET: Tipo_objeto/Create
            public IActionResult Create()
            {

                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Pipeline Pipeline)
            {
                _Pipeline_Services.Insert(Pipeline);
                return RedirectToAction("Index");

            }
            public IActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();

                }
                var obj = _Pipeline_Services.FindById(id.Value);
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
                 _Pipeline_Services.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            public IActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();

                }
                var obj = _Pipeline_Services.FindById(id.Value);
                if (obj == null)
                {
                    return NotFound();
                }
                List<Pipeline> teste = _Pipeline_Services.FindAll();
                //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

                return View(obj);

            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int? id, Pipeline Pipeline)
            {
                if (id != Pipeline.sky_pipeline)
                {
                    return BadRequest();
                }
                try
                {
                     _Pipeline_Services.Update(Pipeline);
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
