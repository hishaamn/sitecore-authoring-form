using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Configuration;
using Sitecore.Sites;
using Sitecore.Text;

namespace Sitecore.AuthoringForms.Controllers
{
    public class AuthoringFormController : Controller
    {
        //[HttpGet]
        //public ActionResult SiteCreator()
        //{
        //    var shellSite = SiteContext.GetSite("shell");

        //    using (new SiteContextSwitcher(shellSite))
        //    {
        //        var urlString = new UrlString(UIUtil.GetUri("control:PowerShellRunner"));
        //        urlString.Append("scriptId", "{B1F5FDB5-AD16-4269-A2FA-E2610C5670B8}");
        //        urlString.Append("scriptDb", "master");

        //        return new JsonResult { Data = urlString.ToString(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }
        //}

        [HttpGet]
        public ActionResult SiteCreator()
        {
            var formItems = Factory.GetDatabase("master").GetItem("/sitecore/content/Home").Children.ToList();
            
            var formList = new List<FormModel>();

            foreach (var formItem in formItems)
            {
                formList.Add(new FormModel
                {
                    FormId = formItem.ID.ToString(),
                    FormName = formItem.Name
                });
            }

            return new JsonResult { Data = formList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

    public class FormModel
    {
        public string FormName { get; set; }

        public string FormId { get; set; }
    }
}