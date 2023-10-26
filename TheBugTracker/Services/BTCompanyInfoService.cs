using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBugTracker.Data;
using TheBugTracker.Models;
using TheBugTracker.Services.Interfaces;

namespace TheBugTracker.Services
{
    public class BTCompanyInfoService : IBTCompanyInfoService
    {
        private readonly ApplicationDbContext _context;

        public BTCompanyInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            List<BTUser> result = new();

            result = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();

            return result;
        }

        public Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> GetCompanyInfoByIdAsync(int? companyId)
        {
            throw new System.NotImplementedException();
        }
    }
}
