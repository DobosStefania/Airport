using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Airport.Models;


namespace Airport.Data
{
    public class FlightListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public FlightListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<FlightList>().Wait();
            _database.CreateTableAsync<Ticket>().Wait();
            _database.CreateTableAsync<ListTicket>().Wait();
        }
        public Task<List<FlightList>> GetFlightListsAsync()
        {
            return _database.Table<FlightList>().ToListAsync();
        }
        public Task<FlightList> GetFlightListAsync(int id)
        {
            return _database.Table<FlightList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveFlightListAsync(FlightList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteFlightListAsync(FlightList slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task<int> SaveTicketAsync(Ticket ticket)
        {
            if (ticket.ID != 0)
            {
                return _database.UpdateAsync(ticket);
            }
            else
            {
                return _database.InsertAsync(ticket);
            }
        }
        public Task<int> DeleteTicketAsync( Ticket ticket)
        {
            return _database.DeleteAsync(ticket);
        }
        public Task<List<Ticket>> GetTicketsAsync()
        {
            return _database.Table<Ticket>().ToListAsync();
        }
        public Task<int> SaveListTicketAsync(ListTicket listt)
        {
            if (listt.ID != 0)
            {
                return _database.UpdateAsync(listt);
            }
            else
            {
                return _database.InsertAsync(listt);
            }
        }
        public Task<List<Ticket>> GetListTicketsAsync(int flightlistid)
        {
            return _database.QueryAsync<Ticket>(
            "select T.ID, T.Description from Ticket T"
            + " inner join ListTicket LT"
            + " on T.ID = LT.TicketID where LT.FlightListID = ?",
            flightlistid);
        }

    }
}
    
    



