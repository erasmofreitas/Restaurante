using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;

namespace Restaurante.Repository
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly RestauranteContext _context;
        public RestauranteRepository(RestauranteContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
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
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }


        //PRATOS
        public async Task<Pratos[]> GetAllPratosAsysnc(bool includeRestaurante = false)
        {
            IQueryable<Pratos> query = _context.Pratos;
               // .Include(c => c.Restaurante);

            // if (includeRestaurante){
            //     query = query
            //         .Include(re => re.Restaurante)
            //         .ThenInclude(r => r.RestauranteNome);
            // }

            query = query.OrderByDescending(c => c.DataCadastro);
            return await query.ToArrayAsync();
        }
        public async Task<Pratos[]> GetAllPratosAsysncByNome(string nome, bool includeRestaurante)
        {
            IQueryable<Pratos> query = _context.Pratos
                .Include(c => c.Restaurante);

            if (includeRestaurante){
                query = query
                    .Include(re => re.Restaurante)
                    .ThenInclude(r => r.RestauranteNome);
            }

            query = query.OrderByDescending(c => c.DataCadastro)
                            .Where(r => r.PratoNome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Pratos> GetAllPratosAsysncById(int PratoId, bool includeRestaurante)
        {
            IQueryable<Pratos> query = _context.Pratos
                .Include(c => c.Restaurante);

            if (includeRestaurante){
                query = query
                    .Include(re => re.Restaurante)
                    .ThenInclude(r => r.RestauranteNome);
            }

            query = query.OrderByDescending(c => c.DataCadastro)
                            .Where(c => c.Id == PratoId);
                            
            return await query.FirstOrDefaultAsync();
        }



        //RESTAURANTES


        public async Task<Restaurantes[]> GetAllRestaurantesAsysnc()
        {
            IQueryable<Restaurantes> query = _context.Restaurantes;
               // .Include(c => c.Restaurante);

            // if (includeRestaurante){
            //     query = query
            //         .Include(re => re.Restaurante)
            //         .ThenInclude(r => r.RestauranteNome);
            // }

            query = query.OrderByDescending(c => c.DataCadastro);
            return await query.ToArrayAsync();
        }

        public async Task<Restaurantes[]> GetAllRestaurantesAsysncByNome(string nome)
        {
            IQueryable<Restaurantes> query = _context.Restaurantes;

            query = query.OrderBy(r => r.RestauranteNome)
                            .Where(r => r.RestauranteNome.ToLower().Contains(nome.ToLower()));
                            
            return await query.ToArrayAsync();
        }

        public async Task<Restaurantes> GetAllRestauranteAsysncById(int RestauranteId)
        {
            IQueryable<Restaurantes> query = _context.Restaurantes;

            query = query.OrderByDescending(c => c.DataCadastro)
                            .Where(c => c.Id == RestauranteId);
                            
            return await query.FirstOrDefaultAsync();
        }        

    }
}