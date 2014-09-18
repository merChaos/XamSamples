using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamProjRef1.Model;

namespace XamProjRef1.VIewModel
{
    public class RecipeViewModel : BaseViewModel
    {
        private Recipe _recipe;


        public RecipeViewModel(Recipe recipe)
        {
            _recipe = recipe;
            Directions = new ObservableCollection<string>(_recipe.Directions);
        }

        public ObservableCollection<string> Directions { get; set; }

        //public const 
        //public string Name
        //{
        //    get { return _recipe != null ? _recipe.Name : null; }
        //    set
        //    {
        //        if (_recipe != null)
        //        {
        //            _recipe.Name = value;
        //        }

        //    }
        //}

        
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
    }
}

