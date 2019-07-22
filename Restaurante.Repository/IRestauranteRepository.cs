using System.Threading.Tasks;
using Restaurante.Domain;

namespace Restaurante.Repository
{
    public interface IRestauranteRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        //PRATOS
        Task<Pratos[]> GetAllPratosAsysncByNome(string nome, bool includeRestaurante);
        Task<Pratos[]> GetAllPratosAsysnc(bool includeRestaurante);
        Task<Pratos> GetAllPratosAsysncById(int PratoId, bool includeRestaurante);

        //RESTAURANTE
        Task<Restaurantes[]> GetAllRestaurantesAsysnc();
        Task<Restaurantes[]> GetAllRestaurantesAsysncByNome(string nome);
        Task<Restaurantes> GetAllRestauranteAsysncById(int RestauranteId);

    }
}