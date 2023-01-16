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

    }
}
