using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Metadados.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class Objeto_localizacaoController : Controller
    {

        private readonly Objeto_localizacao_Services _Objeto_localizacao_Services;
        private readonly Localizacao_tipo_Services _Localizacao_tipo_Services;


        public Objeto_localizacaoController(Objeto_localizacao_Services Objeto_localizacao_Services, Localizacao_tipo_Services Localizacao_tipo_Services)
        {
            _Objeto_localizacao_Services = Objeto_localizacao_Services;
            _Localizacao_tipo_Services = Localizacao_tipo_Services;

        }

        public IActionResult Index()
        {
            var list = _Objeto_localizacao_Services.FindAll();

            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {
            Objeto_localizacaoViewModel oObjetoViewModel = new Objeto_localizacaoViewModel();

            // Listas que recebem MODEL
            List<Localizacao_tipo> oListLocalizacao_tipo = _Localizacao_tipo_Services.FindAll();

            // Testar sem a variavel OList
            oObjetoViewModel.oLocalizacao_tipo = oListLocalizacao_tipo;


            return View(oObjetoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Objeto_localizacao Objeto_localizacao)
        {
            _Objeto_localizacao_Services.Insert(Objeto_localizacao);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_localizacao_Services.FindById(id.Value);
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
            _Objeto_localizacao_Services.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_localizacao_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Objeto_localizacao> teste = _Objeto_localizacao_Services.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Objeto_localizacao Objeto_localizacao)
        {
            if (id != Objeto_localizacao.sky_objeto_localizacao)
            {
                return BadRequest();
            }
            try
            {
                _Objeto_localizacao_Services.Update(Objeto_localizacao);
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
