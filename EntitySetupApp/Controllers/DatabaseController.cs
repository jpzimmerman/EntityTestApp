using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EntitySetupApp.Models;

namespace EntitySetupApp.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            
            //DevBuildMoviesEntities1 ORM = new DevBuildMoviesEntities1();
            //ViewBag.MovieList = ORM.Movies.ToList();
            
            return View();
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        public ActionResult SaveNewMovie(Movy ourMovie, Director ourDirector)
        {
            //DevBuildMoviesEntities ORM = new DevBuildMoviesEntities();
            if (ourMovie != null)
            {
                //List<Movy> movieMatches = ORM.Movies.Where(m => //m.MovieTitle == ourMovie.MovieTitle && m.Year == //ourMovie.Year).ToList();

                //if (movieMatches.Count == 0)
                {
                    //ORM.Movies.Add(ourMovie);
                    //ORM.Entry(ourMovie).State = EntityState.Added;
                    //ORM.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}