using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Metadados.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Metadados.Controllers
{
    public class ObjetoController : Controller
    {

        private readonly Objeto_Service _ObjetoService;
        private readonly Objeto_localizacao_Services _Objeto_localizacao_Services;
        private readonly Objeto_configuracao_Service _Objeto_configuracao_Services;

        public ObjetoController(Objeto_Service Objeto_Service, Objeto_localizacao_Services Objeto_localizacao_Services, Objeto_configuracao_Service Objeto_configuracao_Service)
        {
            _ObjetoService = Objeto_Service;
            _Objeto_localizacao_Services = Objeto_localizacao_Services;
            _Objeto_configuracao_Services = Objeto_configuracao_Service;

        }

        public IActionResult Index(int pagina =1)
        {
            //var produtos = db.Produtos.OrderBy(p => p.Id)
            //                .ToPagedList(pagina, 10);



            var list = _ObjetoService.FindAll();
               
            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {
            ObjetoViewModel oObjetoViewModel = new ObjetoViewModel();

            // Listas que recebem MODEL
            List<Objeto_localizacao> oListObjeto_localizacao = _Objeto_localizacao_Services.FindAll();
            List<Objeto_configuracao> oListObjeto_configuracao = _Objeto_configuracao_Services.FindAll();
            List<Objeto> oListObjeto = _ObjetoService.FindAll();
            // Testar sem a variavel OList
            oObjetoViewModel.oObjeto_localizacao = oListObjeto_localizacao;
            oObjetoViewModel.oObjeto_configuracao = oListObjeto_configuracao;

            return View(oObjetoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Objeto Objeto)
        {

            ObjetoViewModel oObjetoViewModel = new ObjetoViewModel();
            oObjetoViewModel.Objeto = Objeto;  
            oObjetoViewModel.oObjeto_localizacao = _Objeto_localizacao_Services.FindAll();
            oObjetoViewModel.oObjeto_configuracao = _Objeto_configuracao_Services.FindAll();
            
            if (ModelState.IsValid)
            {
                _ObjetoService.Insert(Objeto);
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
            var obj = _ObjetoService.FindById(id.Value);
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
            _ObjetoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _ObjetoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Objeto> teste = _ObjetoService.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Objeto Objeto)
        {
            if (id != Objeto.sky_objeto)
            {
                return BadRequest();
            }
            try
            {
                _ObjetoService.Update(Objeto);
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
