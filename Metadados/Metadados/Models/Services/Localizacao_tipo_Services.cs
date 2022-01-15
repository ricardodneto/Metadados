using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Localizacao_tipo_Services
    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Localizacao_tipo_Services(MetadadosContext context)
        {
            _context = context;
        }
        public List<Localizacao_tipo> FindAll()
        {
            return _context.Localizacao_tipo.ToList();
        }
        public void Insert(Localizacao_tipo obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Localizacao_tipo FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Localizacao_tipo.FirstOrDefault(obj => obj.sky_localizacao_tipo == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Localizacao_tipo.Find(id);
            _context.Localizacao_tipo.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Localizacao_tipo obj)
        {
            if (!_context.Localizacao_tipo.Any(x => x.sky_localizacao_tipo == obj.sky_localizacao_tipo))
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
