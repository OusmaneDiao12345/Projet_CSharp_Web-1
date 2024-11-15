using ProjetFileRouge.Models;
using System.Threading.Tasks;

namespace ProjetFileRouge.Services
{
    public interface IDetteService
    {
        Task<IEnumerable<Dette>> GetDettesAsync(); 
        Task<IEnumerable<Dette>> GetDettesClientAsync(int clientId);
        Task<Dette> Create(Dette dette);
    }
}