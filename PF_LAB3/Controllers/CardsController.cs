using Microsoft.AspNetCore.Mvc;
using PF_LAB3.Models;

namespace PF_LAB3.Controllers
{
    public class CardsController : Controller
    {
        // STATIC LIST: Ito ang magsisilbing "Database" natin pansamantala
        private static List<Card> _cards = new List<Card>
        {
            new Card {
                Id = 1,
                Name = "Accompany",
                Rarity = "Rare",
                CharacterName = "Ging Freecss",
                CharacterImageUrl = "/images/ging.jpg",
                Type = "Spell",
                Description = "Allows the user to travel to a designated location where someone they have met is currently located."
            },
            new Card {
                Id = 2,
                Name = "Binders",
                Rarity = "Common",
                CharacterName = "Gon Freecss",
                CharacterImageUrl = "/images/gon.jpg",
                Type = "Equipment",
                Description = "Temporarily freezes the movements of anyone touched."
            },
            new Card {
                Id = 3,
                Name = "Ruler's Authority",
                Rarity = "Ultra Rare",
                CharacterName = "Razor",
                CharacterImageUrl = "/images/razor.jpg",
                Type = "Spell",
                Description = "A set of powerful, non-tradable cards essential for winning the game."
            }
        };

        // READ (Index - List)
        // Ipinapakita ang lahat ng cards
        public IActionResult Index()
        {
            return View(_cards.OrderBy(c => c.Id).ToList());
        }

        // READ (Details)
        public IActionResult Details(int id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // UPDATE (Edit - GET)
        // Nagpapakita ng form
        public IActionResult Edit(int id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // UPDATE (Edit - POST)
        // Tumatanggap ng form at nag-u-update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Rarity,CharacterName,CharacterImageUrl,Type,Description")] Card updatedCard)
        {
            if (id != updatedCard.Id)
            {
                return NotFound();
            }

            // Walang DbContext validation/logic, diretso na sa update
            if (ModelState.IsValid)
            {
                var existingCard = _cards.FirstOrDefault(c => c.Id == id);
                if (existingCard != null)
                {
                    // Copy properties
                    existingCard.Name = updatedCard.Name;
                    existingCard.Rarity = updatedCard.Rarity;
                    existingCard.CharacterName = updatedCard.CharacterName;
                    existingCard.CharacterImageUrl = updatedCard.CharacterImageUrl;
                    existingCard.Type = updatedCard.Type;
                    existingCard.Description = updatedCard.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updatedCard);
        }

        // DELETE (Delete - GET)
        // Nagpapakita ng confirmation page
        public IActionResult Delete(int id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // DELETE (Delete - POST)
        // Tumatanggap ng confirmation at nagtatanggal
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cardToRemove = _cards.FirstOrDefault(c => c.Id == id);
            if (cardToRemove != null)
            {
                _cards.Remove(cardToRemove);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}   