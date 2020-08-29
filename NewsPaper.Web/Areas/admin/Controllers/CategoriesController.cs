using AutoMapper;
using NewsPaper.Data.Data;
using NewsPaper.Service.AutoMapper;
using NewsPaper.Service.Services;
using NewsPaper.Service.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NewsPaper.Web.Areas.admin.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly NewsCategorieService _newsCategorie = new NewsCategorieService();
        private Mapper _mapper = new Mapper(AutoMapperConfig.RegisterMappings());

        // GET: admin/Categories
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
            var dataTables = await _newsCategorie.GetPagingList(record, start, search, oderId, oderDir);
            return Json(new { draw = draw, recordsTotal = dataTables.TotalRecords, recordsFiltered = dataTables.FilterRecord, data = dataTables.Data });
        }

        [HttpGet]
        public async Task<ActionResult> Get(int? id = 0)
        {
            var model = new NewsCategorieModel() { Id = id.Value };
            // if (id is null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (id > 0)
            {
                var tbl = await _newsCategorie.GetById(id.Value);

                if (tbl is null) return HttpNotFound();

                model = _mapper.Map<NewsCategorieModel>(tbl);
            }
            return PartialView("_GetCategory", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(NewsCategorieModel model)
        {
            if (ModelState.IsValid)
            {
                var tbl = new NewsCategories();
                if (model.Id > 0)
                {
                    tbl = await _newsCategorie.GetById(model.Id);
                    if (tbl is null)
                    {
                        return HttpNotFound();
                    }
                }
                
                tbl = _mapper.Map<NewsCategorieModel,NewsCategories>(model,tbl);

                await (tbl.Id > 0 ? _newsCategorie.UpdateAsyn(tbl) : _newsCategorie.AddAsyn(tbl));
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _newsCategorie.DeleteAsyn(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}