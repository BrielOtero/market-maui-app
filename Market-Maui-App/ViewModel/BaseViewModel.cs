namespace Market_Maui_App.ViewModel;

internal partial class BaseViewModel: ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy=>!isBusy;
}
