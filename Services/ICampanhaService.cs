using System.Collections.Generic;
using System.Threading.Tasks;
using AnallyzerAPI.Models;

namespace AnallyzerAPI.Services
{
    public interface ICampaignService
    {
        Task<IEnumerable<Campain>> GetAllCampaignsAsync();
        Task<Campain> GetCampaignByIdAsync(int id);
        Task<Campain> CreateCampaignAsync(Campain campain);
        Task<bool> UpdateCampaignAsync(int id, Campain campain);
        Task<bool> DeleteCampaignAsync(int id);
    }
}
