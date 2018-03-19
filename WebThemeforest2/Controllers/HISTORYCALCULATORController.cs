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
    public class HistoryCalculatorController : ApiController
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
		[HttpGet]
		public IQueryable<HistoryCalculator> Get()
		{
			HistoryCalculatorRepository rep = new HistoryCalculatorRepository(connectionString);
			List<HistoryCalculator> list = rep.GetData();
			return list.AsQueryable();
		}

		[Route("api/HISTORYCALCULATOR/ID/{id}")]
		[HttpGet]
		public IQueryable<HistoryCalculator> GetByID(int id)
		{
			HistoryCalculatorRepository rep = new HistoryCalculatorRepository(connectionString);
			List<HistoryCalculator> list = rep.GetDataByID(id);
			return list.AsQueryable();
		}

		public void Post(HistoryCalculator historycalculator)
		{
			HistoryCalculatorRepository rep = new HistoryCalculatorRepository(connectionString);
			rep.Add(historycalculator);
		}

		public void Put(HistoryCalculator historycalculator)
		{
			HistoryCalculatorRepository rep = new HistoryCalculatorRepository(connectionString);
			rep.Update(historycalculator);
		}

		public void Delete(HistoryCalculator historycalculator)
		{
			HistoryCalculatorRepository rep = new HistoryCalculatorRepository(connectionString);
			rep.Remove(historycalculator);
		}

	}
}