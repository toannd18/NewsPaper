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
    public class SlidesController : Controller
    {
        private readonly SlideService _slideService;
        private Mapper _mapper;

        public SlidesController()
        {
            _slideService = new SlideService();
            _mapper = new Mapper(AutoMapperConfig.RegisterMappings());
        }

        // GET: admin/Slides
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetPagingList(int? draw, int? length, int start, string search)
        {
            if (!string.IsNullOrEmpty(Request.Form["search[value]"]))
            {
                search = Request.Form["search[value]"];
            }
            int record = length ?? 10;
            string oderId = Request.Form["order[0][column]"];
            string oderDir = Request.Form["order[0][dir]"];

            start = start * record;
            var dataTables = await _slideService.GetPagingList(record, start, search, oderId, oderDir);
            return Json(new { draw = draw, recordsTotal = dataTables.TotalRecords, recordsFiltered = dataTables.FilterRecord, data = dataTables.Data });
        }

        [HttpGet]
        public async Task<ActionResult> Get(int? id = 0)
        {
            var model = new SlideViewModel() { Id = id.Value };
            // if (id is null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (id > 0)
            {
                var tbl = await _slideService.GetById(id.Value);

                if (tbl is null) return HttpNotFound();

                model = _mapper.Map<SlideViewModel>(tbl);
            }
            return View("GetSlide", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(SlideViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tbl = new Slide(0, "Alias", false);
                if (model.Id > 0)
                {
                    tbl = await _slideService.GetById(model.Id);
                    if (tbl is null)
                    {
                        return HttpNotFound();
                    }
                }

                tbl = _mapper.Map<SlideViewModel, Slide>(model, tbl);

                await (tbl.Id > 0 ? _slideService.UpdateAsyn(tbl) : _slideService.AddAsyn(tbl));
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteById(int id)
        {
            await _slideService.DeleteAsyn(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}