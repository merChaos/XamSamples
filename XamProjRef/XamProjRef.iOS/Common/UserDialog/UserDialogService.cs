﻿using BigTed;
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamProjRef.iOS.Common.UserDialog;
using XamProjRef1.Common;

[assembly: Dependency(typeof(UserDialogService))]
namespace XamProjRef.iOS.Common.UserDialog
{
    public class UserDialogService : AbstractUserDialog
    {

        public override void Alert(AlertConfig config)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var dlg = new UIAlertView(config.AlertTitle ?? String.Empty, config.Message, null, null, config.OkButtonText);
                if (config.OkButtonAction != null)
                    dlg.Clicked += (s, e) => config.OkButtonAction();
                dlg.Show();
            }); 

        }

        public override void Confirm(ConfirmConfig config)
        {
            Device.BeginInvokeOnMainThread(() => { 
             var dlg = new UIAlertView(config.Title ?? String.Empty, config.Message, null, config.CancelButtonText, config.OkButtonText); 
             dlg.Clicked += (s, e) => { 
                 var ok = (dlg.CancelButtonIndex != e.ButtonIndex); 
                 config.OnConfirm(ok); 
             }; 
             dlg.Show(); 
            }); 
        }

        protected override IProgressDialog CreatePlatformDialogInstance()
        {
            throw new NotImplementedException();
        }

        public override void Toast(string message, int timeoutSeconds = 3, Action onClick = null)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var ms = timeoutSeconds * 1000;
                BTProgressHUD.ShowToast(message, false, ms);
            }); 
        }

        public override void AlertWithInput(AlertInputConfig config)
        {
            Device.BeginInvokeOnMainThread(() =>
                {
                    var uiAlertView = new UIAlertView(config.AlertTitle, config.Message, null, config.CancelText, config.OkText)
                    {
                        AlertViewStyle = config.IsTextSecure ? UIAlertViewStyle.SecureTextInput : UIAlertViewStyle.PlainTextInput
                    };
                    var txt = uiAlertView.GetTextField(0);
                    txt.Placeholder = config.PlaceHolder;
                    txt.SecureTextEntry = config.IsTextSecure;
                    
                    uiAlertView.Clicked+= (sender, args) => 
                        {
                            config.OnActionCallBack(new AlertInputResult() { InputText = txt.Text, Ok = (uiAlertView.CancelButtonIndex != args.ButtonIndex) });
                        };
                    uiAlertView.Show();
                });
        }
    }
}
