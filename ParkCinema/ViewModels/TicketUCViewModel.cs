using ParkCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkCinema.ViewModels
{
    public class TicketUCViewModel : BaseViewModel
    {
        public List<int> SelectedRows { get; set; } = new List<int> { };
        public List<int> SelectedColumns { get; set; } = new List<int> { };
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; OnPropertyChanged(); }
        }

        private MovieSchedule movie;

        public MovieSchedule Movie
        {
            get { return movie; }
            set { movie = value; OnPropertyChanged(); }
        }
        private int selectedRow;

        public int SelectedRow
        {
            get { return selectedRow; }
            set { selectedRow = value; OnPropertyChanged(); }
        }
        private int selectedColumn;

        public int SelectedColumn
        {
            get { return selectedColumn; }
            set { selectedColumn = value; OnPropertyChanged(); }
        }
        

        static int i = 0;
        public TicketUCViewModel()
        {
            if (SelectedColumns.Count != 0 && SelectedRows.Count != 0)
            {
                SelectedColumn = SelectedColumns[i];
                SelectedRow = SelectedRows[i];
                i++;
            }
        }
    }
}
