using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace studentportal.api.Repositories
{
    public class LocalStroageImageRepository : IImageRepository
    {
        public async Task<string> Upload(IFormFile formFile, string fileName)
        {
            //throw new System.NotImplementedException();
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources\Images",fileName);

            using Stream filestream = new FileStream(filepath, FileMode.Create);//, FileAccess.Read);

            await formFile.CopyToAsync(filestream);

            return GetServerRelativePath(fileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Resources\Images", fileName);
        }
    }
}
