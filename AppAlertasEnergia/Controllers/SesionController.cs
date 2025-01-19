using AppAlertasEnergia.Data;
using AppAlertasEnergia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAlertasEnergia.Controllers
{
    public class SesionController : Controller
    {
        private readonly ApplicationDbContext _context;


        public SesionController(ApplicationDbContext _context)
        {
            _context = _context;
        }

        public IActionResult Login()=>View();
        
           
        [HttpPost]
        public async Task<IActionResult> Login(Usuario model)
        {
            if (ModelState.IsValid) {
                var user = await _context.Usuario.FirstOrDefaultAsync(u =>u.email== model.email && u.clave == model.clave);
                if (user != null) { 
                    var result = await _signInManager.PasswordSignInAsync(user, model.clave,false,false);
                    if (result.Succeeded) { 
                        return RedirectToAction("Login", "Sesion");
                    }
                    ModelState.AddModelError(string.Empty, "Usuario invalido.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                }                    
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
