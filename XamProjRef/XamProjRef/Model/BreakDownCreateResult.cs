using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model
{
    public class BreakDownCreateResult : BaseModel
    {
        public BreakdownStatus Status { get; set; }

    }

    public enum BreakdownStatus
    { 
        Success,Error
    }


}
