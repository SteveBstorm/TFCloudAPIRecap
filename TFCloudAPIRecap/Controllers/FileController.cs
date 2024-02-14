using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFCloudAPIRecap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {
            HttpRequest req = HttpContext.Request;
            string filename = req.Form.Files[0].FileName;

            string extension = filename.Substring(filename.LastIndexOf('.')+1, 3);

            if (extension != "jpg") return BadRequest(extension);

            if (!Directory.Exists("images"))
                Directory.CreateDirectory("images");

            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "images/", filename);

            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                await req.Form.Files[0].CopyToAsync(fs);

                return Ok($"https://localhost:7120/images/{filename}");
            }
        }
    }
}
