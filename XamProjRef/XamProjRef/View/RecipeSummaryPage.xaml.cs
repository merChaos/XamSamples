using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.VIewModel;

namespace XamProjRef1.View
{
    public partial class RecipeSummaryPage
    {
        public RecipeSummaryPage(RecipeViewModel recipeViewModel)
        {
            InitializeComponent();
            this.BindingContext = recipeViewModel;
        }
    }
}
