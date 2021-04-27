using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebService.UI.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebService.UI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment web;

        public ImageController(IWebHostEnvironment web)
        {
            this.web = web;
        }

        [HttpGet]
        public IActionResult Index(ImageEditorViewModel model)
        {
            
            model.Images = System.IO.Directory.GetFiles(web.WebRootPath,"*.*",SearchOption.AllDirectories).Where(c=>c.EndsWith(".jpg") || c.EndsWith(".bmp") || c.EndsWith(".png")).ToList();

            var Count = model.Images.Count;
            var TotalPage = Count / (double)model.CountOnpage;
            model.TotalPage = (short)Math.Ceiling(TotalPage);

            model.Images = model.Images.Select(c =>  new string(c.Substring(c.IndexOf("wwwroot")).Replace("\\", "/")).Replace("wwwroot","")).OrderBy(c=>c).Skip((model.CurrentPage - 1) * model.CurrentPage).Take(model.CountOnpage).ToList();

            return View(model);
        }


       
        public IActionResult Delete(string FileName="")
        {
            var File = web.WebRootPath + "\\" + FileName.Replace("/", "\\");
            System.IO.File.Delete(File);

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(List<IFormFile> Files, string Path="")
        {
          
            foreach (var item in Files)
            {
                if (!System.IO.Directory.Exists(Path)) System.IO.Directory.CreateDirectory(Path);

                using (var file = new FileStream($@"{web.WebRootPath}{Path}\{item.FileName}",FileMode.Create,FileAccess.ReadWrite))
                {
                    
                    item.CopyTo(file);
                    file.Close();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
