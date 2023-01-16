using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Airport.Models
{
    public class ListTicket
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(FlightList))]
        public int FlightListID { get; set; }
        public int TicketID { get; set; }
    }
}
