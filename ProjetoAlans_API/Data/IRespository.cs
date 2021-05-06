using System.Threading.Tasks;
using ProjetoAlans_API.models;

namespace ProjetoAlans_API.Data
{
    public interface IRespository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Pegar todos os Funcionarios
        Task<Funcionario[]> GetAllFuncionarioAsync(bool InFuncionario);
        //Pegar um funcionario pelo Nome
        Task<Funcionario> GetFuncionarioIdAsync(int id);
    }
}