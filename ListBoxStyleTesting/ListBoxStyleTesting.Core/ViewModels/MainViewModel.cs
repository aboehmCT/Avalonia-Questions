using CommunityToolkit.Mvvm.ComponentModel;

using System.Collections.Generic;
using System.Linq;

namespace ListBoxStyleTesting.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public Dictionary<string, ViewModelBase> Pages { get; } = [];

    [ObservableProperty]
    public KeyValuePair<string, ViewModelBase> _SelectedPage;

    public MainViewModel()
    {
        Pages.Add("Page1", new Page1ViewModel());
        Pages.Add("Page2", new Page2ViewModel());
        Pages.Add("Page3", new Page3ViewModel());

        SelectedPage = Pages.First();
    }
}
