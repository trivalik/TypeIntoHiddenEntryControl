using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TypeIntoHiddenEntryControl.ViewModel;

public partial class MainPageViewModel : INotifyPropertyChanged
{
    private string _word = "";
    private bool _modeActive = true;

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainPageViewModel()
    {
        ToggleMode = new Command(
            execute: () =>
            {
                IsModeActive = !IsModeActive;
            }
		);
    }
    public Command ToggleMode { get; }

    public bool IsModeActive
    {
        get { return _modeActive; }
        set { SetProperty(ref _modeActive, value); }
    }

    public string Word
    {
        get { return _word; }
        set { SetProperty(ref _word, value); }
    }

    private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
    {
        if (object.Equals(storage, value))
            return false;

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
