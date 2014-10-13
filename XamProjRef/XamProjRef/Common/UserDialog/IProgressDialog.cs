using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamProjRef1.Common
{
    public interface IProgressDialog : IDisposable
    {
        string Title { get; set; }

        int PercentageComplete { get; set; }

        bool IsDeterministic { get; set; }

        bool IsShowing { get; set; }

        void SetCancel(Action onCancel, string cancelText = "Cancel");

        void ShowProgressDialog();

        void HideProgressDialog();

    }
}
