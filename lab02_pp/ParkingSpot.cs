namespace lab02_pp
{
    public class ParkingSpot
    {
        public string Id { get; }
        public string CarLicensePlate
        {
            get => _carLicensePlate;
            set
            {
                _carLicensePlate = value;
                IsBusy = _carLicensePlate != null;
            }
        }
        public bool IsBusy { get; private set; } 
        private string _carLicensePlate;

        public ParkingSpot(string id)
        {
            Id = id;
        }
    }
}