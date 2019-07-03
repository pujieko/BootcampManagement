using BootcampManagement.Client.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BootcampManagement.Client.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View(LoadClass());
        }

        public JsonResult LoadClass()
        {
            IEnumerable<ClassVM> classVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Classes");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<ClassVM>>();
                readTask.Wait();
                classVM = readTask.Result;
            }
            else
            {
                classVM = Enumerable.Empty<ClassVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(classVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(ClassVM classVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(classVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (classVM.Id.Equals(0))
            {
                var result = client.PostAsync("Classes", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Classes/" + classVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            ClassVM classVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Classes/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ClassVM>();
                readTask.Wait();
                classVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(classVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Classes/" + id).Result;
        }
    }
}