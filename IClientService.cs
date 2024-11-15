using ProjetFileRouge.Models;

namespace ProjetFileRouge.Services;

public interface IClientService{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client> Create(Client client);
}