using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practic5Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practic5Back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private List<AppModel> appModels = new List<AppModel>() {
                new AppModel() { Id = 1, AppName = "Adobe Illustrator"},
                new AppModel() { Id = 2, AppName = "Adobe Photoshop"},
                new AppModel() { Id = 2, AppName = "Adobe InDesign"},
                new AppModel() { Id = 2, AppName = "Canva"},
                new AppModel() { Id = 2, AppName = "Adobe Dreamweaver"},
                new AppModel() { Id = 2, AppName = "SVG-edit"},
                new AppModel() { Id = 2, AppName = "Xara Designer Pro"},
                new AppModel() { Id = 2, AppName = "Onshape"},
                new AppModel() { Id = 2, AppName = "Autodesk 3ds Max"},
                new AppModel() { Id = 2, AppName = "Easelly"},
                new AppModel() { Id = 1, AppName = "PhotoScape"},
                new AppModel() { Id = 2, AppName = "Gravit Designer"},
                new AppModel() { Id = 2, AppName = "PhotoScape"},
                new AppModel() { Id = 2, AppName = "Gravit Designer"},
                new AppModel() { Id = 2, AppName = "Venngage"},
                new AppModel() { Id = 2, AppName = "Photoshop Elements"},
                new AppModel() { Id = 2, AppName = "Piktochart"},
                new AppModel() { Id = 2, AppName = "Corel PaintShop Pro"},
                new AppModel() { Id = 2, AppName = "Autodesk SketchBook"},
                new AppModel() { Id = 2, AppName = "Inkscape"},
            };
        public SearchController() { }

        [HttpGet]
        [EnableCors("SearchCors")]
        public JsonResult SendSearchData(string searchString)
        {
            var returnApps = new List<AppModel>();
            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var app in appModels)
                {
                    if (app.AppName.Length >= searchString.Length)
                    {
                        if (app.AppName.Substring(0, searchString.Length).ToLower() == searchString.ToLower())
                        {
                            returnApps.Add(app);
                        }
                    }
                }
            }
            else
            {
                returnApps = appModels;
            }
            
            return new JsonResult(returnApps);
        }
    }
}
