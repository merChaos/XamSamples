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
using AndroidHUD;

[assembly: Dependency(typeof(UserDialogService))]

namespace XamProjRef.Droid.Common.UserDialog
{
    public class UserDialogService : AbstractUserDialog
    {
        public override void Alert(AlertConfig config)
        {
            PlatformHelper.RequestMainThread(() => new AlertDialog
            .Builder(PlatformHelper.GetActivityContext())
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
            PlatformHelper.RequestMainThread(() =>
            {
                onClick = onClick ?? (() => { });
                AndHUD.Shared.ShowToast(
                PlatformHelper.GetActivityContext(),
                message,
                MaskType.Clear,
                TimeSpan.FromSeconds(timeoutSeconds),
                false,
                onClick);
            });
        }

        protected override IProgressDialog CreatePlatformDialogInstance()
        {
            return new ProgressDialogAndroid();
        }

        public override void AlertWithInput(AlertInputConfig config)
        {
            PlatformHelper.RequestMainThread(() =>
                {
                    var text = new EditText(PlatformHelper.GetActivityContext()) { Hint = config.PlaceHolder };
                    if (config.IsTextSecure) { text.TransformationMethod = PasswordTransformationMethod.Instance; }
                    new AlertDialog.Builder(PlatformHelper.GetActivityContext())
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