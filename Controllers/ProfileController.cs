using ImgInsert.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImgInsert.Controllers
{
    public class ProfileController : Controller
    {
        MvcdbContext db;
        IWebHostEnvironment env;
        public ProfileController(IWebHostEnvironment env)
        {
            db = new MvcdbContext();
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Index(ProDuct p, IFormFile[] Photos)
        {
            String folder = env.WebRootPath + "/Products/" + p.Productname;
            if(Photos.Length == 0)
            {
                ViewBag.msg = "Please select at least one image";
                return View();
            }
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string imglist = "";
            int i = 1;
            foreach (IFormFile f in Photos)
            {
                string imgname = i + Path.GetExtension(f.FileName);
                string imgPath = folder + "/" + imgname;
                FileStream fs = new FileStream(imgPath, FileMode.Create);
                f.CopyTo(fs);
                imglist += "," + imgname;
                i++;
                fs.Close();
            }
            p.Images = imglist.Length > 0 ? imglist.Substring(1) : "";
            db.ProDucts.Add(p);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.msg = "Product Added Successfully";
            return View();
        }
        public IActionResult ViewProducts()
        {
            var data = db.ProDucts.ToList();
            return View(data);
        }
    }
}
