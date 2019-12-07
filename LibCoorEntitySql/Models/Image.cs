using System;
using System.Collections.Generic;

namespace LibCoorEntitySql.Models
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public int Sorted { get; set; }
        public Guid? ProjectId { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }

        public virtual Project Project { get; set; }
    }
}
