using System.Diagnostics;
using System.Web.Mvc;
using ExceptionFilterMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilterMVC.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        [HandleError]
        public IActionResult Index()
        {
            //int a = 10;   
            //int b = 0;
            //int c = a / b;        // divide by zero exception

            //string a = null;
            //int b = a.Length;       // Null reference exception

            //int[] a = new int[3];
            //a[0] = 1;
            //a[1] = 2;
            //a[2] = 3;
            //a[3] = 4;               //IndexOutOfRangeException

            /*try
            {
                throw new Exception();

            }
            catch (Exception ex)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
            return View();*/

            throw new Exception();
            return View();

        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
