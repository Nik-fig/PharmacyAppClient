using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PharmacyAppClient.Models;
using PharmacyAppClient.Services;
using PharmacyAppClient.utils.api;

namespace PharmacyAppClient.ViewsModels
{
    public class DrugsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Drug> Drugs { get; set; }
        private DrugsApi drugsApi;
        public Drug selectedDrug { get; set; }
        public Drug SelectedDrug
        {
            get
            {
                return selectedDrug;
            }
            set
            {
                selectedDrug = value;
                OnPropertyChanged("SelectedDrug");
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      var response = Task.Run(() => drugsApi.DeleteDrugAsync(selectedDrug));
                      if (response.Result == System.Net.HttpStatusCode.OK)
                          Drugs.Remove(selectedDrug);
                  }));
            }
        }

        public DrugsViewModel()
        {
            drugsApi = DrugsApi.getInstance();
            var drugs = Task.Run(() => drugsApi.GetAllDrugsAsync());
            Drugs = new ObservableCollection<Drug>(drugs.Result);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
