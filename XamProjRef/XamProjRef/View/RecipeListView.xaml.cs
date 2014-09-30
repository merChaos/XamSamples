using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Model;
using XamProjRef1.ViewModel;

namespace XamProjRef1.View
{
    public partial class RecipeListView
    {
        public RecipeListView()
        {
            InitializeComponent();
            //this.BindingContext = new RecipeListViewModel();
        }

        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var recipe = args.Item as Recipe;
            if (recipe == null) return;

            RecipeView page = new RecipeView();
            App.Navigator.PushAsync(page);
            //App.NavigateTo<RecipeViewModel>(recipe);
            //Navigation.PushAsync(new RecipeView(new RecipeViewModel(recipe)));
            this.recipeList.SelectedItem = null;
        }
    }
}
