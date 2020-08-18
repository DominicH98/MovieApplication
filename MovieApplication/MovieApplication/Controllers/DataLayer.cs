using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    public class DataLayer
    {
        //An instance of the database is created for use throughout the class
        private MovieDatabaseEntities db = new MovieDatabaseEntities();

        //GetMovieList returns the list of all movies in the database in the form of Json
        public JsonResult GetMovieList()
        {
            var data = db.Movies.ToList();
            return new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //This method creates a movie with the given information 
        public int CreateMovie([Microsoft.AspNetCore.Mvc.FromBody] Movy Movie)
        { 
            db.Movies.Add(Movie);
            db.SaveChanges();

            return 1;

        }

        //This method edits the movie with the given id  
        public int EditMovie([Microsoft.AspNetCore.Mvc.FromBody] Movy Movie)
        {
            db.Entry(Movie).State = EntityState.Modified;
            db.SaveChanges();

            return 1;
        }

        //This method deletes the movie with the given id    
        public int DeleteMovie(int id)
        {
                Movy movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();

                return 1;
        }
    }
}