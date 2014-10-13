using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Helper;

namespace XamProjRef1.Common
{
    public abstract class AbstractUserDialog : IUserDialog
    {

        private IProgressDialog loading;

        public abstract void Alert(AlertConfig config);
        

        public abstract void Confirm(ConfirmConfig config);
        
        public IProgressDialog Progress(ProgressConfig config)
        {
            var platformProgressDialog = this.CreatePlatformDialogInstance();
            platformProgressDialog.Title = config.Title;
            platformProgressDialog.IsDeterministic = config.IsDeterministic;

            if (config.OnCancel != null) { platformProgressDialog.SetCancel(config.OnCancel, config.CancelText); }

            if (config.AutoShow) { platformProgressDialog.ShowProgressDialog(); }

            return platformProgressDialog;
        }

        public void ShowLoading(string title = "Loading...")
        {
            if (this.loading == null) { this.loading = this.Loading(title, null, null, true); }
        }

        public void HideLoading()
        {
            if (this.loading != null)
            {
                this.loading.Dispose(); // dispose the progress dialog created by the platform.
                this.loading = null;
            }
        }

        public abstract void Toast(string message, int timeoutSeconds = 3, Action onClick = null);


        protected abstract IProgressDialog CreatePlatformDialogInstance();
    }
}
