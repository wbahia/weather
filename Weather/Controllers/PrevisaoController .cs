using System;
using System.Web.Mvc;
using Weather.BLL.Manager;

namespace Weather.Controllers
{
    public class PrevisaoController : Controller
    {
        public JsonResult ObterPrevisao(int idAPI)
        {
            try
            {
                var listaPrevisao = new PrevisaoManager().ObterPrevisao(idAPI);
                return Json(new { Lista = listaPrevisao }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

    }


}