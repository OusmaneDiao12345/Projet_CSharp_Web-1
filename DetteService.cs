using ProjetFileRouge.Data;
using ProjetFileRouge.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjetFileRouge.Services.Impl
{
    public class DetteService : IDetteService
    {
        private readonly ApplicationDbContext _context;

        public DetteService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Dette> Create(Dette dette)
        {
            _context.Dettes.Add(dette);
            await _context.SaveChangesAsync();
            return dette;
        }

        public async Task<IEnumerable<Dette>> GetDettesAsync()
        {
            return await _context.Dettes.ToListAsync();
        }

        public async Task<IEnumerable<Dette>> GetDettesClientAsync(int clientId)
        {
            return await _context.Dettes
                .Where(dette => dette.ClientId == clientId)
                .ToListAsync();
        }
    }
}