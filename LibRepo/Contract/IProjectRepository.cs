namespace LibRepo.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LibCoorEntitySql.Models;

    public interface IProjectRepository : IRepository<Project>
    {
        Task<IEnumerable<Project>> GetAllProjectAsync();
    }
}
