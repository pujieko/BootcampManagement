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
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View(LoadEmployee());
        }

        public JsonResult LoadEmployee()
        {
            IEnumerable<EmployeeVM> employeeVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeeVM>>();
                readTask.Wait();
                employeeVM = readTask.Result;
            }
            else
            {
                employeeVM = Enumerable.Empty<EmployeeVM>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return Json(employeeVM, JsonRequestBehavior.AllowGet);
        }

        public void InsertOrUpdate(EmployeeVM employeeVM)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var myContent = JsonConvert.SerializeObject(employeeVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            if (employeeVM.Id.Equals(0))
            {
                var result = client.PostAsync("Employees", byteContent).Result;
            }
            else
            {
                var result = client.PutAsync("Employees/" + employeeVM.Id, byteContent).Result;
            }
        }

        public JsonResult GetById(int id)
        {
            EmployeeVM employeeVM = null;
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var responseTask = client.GetAsync("Employees/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmployeeVM>();
                readTask.Wait();
                employeeVM = readTask.Result;
            }
            else
            {
                // try to find something
            }
            return Json(employeeVM, JsonRequestBehavior.AllowGet);
        }

        public void Delete(int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:12280/api/")
            };
            var result = client.DeleteAsync("Employees/" + id).Result;
        }
    }
}