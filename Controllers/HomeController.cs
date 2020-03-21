using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Angular_colors.Models;
using System.Data.SQLite;
using Dapper;
using System.IO;

namespace Angular_colors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["data"] = DataClass.GetAllColors();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class DataClass
    {
        public static SQLiteConnection myDbCon()
        {
            string currentDirPath = Path.Combine(Directory.GetCurrentDirectory());
            return new SQLiteConnection(@"Data Source=" + currentDirPath + "/colors.db");
        }

        public static List<ColorsModel> GetAllColors()
        {
            List<ColorsModel> dataOut = new List<ColorsModel>();
            try
            {
                using (var dbCon = myDbCon())
                {
                    dbCon.Open();
                    dataOut = dbCon.Query<ColorsModel>("SELECT * FROM desc LIMIT 5").ToList();

                    /* replaced by dapper, the power of simplicity
                    cmd.CommandText = "SELECT * from desc";
                    cmd.CommandType = System.Data.CommandType.Text;

                    SQLiteDataReader reader;
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                        dataOut.Add(reader.GetValues().ToString());
                     */
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //DoException(ex);
            }
            return dataOut;
        }
    }
}