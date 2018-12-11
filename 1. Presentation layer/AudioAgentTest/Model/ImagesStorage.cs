using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudioAgentTest.Model
{
    public class ImagesStorage
    {
        [Column("ImageID")]
        public int? Id { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string ImageFileExtension { get; set; }
        public Nullable<DateTime> DateCreated { get; set; }
    }
}
