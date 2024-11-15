using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projet_csharp.Models;
using ProjetFileRouge.Models;
using ProjetFileRouge.Services;

namespace ProjetFileRouge.Controllers
{
    public class DetteController : Controller
    {
        private readonly ILogger<DetteController> _logger;
        private readonly IDetteService _detteService;

        public DetteController(ILogger<DetteController> logger, IDetteService detteService)
        {
            _logger = logger;
            _detteService = detteService;
        }

        // Action pour afficher la liste des dettes
        public async Task<IActionResult> Index()
        {
            // Récupérer les dettes du service
            var dettes = await _detteService.GetDettesAsync(); // Remplacez par la bonne méthode pour récupérer toutes les dettes
            return View(dettes); 
        }

        // Action pour afficher les dettes d'un client spécifique
        public async Task<IActionResult> DetteClient(int clientId)
        {
            var dettes = await _detteService.GetDettesClientAsync(clientId);
            return View(dettes);
        }

        // Action pour afficher le formulaire de création de dette
       public IActionResult Create()
        {
           return View(); // Assurez-vous de renvoyer la vue "Create"
        }

        // Action pour traiter le formulaire de création de dette
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dette dette)
        {
            if (ModelState.IsValid)
            {
                await _detteService.Create(dette);
                return RedirectToAction(nameof(Index)); // Redirige vers la page de la liste des dettes
            }
            return View(dette);
        }

        // Action pour gérer les erreurs
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}