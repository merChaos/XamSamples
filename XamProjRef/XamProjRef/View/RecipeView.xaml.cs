using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;
using XamProjRef1.ViewModel;

namespace XamProjRef1.View
{
    public partial class RecipeView
    {
        public RecipeView()
        {
            InitializeComponent();
        }

        public RecipeView(Recipe recipe)
        {
            InitializeComponent();
            this.BindingContext = recipe;
        }
        //public RecipeView(RecipeViewModel recipeViewModel)
        //{
        //    InitializeComponent();
        //    this.BindingContext = recipeViewModel;
        //}
    }
}
