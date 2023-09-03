using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace PharmacyAppClient.ViewsModels
{
    public class MainViewModel
    {
        ObservableCollection<object> _childrens;

        public MainViewModel()
        {
            _childrens = new ObservableCollection<object>
            {
                new DrugsViewModel()
            };
        }

        public ObservableCollection<object> Childrens { get { return _childrens; } }
    }
}
