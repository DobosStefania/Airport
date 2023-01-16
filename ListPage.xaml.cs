using Airport.Models;
namespace Airport;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (FlightList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveFlightListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (FlightList)BindingContext;
        await App.Database.DeleteFlightListAsync(slist);
        await Navigation.PopAsync();
    }
}