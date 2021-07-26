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
                new AppModel() { Id = 3, AppName = "Adobe InDesign"},
                new AppModel() { Id = 4, AppName = "Canva"},
                new AppModel() { Id = 5, AppName = "Adobe Dreamweaver"},
                new AppModel() { Id = 6, AppName = "SVG-edit"},
                new AppModel() { Id = 7, AppName = "Xara Designer Pro"},
                new AppModel() { Id = 8, AppName = "Onshape"},
                new AppModel() { Id = 9, AppName = "Autodesk 3ds Max"},
                new AppModel() { Id = 10, AppName = "Easelly"},
                new AppModel() { Id = 11, AppName = "PhotoScape"},
                new AppModel() { Id = 12, AppName = "Gravit Designer"},
                new AppModel() { Id = 13, AppName = "PhotoScape"},
                new AppModel() { Id = 14, AppName = "Gravit Designer"},
                new AppModel() { Id = 15, AppName = "Venngage"},
                new AppModel() { Id = 16, AppName = "Photoshop Elements"},
                new AppModel() { Id = 17, AppName = "Piktochart"},
                new AppModel() { Id = 18, AppName = "Corel PaintShop Pro"},
                new AppModel() { Id = 19, AppName = "Autodesk SketchBook"},
                new AppModel() { Id = 20, AppName = "Inkscape"},
            };
        public SearchController() { }

        [HttpGet]
        [EnableCors("SearchCors")]
        public JsonResult SendSearchData(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString)) { return new JsonResult(appModels.Where(x => x.AppName.Substring(0, searchString.Length).ToLower() == searchString.ToLower()).ToList()); }
            else { return new JsonResult(appModels); }
        }
    }
}
