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
    public class RoomsController : Controller
    {
        // GET: Rooms
        public ActionResult Index()
        {
            return View(LoadRoom());
        }

        public JsonResult LoadRoom()
        {
            IEnumerable<RoomVM> roomVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Rooms");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<RoomVM>>();
                readTask.Wait();
                roomVM = readTask.Result;
            }
            else
            {
                roomVM = Enumerable.Empty<RoomVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(roomVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(RoomVM roomVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(roomVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (roomVM.Id.Equals(0))
            {
                var result = client.PostAsync("Rooms", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Rooms/" + roomVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(string id)
        {
            RoomVM roomVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Rooms/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<RoomVM>();
                readTask.Wait();
                roomVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(roomVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(string id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Rooms/" + id).Result;
        }
    }
}