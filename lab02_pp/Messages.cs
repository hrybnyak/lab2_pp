namespace lab02_pp
{
    public class Messages
    {
        public record LeaveParking(string LicensePlate);

        public record ParkingReceived(string ParkingId, string LicensePlate);

        public record ParkingRejected(string LicencePlate);

        public record ParkingRequested(string LicensePlate);
    }
}