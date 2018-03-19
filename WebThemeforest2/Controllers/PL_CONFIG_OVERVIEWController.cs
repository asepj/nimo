using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using WebThemeforest2.Models;
using WebThemeforest2.Repositories;

namespace WebThemeforest2
{
    public class PL_CONFIG_OVERVIEWController : ApiController
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
        [HttpGet]
        public IQueryable<PL_CONFIG_OVERVIEW> Get()
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetData();
            return list.AsQueryable();
        }

        [Route("api/PL_CONFIG_OVERVIEW/AREA_NAME/{id}")]
        [HttpGet]
        public IQueryable<PL_CONFIG_OVERVIEW> GetByID(string AREA_NAME)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetDataByID(AREA_NAME);
            return list.AsQueryable();
        }

        public void Post(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            rep.Add(pl_config_overview);
        }

        public void Put(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            rep.Update(pl_config_overview);
        }

        public void Delete(PL_CONFIG_OVERVIEW pl_config_overview)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            rep.Remove(pl_config_overview);
        }



        [Route("api/PL_CONFIG_OVERVIEW/AreaSelect")]
        [HttpPost]
        public IQueryable<PL_CONFIG_OVERVIEW> AreaSelect([FromBody]PL_CONFIG_OVERVIEW pl_config_overview)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetAreaSelect(pl_config_overview);
            return list.AsQueryable();
        }

        [Route("api/PL_CONFIG_OVERVIEW/maptypeSelect")]
        [HttpPost]
        public IQueryable<PL_CONFIG_OVERVIEW> maptypeSelect([FromBody]PL_CONFIG_OVERVIEW pl_config_overview)
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetMapSelect(pl_config_overview);
            return list.AsQueryable();
        }


        [Route("api/PL_CONFIG_OVERVIEW/GetKarSettSaturation")]
        [HttpGet]
        public IQueryable<PL_CONFIG_OVERVIEW> SaturationSelect()
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetDataKarawangSaturation();
            return list.AsQueryable();
        }


        [Route("api/PL_CONFIG_OVERVIEW/GetKarSettNode")]
        [HttpGet]
        public IQueryable<PL_CONFIG_OVERVIEW> NodeSelect()
        {
            PL_CONFIG_OVERVIEWRepository rep = new PL_CONFIG_OVERVIEWRepository(connectionString);
            List<PL_CONFIG_OVERVIEW> list = rep.GetDataKarawangNode();
            return list.AsQueryable();
        }


    }
}