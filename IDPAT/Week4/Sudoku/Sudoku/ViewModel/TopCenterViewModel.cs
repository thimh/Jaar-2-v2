using System.ComponentModel;
using System.Runtime.CompilerServices;
using Sudoku.Annotations;

namespace Sudoku.ViewModel
{
    public class TopCenterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}