namespace LibRepo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LibCoorEntitySql;
    using LibCoorEntitySql.Models;
    using LibRepo.Contract;
    using Microsoft.EntityFrameworkCore;

    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        private readonly CoordinatorSmikContext context;

        public ImageRepository(CoordinatorSmikContext dbcontext)
            : base(dbcontext)
        {
            this.context = dbcontext;
        }

        public IEnumerable<Image> AllInProject(Guid id)
        {
          var img = this.context.Images.Where(im => im.ProjectId == id);
          return img;
        }

        public Image GetTitleImg(Guid projectId)
        {
            return this.context.Images.SingleOrDefault(s => s.ProjectId.Equals(projectId) && s.Sorted.Equals(0));
        }

        public async Task<Image> GetTitleImgAsync(Guid projectId)
        {
            return await this.context.Images.SingleOrDefaultAsync(s => s.ProjectId.Equals(projectId) && s.Sorted.Equals(0));
        }
    }
}
