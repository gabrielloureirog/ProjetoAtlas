using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAlans_API.models;

namespace ProjetoAlans_API.Data
{
    public class Repository : IRespository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        //Salvar mudanças e enviar para o BD
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //Método implementado para pegar todos os funcionarios cadastrados
        public async Task<Funcionario[]> GetAllFuncionarioAsync(bool Funcionarios)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking().OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }

        //Método implementado para pegar um funcionario usando o nome
        public async Task<Funcionario> GetFuncionarioIdAsync(int id)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            query = query.AsNoTracking()
                        .Where(funcionario => funcionario.id == id);

            return await query.FirstOrDefaultAsync();

        }
    }
}