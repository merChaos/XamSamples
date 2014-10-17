using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1
{
    public class SessionToken
    {
        public SessionToken()
        {
            this.SessionCreatedDate = DateTime.Now;
        }
        public string TokenId { get; set; }

        private DateTime SessionCreatedDate { get; set; }

        public int SessionElapsedTime {
            get
            {
                return (DateTime.Now - SessionCreatedDate).Minutes; 
            }
        }
    }
}
