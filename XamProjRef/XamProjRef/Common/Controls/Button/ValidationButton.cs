using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Common.Controls.Input;

namespace XamProjRef1.Common.Controls.Button
{
    public class ValidationButton : Xamarin.Forms.Button
    {
        public static readonly BindableProperty IsFormEntryValidProperty = BindableProperty.Create<ValidationButton, bool>(p => p.IsValid, false);

        public bool IsValid
        {
            get { return (bool)GetValue(IsFormEntryValidProperty); }
            set { SetValue(IsFormEntryValidProperty, value); }
        }
        public IList<AbstractValidator> Validators { get; set; }
    }
}
