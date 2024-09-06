using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Drawing; // 需要引入 System.Drawing.Common 库

namespace Heysundue.Controllers
{
    public class BannerController : Controller
    {
        // 最大的宽度和高度限制
        private const int MaxWidth = 1920;
        private const int MaxHeight = 1080;

        // 顯示 Banner2 頁面
        [HttpGet]
        public IActionResult Banner2()
        {
            return View();
        }

        // 處理圖片上傳請求
        [HttpPost]
        public async Task<IActionResult> UploadBanner(IFormFile fileUpload)
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var ext = Path.GetExtension(fileUpload.FileName).ToLowerInvariant();
                
                if (!string.IsNullOrEmpty(ext) && !permittedExtensions.Contains(ext))
                {
                    TempData["UploadResult"] = "無效的文件類型，只允許上傳圖片 (.jpg, .jpeg, .png, .gif)";
                    return RedirectToAction("Banner2");
                }

                // 讀取圖片並檢查尺寸
                using (var image = Image.FromStream(fileUpload.OpenReadStream()))
                {
                    if (image.Width > MaxWidth || image.Height > MaxHeight)
                    {
                        TempData["UploadResult"] = $"圖片尺寸太大，最大允許 {MaxWidth}x{MaxHeight} 像素。";
                        return RedirectToAction("Banner2");
                    }
                    
                }

                // 定義文件保存的路徑
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileUpload.FileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                // 保存文件到服務器
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                TempData["UploadResult"] = $"文件 {fileUpload.FileName} 上傳成功！";
            }
            else
            {
                TempData["UploadResult"] = "請選擇一個文件進行上傳。";
            }

            // 上傳完成後重定向到同一頁面
            return RedirectToAction("Banner2");
        }

        // 處理選擇圖標的請求
        [HttpPost]
        public IActionResult SetIcon(string selectedIcon)
        {
            // 将用户选择的图标存储到 Session 中
            HttpContext.Session.SetString("Favicon", selectedIcon);

            // 重定向回 Banner2 页面
            return RedirectToAction("Banner2");
        }
    }
}
