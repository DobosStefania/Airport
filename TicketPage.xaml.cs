using Airport.Data;
using Airport.Models;
namespace Airport;

public partial class TicketPage : ContentPage
{
    FlightList fl;

    public TicketPage(FlightList flist)
    {
        InitializeComponent();
        fl = flist;
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var ticket = (Ticket)BindingContext;
        await App.Database.SaveTicketAsync(ticket);
        listView.ItemsSource = await App.Database.GetTicketsAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var ticket = (Ticket)BindingContext;
        await App.Database.DeleteTicketAsync(ticket);
        listView.ItemsSource = await App.Database.GetTicketsAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetTicketsAsync();
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Ticket t;
        if (listView.SelectedItem != null)
        {
            t = listView.SelectedItem as Ticket;
            var lt = new ListTicket()
            {
                FlightListID = fl.ID,
                TicketID = t.ID
            };
            await App.Database.SaveListTicketAsync(lt);
            t.ListTickets = new List<ListTicket> { lt };
            await Navigation.PopAsync();
        }

    }
}