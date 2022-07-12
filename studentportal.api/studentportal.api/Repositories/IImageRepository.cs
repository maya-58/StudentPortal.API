using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace studentportal.api.Repositories
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile formFile, string fileName);
    }
}



