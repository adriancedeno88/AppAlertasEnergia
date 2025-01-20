using AppAlertasEnergia.Data;
using AppAlertasEnergia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAlertasEnergia.Controllers
{
    public class SesionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SesionController> _logger;

        public SesionController(ApplicationDbContext context, ILogger<SesionController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Sesion() => View();


        [HttpPost]
        public async Task<IActionResult> Menu([Bind("email,clave")] Usuario user)
        {
            _logger.LogInformation($"Parámetro 'user': {user.email} .");
            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.email.Equals(user.email));                              
            if(usuario != null)
            {
                if (user.clave.Equals(usuario.clave))
                {
                    if (usuario.estado == 1)
                    {
                        HttpContext.Session.SetString("username", (usuario.nombres + " " + usuario.apellidos));
                        HttpContext.Session.SetString("tipo", (usuario.tipo + ""));
                        
                        return Redirect("Menu");
                    }                    
                }
            }            
            ViewBag.ErrorMessage = "Usuario o contraseña incorrecta.";
            return Redirect("Error");
        }

        public IActionResult Menu()
        {
            var username = HttpContext.Session.GetString("username");
            var tipo = HttpContext.Session.GetString("tipo");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Sesion");
            }
            ViewBag.Username = username;
            ViewBag.Tipo = tipo;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index","Home");
        }
    }
}
