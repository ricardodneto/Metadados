using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Pipeline_Services
    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Pipeline_Services(MetadadosContext context)
        {
            _context = context;
        }
        public List<Pipeline> FindAll()
        {
            return _context.Pipeline.ToList();
        }
        public void Insert(Pipeline obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Pipeline FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Pipeline.FirstOrDefault(obj => obj.sky_pipeline == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Pipeline.Find(id);
            _context.Pipeline.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Pipeline obj)
        {
            if (!_context.Pipeline.Any(x => x.sky_pipeline == obj.sky_pipeline))
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
