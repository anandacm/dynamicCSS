using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using RazorEngine;

using System.Text;

namespace appStore_Tests.Controllers
{
    public class AppResourceController : Controller
    {
        // GET: AppResource
        public ActionResult Index()
        {


            return View();
        }

        public string GetContent(string targetFile)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(targetFile);
                string retval = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                if(retval.Contains(".css"))
                {
                    Response.ContentType = "text/css";
                }
                else
                {
                    Response.ContentType = "application/javascript";
                }
                string f = System.IO.File.ReadAllText(retval);



                return Razor.Parse(f.Replace("@","@@"));

            }
            catch (Exception ex)
            {

            }


            return Razor.Parse("");

        }

    }
}