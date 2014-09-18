using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Model
{
    public class Login : BaseModel
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool RememberPassword { get; set; }
    }
}
