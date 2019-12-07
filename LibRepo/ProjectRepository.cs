namespace LibRepo
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LibCoorEntitySql;
    using LibCoorEntitySql.Models;
    using LibRepo.Contract;
    using Microsoft.EntityFrameworkCore;

    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly CoordinatorSmikContext context;

        public ProjectRepository(CoordinatorSmikContext dbcontext)
            : base(dbcontext)
        {
            this.context = dbcontext;
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            return await this.context.Projects.OrderBy(index => index.SortIndex).ToListAsync();
        }
    }
}
