using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Sudoku.View.UserControls;

namespace Sudoku.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public UserControl TopLeftControl { get; set; }
        public UserControl TopCenterControl { get; set; }
        public UserControl TopRightControl { get; set; }
        public UserControl CenterLeftControl { get; set; }
        public UserControl CenterCenterControl { get; set; }
        public UserControl CenterRightControl { get; set; }
        public UserControl BottomLeftControl { get; set; }
        public UserControl BottomCenterControl { get; set; }
        public UserControl BottomRightControl { get; set; }

        public MainViewModel()
        {
            TopLeftControl = new TopLeftControl();
            TopCenterControl = new TopCenterControl();
            TopRightControl = new TopRightControl();

            CenterLeftControl = new CenterLeftControl();
            CenterCenterControl = new CenterCenterControl();
            CenterRightControl = new CenterRightControl();

            BottomLeftControl = new BottomLeftControl();
            BottomCenterControl = new BottomCenterControl();
            BottomRightControl = new BottomRightControl();
        }
    }
}