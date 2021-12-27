using System.Collections.Generic;
using System.Linq;
using Akka.Actor;

namespace lab02_pp
{
    public class ParkingActor : ReceiveActor
    {
        private readonly List<ParkingSpot> _parkingSpots = new List<ParkingSpot>();

        public ParkingActor(int numberOfSpots)
        {
            for (int i = 1; i <= numberOfSpots; i++)
            {
                _parkingSpots.Add(new ParkingSpot(i.ToString()));
            }
            
            Receive<Messages.ParkingRequested>(message =>
            {
                var parking = _parkingSpots.FirstOrDefault(x => !x.IsBusy);
                if (parking != null)
                {
                    
                    parking.CarLicensePlate = message.LicensePlate;
                    Sender.Tell(new Messages.ParkingReceived(parking.Id, parking.CarLicensePlate));
                }
                else
                {
              
                    Sender.Tell(new Messages.ParkingRejected(message.LicensePlate));
                }
            });
            
            Receive<Messages.LeaveParking>(message =>
            {
                var parking = _parkingSpots.FirstOrDefault(x => x.CarLicensePlate == message.LicensePlate);
                if (parking != null) parking.CarLicensePlate = null;
            });
        }
    }
}