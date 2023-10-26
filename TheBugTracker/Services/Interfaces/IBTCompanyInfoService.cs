using System.Collections.Generic;
using System.Threading.Tasks;
using TheBugTracker.Models;

namespace TheBugTracker.Services.Interfaces
{
    public interface IBTCompanyInfoService
    {
        public Task<Company> GetCompanyInfoByIdAsync(int? companyId); //nullable for checks (learning purposes)

        public Task<List<BTUser>> GetAllMembersAsync(int companyId);

        public Task<List<Project>> GetAllProjectsAsync(int companyId);

        public Task<List<Ticket>> GetAllTicketsAsync(int companyId);




    }
}
