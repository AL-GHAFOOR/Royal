using System;

namespace GHospital_Care.DAL.Model
{
    public class IPDBedHistory
    {

        public int Id { get; set; }
        public string BedorCabin { get; set; }
        public string PatientID { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime Todate { get; set; }
        public DateTime TransferDate { get; set; }
        public Decimal Rate { get; set; }
        public Decimal DayQty { get; set; }
        public TimeSpan TransferTime { get; set; }

       public string UserId { get; set; }

    }
}