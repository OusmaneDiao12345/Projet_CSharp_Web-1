using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projet_csharp.Models;
using ProjetFileRouge.Models;
using ProjetFileRouge.Services;


namespace Projet_csharp.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }
    // Home/Index | Routes
    public async Task<IActionResult> Index()
    {
        // Fetch clients from the service
        var clients = await _clientService.GetClientsAsync();
        // Pass the clients to the view
        return View(clients);
    }

    public  IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public  async Task<IActionResult> Create([Bind("Surnom,Telephone,Adresse")] Client client)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"***********************************************{client.Adresse}***********************************************");
            var clientAdded = await _clientService.Create(client);
            // if (clientAdded != null)
            // {
                TempData["Message"] = "Client créé avec succès!";
                return RedirectToAction(nameof(Index));
            // }
        }
        return View(client);
    }
}