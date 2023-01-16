using Airport.Models;
using Airport.Data;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
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
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TicketPage((FlightList)
       this.BindingContext)
        {
            BindingContext = new Ticket()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var flightl = (FlightList)BindingContext;

        listView.ItemsSource = await App.Database.GetListTicketsAsync(flightl.ID); ;
    }
}