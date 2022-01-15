using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Objeto_tipo_Services
    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Objeto_tipo_Services(MetadadosContext context)
        {
            _context = context;
        }
        public List<Objeto_tipo> FindAll()
        {
            return _context.Objeto_tipo.ToList();
        }
        public void Insert(Objeto_tipo obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Objeto_tipo FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Objeto_tipo.FirstOrDefault(obj => obj.sky_objeto_tipo == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Objeto_tipo.Find(id);
            _context.Objeto_tipo.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Objeto_tipo obj)
        {
            if (!_context.Objeto_tipo.Any(x => x.sky_objeto_tipo == obj.sky_objeto_tipo))
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
