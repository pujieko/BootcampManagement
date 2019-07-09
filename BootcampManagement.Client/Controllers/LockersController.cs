using BootcampManagement.Client.ViewModels;
using BootcampManagement.Data.Model;
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
    public class LockersController : Controller
    {
        // GET: Lockers
        public ActionResult Index()
        {
            return View(LoadLocker());
        }

        public JsonResult LoadLocker()
        {
            IEnumerable<Locker> locker = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Lockers");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Locker>>();
                readTask.Wait();
                locker = readTask.Result;
            }
            else
            {
                locker = Enumerable.Empty<Locker>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(locker, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(LockerVM lockerVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(lockerVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (string.IsNullOrEmpty(lockerVM.Id))
            {
                var result = client.PostAsync("Lockers", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Lockers/" + lockerVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            LockerVM lockerVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Lockers/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<LockerVM>();
                readTask.Wait();
                lockerVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(lockerVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Lockers/" + id).Result;
        }
    }
}