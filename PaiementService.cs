using ProjetFileRouge.Data;
using ProjetFileRouge.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetFileRouge.Services.Impl;

public class PaiementService : IPaiementService
{
    private readonly ApplicationDbContext _context;

    public PaiementService(ApplicationDbContext context)
    {
        this._context = context;
    }
  
    public async Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId)
    {
        return await _context.Paiements.Where(paiement => paiement.DetteId == detteId).ToListAsync();
    }
}