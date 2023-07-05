using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using ViewerPDF.Models;

namespace ViewerPDF.Controllers
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
            string pdfUrl = "/Home/GetPdf?pdfUrl=https://bconnectstoragetest.blob.core.windows.net/temp/dotnet_core_tutorial.pdf";
            ViewData["pdfUrl"] = pdfUrl;
            return View();
        }

        public async Task<IActionResult> GetPdf(string pdfUrl)
        {
            using (var httpClient = new HttpClient())
            {
                var pdfData = await httpClient.GetByteArrayAsync(pdfUrl);
                return File(pdfData, "application/pdf");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}