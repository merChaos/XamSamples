using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Model;
using XamProjRef1.VIewModel;

namespace XamProjRef1.View
{
    public partial class RecipleListPage
    {
        public RecipleListPage()
        {
            InitializeComponent();
            this.BindingContext = new RecipeListViewModel();
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var recipe = args.Item as Recipe;
            if (recipe == null) return;

            Navigation.PushAsync(new RecipeSummaryPage(new RecipeViewModel(recipe)));
            this.recipeList.SelectedItem = null;
        }
    }
}
