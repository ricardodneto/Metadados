using CadastroMaterial.Models.Services;
using CadastroMaterial.Models.Services.Exceptions;
using Metadados.Data;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Models.Services
{
    public class Mapeamento_Services
    {
        private readonly Metadados.Data.MetadadosContext _context;

        public Mapeamento_Services(MetadadosContext context)
        {
            _context = context;
        }
        public List<Mapeamento> FindAll()
        {
            return _context.Mapeamento.ToList();
        }
        public void Insert(Mapeamento obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Mapeamento FindById(int id)
        {
            // Buscar por ID e verificar se ID é igual ao OBJ;
            return _context.Mapeamento.FirstOrDefault(obj => obj.sky_mapeamento == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Mapeamento.Find(id);
            _context.Mapeamento.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Mapeamento obj)
        {
            if (!_context.Mapeamento.Any(x => x.sky_mapeamento == obj.sky_mapeamento))
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
