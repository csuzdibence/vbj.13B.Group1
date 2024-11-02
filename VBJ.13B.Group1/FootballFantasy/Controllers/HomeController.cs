using FootballFantasy.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballFantasy.Controllers
{
    public class HomeController : Controller
    {
        public static List<Team> teams = new List<Team>();

        public IActionResult Index()
        {
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            Team team = teams.FirstOrDefault(x => x.ID == id);
            if (team != null)
            {
                teams.Remove(team);
            }

            return RedirectToAction("Index");
        }

        public IActionResult CreateTeam(Team team)
        {
            if (teams.Any())
            {
                team.ID = teams.Last().ID + 1;
            }
            else
            {
                team.ID = 1;
            }

            teams.Add(team);
            return RedirectToAction("Index");
        }
    }
}
