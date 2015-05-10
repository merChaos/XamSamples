using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamProjRef1.Model;

namespace XamProjRef1.ViewModel
{
    public class RecipeViewModel : BaseViewModel
    {
        private Recipe _recipe;

        public RecipeViewModel()
        {
            
        }

        public override void Init(object args)
        {
            this._recipe = args as Recipe;
            Directions = new ObservableCollection<string>(_recipe.Directions);
        }
        
        public RecipeViewModel(Recipe recipe)
        {
            _recipe = recipe;
            Directions = new ObservableCollection<string>(_recipe.Directions);
        }

        public ObservableCollection<string> Directions { get; set; }

        
        public string Description
        {
            get { return _recipe != null ? _recipe.Description : null; }
            set
            {
                if (_recipe != null)
                {
                    _recipe.Description = value;
                }
                OnPropertyChanged("Description");
            }
        }

        public string PrepTime
        {
            get { return _recipe != null ? _recipe.PrepTime.ToString() : "None"; }
            set
            {
                if (_recipe != null)
                {
                    _recipe.PrepTime = TimeSpan.Parse(value);
                } 
                OnPropertyChanged("PrepTime");
            }
        }

        public string CookingTime
        {
            get { return _recipe != null ? _recipe.CookingTime.ToString() : "None"; }
            set
            {
                if (_recipe != null)
                {
                    _recipe.CookingTime = TimeSpan.Parse(value);
                }
                OnPropertyChanged("CookingTime");
            }
        }

        public const string NAVIGATE_TO_COMMAND_NAME = "NavigateToCommand";
        public Command navigateToCommand { protected set; get; }
        public Command NavigateToCommand
        {
            get { return navigateToCommand ?? (navigateToCommand = new Command(() => App.NavigateTo<DashboardViewModel>(null,true))); }
        }
    }
}

