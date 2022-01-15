using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Objeto_configuracao_Service

    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Objeto_configuracao_Service(MetadadosContext context)
        {
            _context = context;
        }
        public List<Objeto_configuracao> FindAll()
        {
            return _context.Objeto_configuracao.ToList();
        }
        public void Insert(Objeto_configuracao obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Objeto_configuracao FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Objeto_configuracao.FirstOrDefault(obj => obj.sky_objeto_configuracao == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Objeto_configuracao.Find(id);
            _context.Objeto_configuracao.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Objeto_configuracao obj)
        {
            if (!_context.Objeto_configuracao.Any(x => x.sky_objeto_configuracao == obj.sky_objeto_configuracao))
            {
                throw new NotFoundException("Id not found");

            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);

            }
        }
    }
}
