using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.model
{
    public class Booking
    {
        private int _id;
        private DateTime _bookingDate;
        private TimeSpan _bookingTime;
        private string _personPhone;
        private int _bowlingAlley;

        public Booking()
        {
        }

        public Booking(int id, DateTime bookingDate, TimeSpan bookingTime, string personPhone, int bowlingAlley)
        {
            _id = id;
            _bookingDate = bookingDate;
            _bookingTime = bookingTime;
            _personPhone = personPhone;
            _bowlingAlley = bowlingAlley;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime BookingDate
        {
            get => _bookingDate;
            set => _bookingDate = value;
        }

        public TimeSpan BookingTime
        {
            get => _bookingTime;
            set => _bookingTime = value;
        }

        public string PersonPhone
        {
            get => _personPhone;
            set => _personPhone = value;
        }

        public int BowlingAlley
        {
            get => _bowlingAlley;
            set => _bowlingAlley = value;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(BookingDate)}: {BookingDate.ToString("d")}, {nameof(BookingTime)}: {BookingTime.Hours}:{BookingTime.Minutes}, {nameof(PersonPhone)}: {PersonPhone}, {nameof(BowlingAlley)}: {BowlingAlley}";
        }
    }
}
