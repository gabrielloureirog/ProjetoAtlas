using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoAlans_API.Data;
using ProjetoAlans_API.models;

namespace ProjetoAlans_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {

        private readonly IRespository _repo;
        public FuncionarioController(IRespository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get() {
            
            try
            {
                var result = await _repo.GetAllFuncionarioAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarioIdAsync(int id) {
            
            try
            {
                var result = await _repo.GetFuncionarioIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");                
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model) {
            
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");                
            }

            return BadRequest();
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> put(int id, Funcionario model) {
            
            try
            {
                var result = await _repo.GetFuncionarioIdAsync(id);
                
                if(result == null)
                {
                    return NotFound("Aluno não encontrato");
                }

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");                
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id) {
            
            try
            {
                var result = await _repo.GetFuncionarioIdAsync(id);
                
                if(result == null)
                {
                    return NotFound("Aluno não encontrato");
                }

                _repo.Delete(result);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message = "Deletado"});
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");                
            }

            return BadRequest();
        }
    }
}