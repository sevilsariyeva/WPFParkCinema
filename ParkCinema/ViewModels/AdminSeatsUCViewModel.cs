using Newtonsoft.Json;
using ParkCinema.Commands;
using ParkCinema.Models;
using ParkCinema.Views.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace ParkCinema.ViewModels
{
    public class AdminSeatsUCViewModel : BaseViewModel
    {
        public RelayCommand PlaceClickCommand { get; set; }
        private MovieSchedule movie;

        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private void WriteData(List<SelectedButtons>data)
        {
            string jsonString = JsonConvert.SerializeObject(data);
            File.WriteAllText("toggleButtonState.json", jsonString);
        }
        public AdminSeatsUCViewModel()
        {
            PlaceClickCommand = new RelayCommand((obj) =>
            {
                Grid grid = obj as Grid;
                if (grid == null) return;
                var data = new List<SelectedButtons>();
                if (File.Exists("toggleButtonState.json"))
                {
                    string jsonString = File.ReadAllText("toggleButtonState.json");

                    data = JsonConvert.DeserializeObject<List<SelectedButtons>>(jsonString);
                    foreach (var item in data)
                    {
                        foreach (UIElement child in grid.Children)
                        {
                            ToggleButton toggleButton = child as ToggleButton;
                            if (toggleButton.Name != item.ButtonName)
                            {
                                toggleButton.IsChecked = true;
                            }
                        }
                    }
                }
                var uc = new EditUC();
                var vm = new EditUCViewModel();
                vm.Data=data;
                uc.DataContext = vm;
            });
        }
    }
}
