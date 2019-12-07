using System;
using System.Collections.Generic;

namespace LibCoorEntitySql.Models
{
    public partial class Project
    {
        public Project()
        {
            Computers = new HashSet<Computer>();
            Groups = new HashSet<Group>();
            Images = new HashSet<Image>();
        }

        public Guid Id { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public string AddressRu { get; set; }
        public string AddressEn { get; set; }
        public string CityRu { get; set; }
        public string CityEn { get; set; }
        public string CountryRu { get; set; }
        public string CountryEn { get; set; }
        public DateTime? StartedDate { get; set; }
        public string DescriptionRu { get; set; }
        public string DescriptionEn { get; set; }
        public int? SystemState { get; set; }
        public int? ConstructionState { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int ApiState { get; set; }
        public int SortIndex { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
