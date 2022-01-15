using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Objeto_Service
    {
        private readonly Metadados.Data.MetadadosContext _context;  

        public Objeto_Service(MetadadosContext context)
        {
            _context = context;
        }
        public List<Objeto> FindAll()
        {
            return _context.Objeto.ToList();
        }
        public void Insert(Objeto obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Objeto FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Objeto.FirstOrDefault(obj => obj.sky_objeto == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Objeto.Find(id);
            _context.Objeto.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Objeto obj)
        {
            if (!_context.Objeto.Any(x => x.sky_objeto == obj.sky_objeto))
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
