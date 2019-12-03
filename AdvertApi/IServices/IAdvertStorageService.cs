using AdvertApi.Models;
using System.Threading.Tasks;

namespace AdvertApi.IServices
{
    public interface IAdvertStorageService
    {
        Task<string> Add(AdvertModel model);
        Task Confirm(ConfirmAdvertModel model);
    }
}
