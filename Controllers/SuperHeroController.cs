using Microsoft.AspNetCore.Mvc;

using SuperHeroAPI.Model;

namespace SuperHeroAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private static List<SupeHero> heroes = new List<SupeHero>
    {
            new SupeHero {
                Id = 1,
                Name = "Superman",
                FirstName = "Kal-El",
                LastName = string.Empty,
                Place = "Krypton"
            },
            new SupeHero {
                Id = 2,
                Name = "Iron-man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Long Island"
            },
    };

    [HttpGet]
    public async Task<ActionResult<List<SupeHero>>> Get()
    {
        return Ok(heroes);
    }

    [HttpPost]
    public async Task<ActionResult<List<SupeHero>>> AddHero(SupeHero hero)
    {
        heroes.Add(hero);
        return Ok(heroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SupeHero>> GetSingle(int id)
    {
        var heroe = heroes.Find(x => x.Id == id);
        if (heroe == null)
        {
            return BadRequest("hero does not exist");
        }
        return Ok(heroe);
    }

    [HttpPut("{newHero}")]
    public async Task<ActionResult<SupeHero>> Update(SupeHero newHero)
    {
        var heroe = heroes.Find(h => h.Id == newHero.Id);
        if (heroe == null)
        {
            return BadRequest("hero does not exist");
        }

        heroe.Name = newHero.Name;
        heroe.FirstName = newHero.FirstName;
        heroe.LastName = newHero.LastName;
        heroe.Place = newHero.Place;

        return Ok(heroe);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<SupeHero>> Delete(int id)
    {
        var heroe = heroes.Find(x => x.Id == id);
        if (heroe == null)
        {
            return BadRequest("hero does not exist");
        }

        heroes.Remove(heroe);
        return Ok(heroes);
    }
}
