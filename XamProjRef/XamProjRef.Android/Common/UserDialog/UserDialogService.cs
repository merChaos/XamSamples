using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamProjRef1.Common;
using Xamarin.Forms;
using XamProjRef.Droid.Common.UserDialog;
using Android.Text.Method;

[assembly: Dependency(typeof(UserDialogService))]

namespace XamProjRef.Droid.Common.UserDialog
{
    public class UserDialogService : AbstractUserDialog
    {
        public override void Alert(AlertConfig config)
        {
            PlatformHelper.RequestMainThread(() => new AlertDialog
            .Builder(PlatformHelper.GetActiveContext())
            .SetMessage(config.Message)
            .SetTitle(config.AlertTitle)
            .SetPositiveButton(config.OkButtonText, (o, e) =>
            {
                if (config.OkButtonAction != null)
                    config.OkButtonAction();
            })
            .Show());
        }

        public override void Confirm(ConfirmConfig config)
        {

            // Do something here
            throw new NotImplementedException();
        }

        public override void Toast(string message, int timeoutSeconds = 3, Action onClick = null)
        {
            throw new NotImplementedException();
        }

        protected override IProgressDialog CreatePlatformDialogInstance()
        {
            throw new NotImplementedException();
        }

        public override void AlertWithInput(AlertInputConfig config)
        {
            PlatformHelper.RequestMainThread(() =>
                {
                    var text = new EditText(PlatformHelper.GetActiveContext()) { Hint = config.PlaceHolder };
                    if (config.IsTextSecure) { text.TransformationMethod = PasswordTransformationMethod.Instance; }
                    new AlertDialog.Builder(PlatformHelper.GetActiveContext())
                    .SetMessage(config.Message)
                    .SetTitle(config.AlertTitle)
                    .SetView(text)
                    .SetPositiveButton(config.OkText, (o, e) =>
                        {
                            config.OnActionCallBack(new AlertInputResult() { InputText = text.Text, Ok = true });
                        })
                    .SetNegativeButton(config.CancelText, (o, e) => { config.OnActionCallBack(new AlertInputResult() { Ok = false, InputText = text.Text }); }) 
                    .Show();
                });
        }
    }
}