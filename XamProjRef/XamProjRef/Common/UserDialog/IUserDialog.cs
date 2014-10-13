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

        void Confirm(ConfirmConfig config);

        IProgressDialog Progress(ProgressConfig config);

        void ShowLoading(string title = "Loading...");

        void HideLoading();

        void Toast(string message, int timeoutSeconds = 3, Action onClick = null);
    }
}
