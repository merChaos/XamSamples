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
using AndroidHUD;

namespace XamProjRef.Droid.Common.UserDialog
{
    public class ProgressDialogAndroid : IProgressDialog
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public virtual string Title
        {
            get { return this.title; }
            set
            {
                if (this.title == value)
                    return;
                this.title = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// The percentage complete
        /// </summary>
        private int percentageComplete;
        /// <summary>
        /// Gets or sets the percentage complete.
        /// </summary>
        /// <value>The percentage complete.</value>
        public virtual int PercentageComplete
        {
            get { return this.percentageComplete; }
            set
            {
                if (this.percentageComplete == value)
                    return;
                if (value > 100) { this.percentageComplete = 100; }
                else if (value < 0) { this.percentageComplete = 0; }
                else { this.percentageComplete = value; }
                this.Refresh();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deterministic.
        /// </summary>
        /// <value><c>true</c> if this instance is deterministic; otherwise, <c>false</c>.</value>
        public virtual bool IsDeterministic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is showing.
        /// </summary>
        /// <value><c>true</c> if this instance is showing; otherwise, <c>false</c>.</value>
        public virtual bool IsShowing { get; set; }

        /// <summary>
        /// The cancel action
        /// </summary>
        private Action cancelAction;

        /// <summary>
        /// The cancel text
        /// </summary>
        private string cancelText;

        /// <summary>
        /// Sets the cancel.
        /// </summary>
        /// <param name="onCancel">The on cancel.</param>
        /// <param name="cancelText">The cancel.</param>
        public virtual void SetCancel(Action onCancel, string cancelText)
        {
            this.cancelAction = onCancel;
            this.cancelText = cancelText;
        }

        /// <summary>
        /// Shows the progress dialog.
        /// </summary>
        public virtual void ShowProgressDialog()
        {
            if (this.IsShowing)
                return;
            this.IsShowing = true;
            this.Refresh();
        }

        /// <summary>
        /// Hides the progress dialog.
        /// </summary>
        public virtual void HideProgressDialog()
        {
            this.IsShowing = false;
            PlatformHelper.RequestMainThread(() => AndHUD.Shared.Dismiss(PlatformHelper.GetActivityContext()));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {
            this.HideProgressDialog();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        protected virtual void Refresh()
        {
            if (!this.IsShowing)
                return;
            var progress = -1;
            var message = this.Title;
            if (this.IsDeterministic)
            {
                progress = this.PercentageComplete;
                if (!String.IsNullOrWhiteSpace(message))
                    message += "\n";
                message += progress + "%\n";
            }
            if (this.cancelAction != null)
                message += "\n" + this.cancelText;
            PlatformHelper.RequestMainThread(() => AndHUD.Shared.Show(
                PlatformHelper.GetActivityContext(), message, progress, MaskType.Black, null, this.OnCancelClick));
        }

        /// <summary>
        /// Called when [cancel click].
        /// </summary>
        private void OnCancelClick()
        {
            if (this.cancelAction == null)
                return;
            this.HideProgressDialog();
            this.cancelAction();
        }


    }
}