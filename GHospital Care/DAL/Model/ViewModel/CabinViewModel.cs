namespace GHospital_Care.DAL.Model.ViewModel
{
    class CabinViewModel
    {
        public int Sl { get; set; }
        public int Id { get; set; }
        public string CabinName { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int FloorId { get; set; }
        public string FloorName { get; set; }
    }
}
