﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Weather.BLL.Manager;
using Weather.Domain.NotMapped;

namespace Weather.Controllers
{
    public class CidadeController : Controller
    {
        public JsonResult ObterCidades()
        {
            try
            {

                var listaCidadesModel = new List<CidadeConsultaModel>();
                var listaCidades = new CidadeManager().ObterCidades();

                foreach (var cidade in listaCidades)
                {
                    CidadeConsultaModel cidadeModel = new CidadeConsultaModel()
                    {
                        Nome = cidade.Nome,
                        Id = cidade.Id
                    };

                    listaCidadesModel.Add(cidadeModel);
                }

                return Json(new { Lista = listaCidadesModel }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }


}