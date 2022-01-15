using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models
{
    public class Objeto_localizacao_Services
    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Objeto_localizacao_Services(MetadadosContext context)
        {
            _context = context;
        }
        public List<Objeto_localizacao> FindAll()
        {
            return _context.Objeto_localizacao.ToList();
        }
        public void Insert(Objeto_localizacao obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Objeto_localizacao FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Objeto_localizacao.FirstOrDefault(obj => obj.sky_localizacao_tipo == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Objeto_localizacao.Find(id);
            _context.Objeto_localizacao.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Objeto_localizacao obj)
        {
            if (!_context.Objeto_localizacao.Any(x => x.sky_localizacao_tipo == obj.sky_localizacao_tipo))
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
