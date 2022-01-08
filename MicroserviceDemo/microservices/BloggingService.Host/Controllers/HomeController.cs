using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.BlobStoring;


namespace BloggingService.Host.Controllers
{
    public class HomeController : AbpController
    {
        private readonly IBlobContainer _blobContainer;

        public HomeController(IBlobContainerFactory blobContainerFactory)
        {
            _blobContainer = blobContainerFactory.Create("blogging-files");
        }

        public ActionResult Index()
        {
            return Redirect("/swagger");
        }

        public async Task<ActionResult> Test()
        {
            ContentResult content = new ContentResult();
            content.Content = "test";
            content.ContentType = "text/plain";

            await BlobTest();

            return content;
        }

        // 测试 BLOB Storing 的存储路径
        private async Task BlobTest()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"F:\vvv.jpg");
            var blobName = "abc.jpg";
            await _blobContainer.SaveAsync(blobName, bytes);
        }
    }
}
