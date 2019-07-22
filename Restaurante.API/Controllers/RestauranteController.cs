using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain;
using Restaurante.Repository;

namespace Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteRepository _repo;
        public RestauranteController(IRestauranteRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllRestaurantesAsysnc();
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpGet("{RestauranteId}")]
        public async Task<IActionResult> Get(int RestauranteId)
        {
            try
            {
                var result = await _repo.GetAllRestauranteAsysncById(RestauranteId);
                
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
                var result = await _repo.GetAllRestaurantesAsysncByNome(nome);
                
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Restaurantes model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/restaurantes/{model.Id}", model);

                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }  


        [HttpPut("{RestauranteId}")]
        public async Task<IActionResult> Put(int RestauranteId, Restaurantes model)
        {
            try
            {
                var restaurantes = await _repo.GetAllRestauranteAsysncById(RestauranteId);
                if(restaurantes == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/restaurantes/{model.Id}", model);

                }
                
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();
        }  

       [HttpDelete("{RestauranteId}")]
        public async Task<IActionResult> Delete(int RestauranteId)
        {
            try
            {
                var restaurantes = await _repo.GetAllRestauranteAsysncById(RestauranteId);
                if(restaurantes == null) return NotFound();
                
                _repo.Delete(restaurantes);

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