using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieApplication.Controllers
{
    
    public class HomeController : Controller
    {
        //instance of the "dataLayer" class is created for use
        DataLayer data = new DataLayer();

        //The main page of the web app is returned through this method
        public ActionResult ViewMovies()
        {
            ViewBag.Message = "List of Current Movies";

            return View();
        }

        //The add movie page of the web app is returned through this method
        public ActionResult AddMovie()
        {
            return View();
        }

        //The update movie page of the web is returned through this method
        public ActionResult UpdateMovie()
        {

            return View();
        }

        //Calls the GetMovieList() method from the "datalayer" class to retreive the movie data
        [HttpGet]
        [Route("Movie/GetMovieList")]
        public JsonResult GetMovieList()
        {
            return data.GetMovieList();
        }

        //Calls the GetMovieList() method from the "datalayer" class to create the given entry
        [HttpPost]
        [Route("Movie/Create")]
        public int Create(Movy Movie)
        {
            return data.CreateMovie(Movie);
        }

        //Calls the GetMovieList() method from the "datalayer" class to edit the given entry
        [Route("Movie/Edit")]
        public int Edit(Movy Movie)
        {
            return data.EditMovie(Movie);
        }

        //Calls the GetMovieList() method from the "datalayer" class to delete the given entry
        [Route("Movie/Delete/{id}")]
        public int Delete(int id)
        {
            return data.DeleteMovie(id);
        }

    }
}