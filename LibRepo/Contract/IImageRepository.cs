namespace LibRepo.Contract
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LibCoorEntitySql.Models;

    public interface IImageRepository : IRepository<Image>
    {
        Image GetTitleImg(Guid projectId);

        Task<Image> GetTitleImgAsync(Guid projectId);

        IEnumerable<Image> AllInProject(Guid id);
    }
}
