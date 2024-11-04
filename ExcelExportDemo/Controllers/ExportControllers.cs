using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ExcelExportDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        [HttpGet("export-data")]
        public IActionResult ExportData()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sample Data");
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Age";

                worksheet.Cell(2, 1).Value = 1;
                worksheet.Cell(2, 2).Value = "John Doe";
                worksheet.Cell(2, 3).Value = 30;

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "data.xlsx");
                }
            }
        }
    }
}