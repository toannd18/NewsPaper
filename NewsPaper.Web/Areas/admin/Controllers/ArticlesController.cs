using AutoMapper;
using NewsPaper.Data.Data;
using NewsPaper.Service.AutoMapper;
using NewsPaper.Service.Services;
using NewsPaper.Service.ViewModels;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsPaper.Web.Areas.admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly NewsArticleService _newsArticleService = new NewsArticleService();
        private Mapper _mapper = new Mapper(AutoMapperConfig.RegisterMappings());
        private readonly NewsCategorieService _newsCategorieService = new NewsCategorieService();

        // GET: admin/Articles

       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetPagingList(int? draw, int? length, int start, string search)
        {
            if (!string.IsNullOrEmpty(Request.Form["search[value]"]))
            {
                search = Request.Form["search[value]"];
            }
            int record = length ?? 10;
            string oderId = Request.Form["order[0][column]"];
            string oderDir = Request.Form["order[0][dir]"];

            start = start * record;
            var dataTables = await _newsArticleService.GetPagingList(record, start, search, oderId, oderDir);

            return Json(new { draw = draw, recordsTotal = dataTables.TotalRecords, recordsFiltered = dataTables.FilterRecord, data = dataTables.Data });
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            NewsArticleModel model = new NewsArticleModel();
            if (id > 0)
            {
                var tbl = await _newsArticleService.GetById(id.Value);
                if (tbl == null)
                {
                    return HttpNotFound();
                }
                model = _mapper.Map<NewsArticleModel>(tbl);
            }
            model.NewsCategories = await _newsCategorieService.GetListAsyn();
            ViewBag.Categories = new MultiSelectList(model.NewsCategories, "Id", "Name", new[] { 9, 10 });
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(NewsArticleModel model)
        {
            if (ModelState.IsValid)
            {
                NewsArticles tbl = new NewsArticles();
                if (model.Id > 0)
                {
                    tbl = await _newsArticleService.GetById(model.Id);
              
                    if (tbl is null)
                    {
                        return HttpNotFound();
                    }
                }
                tbl = _mapper.Map<NewsArticleModel, NewsArticles>(model, tbl);
                await (model.Id > 0 ? _newsArticleService.UpdateAsyn(tbl) : _newsArticleService.AddAsyn(tbl));
                return RedirectToAction("Index");
            }
            model.NewsCategories = await _newsCategorieService.GetListAsyn();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _newsArticleService.DeleteAsyn(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}