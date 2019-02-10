using PagedList;
using RSSFeedWeb.Models;
using RSSFeedWeb.Serices;
using System.Web.Mvc;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        Service service;


        public HomeController()
        {
            service = new Service();
        }



        public ActionResult PostForm(int? page, int? id, int? rb)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ItemViewModel ivm = GetViewModel(id, rb);
            ViewBag.Model = ivm;

            return View(ivm.Items.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AjaxForm()
        {
            ViewBag.Channels = service.GetChannels(); ;
            return View();
        }

        public ActionResult AjaxFilter(int? page, int? id, int? rb)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            ItemViewModel ivm = GetViewModel(id, rb);
            ViewBag.Model = ivm;

            return PartialView(ivm.Items.ToPagedList(pageNumber, pageSize));
        }



        ItemViewModel GetViewModel(int? channelId, int? sort)
        {
            ItemViewModel ivm = new ItemViewModel
            {
                Items = service.GetItems(channelId),
                Channels = service.GetChannels(),
                Filter = channelId,
                Sort = sort
            };

            ivm.Items = service.Sort(ivm.Items, sort);
            return ivm;
        }
    }
}