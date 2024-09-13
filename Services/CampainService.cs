using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnallyzerAPI.Database;
using AnallyzerAPI.Models;

namespace AnallyzerAPI.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly AnallyzerDbContext _context;

        public CampaignService(AnallyzerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Campain>> GetAllCampaignsAsync()
        {
            return await _context.Campain.ToListAsync();
        }

        public async Task<Campain> GetCampaignByIdAsync(int id)
        {
            return await _context.Campain.FindAsync(id);
        }

        public async Task<Campain> CreateCampaignAsync(Campain campain)
        {
            _context.Campain.Add(campain);
            await _context.SaveChangesAsync();
            return campain;
        }

        public async Task<bool> UpdateCampaignAsync(int id, Campain campain)
        {
            if (id != campain.ID)
            {
                return false;
            }

            _context.Entry(campain).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }



        public async Task<bool> DeleteCampaignAsync(int id)
        {
            var campain = await _context.Campain.FindAsync(id);
            if (campain == null)
            {
                return false;
            }

            _context.Campain.Remove(campain);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool CampaignExists(int id)
        {
            return _context.Campain.Any(e => e.ID == id);
        }
    }
}
