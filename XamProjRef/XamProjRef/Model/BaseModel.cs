using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }


    }
}
