using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Metadados.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class Objeto_configuracaoController : Controller
    {

        private readonly Objeto_configuracao_Service _Objeto_configuracao_Service;
        private readonly Objeto_tipo_Services _Objeto_tipo_Services;


        public Objeto_configuracaoController(Objeto_configuracao_Service Objeto_configuracao_Service, Objeto_tipo_Services Objeto_tipo_Services)
        {
            _Objeto_configuracao_Service = Objeto_configuracao_Service;
            _Objeto_tipo_Services = Objeto_tipo_Services;

        }

        public IActionResult Index()
        {
            var list = _Objeto_configuracao_Service.FindAll();

            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {
            ObjetoconfiguracaoViewModel oObjetoViewModel = new ObjetoconfiguracaoViewModel();

            // Listas que recebem MODEL
            List<Objeto_tipo> oListObjeto_tipo = _Objeto_tipo_Services.FindAll();

            // Testar sem a variavel OList
            oObjetoViewModel.oObjeto_tipo = oListObjeto_tipo;


            return View(oObjetoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Objeto_configuracao Objeto_configuracao){
            ObjetoconfiguracaoViewModel oObjetoViewModel = new ObjetoconfiguracaoViewModel();
            oObjetoViewModel.Objeto_configuracao = Objeto_configuracao;
            oObjetoViewModel.oObjeto_tipo = _Objeto_tipo_Services.FindAll();
   
           

            if (ModelState.IsValid)
            {
                _Objeto_configuracao_Service.Insert(Objeto_configuracao);
                return RedirectToAction("Index");
            }
           
            return View(oObjetoViewModel);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_configuracao_Service.FindById(id.Value);
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
            _Objeto_configuracao_Service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_configuracao_Service.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            //List<Objeto_configuracao> Objeto_configuracao = _Objeto_configuracao_Service.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Objeto_configuracao Objeto_configuracao)
        {
            if (id != Objeto_configuracao.sky_objeto_configuracao)
            {
                return BadRequest();
            }
            try
            {
                _Objeto_configuracao_Service.Update(Objeto_configuracao);
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
