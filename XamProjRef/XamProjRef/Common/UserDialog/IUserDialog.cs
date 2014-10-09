using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public interface IUserDialog
    {
        void Alert(AlertConfig config);

        //void Confirm()
    }
}
