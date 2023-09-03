using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PharmacyAppClient.Models;

namespace PharmacyAppClient.ViewsModels
{
    public class DrugViewModel : INotifyPropertyChanged
    {
        private Drug drug;

        public string Name
        {
            get
            {
                return drug.Name;
            }
            set
            {
                drug.Name = value;
                OnPropertyChanged("Name");

            }
        }

        public double Price
        {
            get
            {
                return drug.Price;
            }
            set
            {
                drug.Price = value;
                OnPropertyChanged("Price");
            }
        }

        public Group Group
        {
            get
            {
                return drug.Group;
            }
            set
            {
                drug.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public Provider Provider
        {
            get
            {
                return drug.Provider;
            }
            set
            {
                drug.Provider = value;
                OnPropertyChanged("Provider");
            }
        }
        public DrugViewModel(Drug d)
        {
            drug = d;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
