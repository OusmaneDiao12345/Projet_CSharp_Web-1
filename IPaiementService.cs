using ProjetFileRouge.Models;

namespace ProjetFileRouge.Services;

public interface IPaiementService{
    Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId);
}