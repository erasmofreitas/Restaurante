using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain;
using Restaurante.Repository;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratoController : ControllerBase
    {
        private readonly IRestauranteRepository _repo;
        public PratoController(IRestauranteRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllPratosAsysnc(true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{PratoId}")]
        public async Task<IActionResult> Get(int PratoId)
        {
            try
            {
                var result = await _repo.GetAllPratosAsysncById(PratoId, true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("getByNome/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                var result = await _repo.GetAllPratosAsysncByNome(nome, true);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pratos model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/pratos/{model.Id}", model);

                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }  


        [HttpPut("{PratosId}")]
        public async Task<IActionResult> Put(int PratosId, Pratos model)
        {
            try
            {
                var prato = await _repo.GetAllPratosAsysncById(PratosId, false);
                if(prato == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/pratos/{model.Id}", model);

                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }  

       [HttpDelete("{PratosId}")]
        public async Task<IActionResult> Delete(int PratosId)
        {
            try
            {
                var prato = await _repo.GetAllPratosAsysncById(PratosId, false);
                if(prato == null) return NotFound();
                
                _repo.Delete(prato);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();

                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }                              
    }
}