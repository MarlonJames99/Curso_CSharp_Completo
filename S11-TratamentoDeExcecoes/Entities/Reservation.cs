using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S11_TratamentoDeExcecoes.Entities.Exceptions;

namespace S11_TratamentoDeExcecoes.Entities
{
    class Reservation
    {
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation() { }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
            {
                throw new DomainException("A data de saída deve ser posterior à data de entrada.");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;

            if (CheckIn < now ||  CheckOut < now)
            {
                throw new DomainException("A datas para atualização da reserva devem ser datas futuras.");
            }

            if (checkOut <= checkIn)
            {
                throw new DomainException("A data de saída deve ser posterior à data de entrada.");
            }

            CheckIn = checkIn; 
            CheckOut = checkOut;
        }

        public override string ToString()
        {
            return "Quarto " 
                + RoomNumber 
                + ", Check-in: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", Check-out: "
                + CheckOut.ToString("dd/MM/yyyy")
                + ", "
                + Duration()
                + " noites.";
        }
    }
}
