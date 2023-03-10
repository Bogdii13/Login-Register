namespace mobile1.Views;
using System.Transactions;
using mobile1.ViewModels;

public partial class ScheduleListView : ContentPage
{
    private bool _isPanelTranslated;
    public ScheduleListView()
	{
		InitializeComponent();

        this.BindingContext = new ScheduleListViewModel();

        panelLeft.TranslateTo(-30, 0, 100);
    }

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        var viewModel = (ScheduleListViewModel)BindingContext;
        viewModel.BindDataToScheduleList();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (_isPanelTranslated)
        {
            panelLeft.TranslateTo(-80, 0, 150);
        }
        else
        {
            panelLeft.TranslateTo(0, 0, 150);
        }

        _isPanelTranslated = !_isPanelTranslated;
    }
}