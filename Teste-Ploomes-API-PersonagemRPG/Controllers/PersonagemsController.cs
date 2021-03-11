using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Teste_Ploomes_API_PersonagemRPG.Data;
using Teste_Ploomes_API_PersonagemRPG.Models;

namespace Teste_Ploomes_API_PersonagemRPG.Controllers
{
    public class PersonagemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonagemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personagem.ToListAsync());
        }

        // GET: Personagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        // GET: Personagems/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: Personagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personagem personagem)
        {
            personagem.User = User.Identity.Name;

            personagem.Vida = personagem.Vitalidade * 2;
            personagem.Mana = personagem.Inteligencia * 2;

            personagem.TotalAtributos = personagem.Forca + personagem.Agilidade + personagem.Inteligencia + personagem.Carisma + personagem.Vitalidade;

            if (ModelState.IsValid && personagem.TotalAtributos <= 30 && personagem.TotalAtributos >= 0)
            {
                _context.Add(personagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        [Authorize]
        // GET: Personagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var personagem = await _context.Personagem.FindAsync(id);

            if(personagem.User != User.Identity.Name)
            {
                return View();
            }
            if (personagem == null)
            {
                return NotFound();
            }
            return View(personagem);
        }

        [Authorize]
        // POST: Personagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Nome,Aparencia,Historia,Vida,Mana,Forca,Agilidade,Inteligencia,Vitalidade,Carisma,TotalAtributos")] Personagem personagem)
        {
            if (id != personagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonagemExists(personagem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personagem);
        }

        [Authorize]
        // GET: Personagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personagem = await _context.Personagem
                .FirstOrDefaultAsync(m => m.Id == id);

            if (personagem.User != User.Identity.Name)
            {
                return View();
            }
            if (personagem == null)
            {
                return NotFound();
            }

            return View(personagem);
        }

        [Authorize]
        // POST: Personagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personagem = await _context.Personagem.FindAsync(id);
            _context.Personagem.Remove(personagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonagemExists(int id)
        {
            return _context.Personagem.Any(e => e.Id == id);
        }
    }
}
