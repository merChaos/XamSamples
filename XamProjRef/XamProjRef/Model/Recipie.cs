using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model
{
    public class Recipe : BaseModel 
    {
        public string Description { get; set; }
        public TimeSpan PrepTime { get; set; }
        public TimeSpan CookingTime { get; set; }
        public List<string> Directions { get; set; }
    }
}
