using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace toll_calculator {
    public class TollCalculator {
        public double CarToll { get; set; }
        public double TaxiToll { get; set; }
        public double BusToll { get; set; }
        public double DeliveryTruckToll { get; set; }
        public TollCalculator(double carToll = 2, double taxiToll = 3.5, double busToll = 5, double deliveryTruckToll = 10) {
            CarToll = carToll;
            TaxiToll = taxiToll;
            BusToll = busToll;
            DeliveryTruckToll = deliveryTruckToll;
        }

        public double Calculate(object vehicle) {
            if (vehicle is Car c) { return CarToll; }
            else if (vehicle is Taxi t) { return TaxiToll; }
            else if (vehicle is Bus b) { return BusToll; }
            else if (vehicle is DeliveryTruck d) { return DeliveryTruckToll; }
            else
                throw new ArgumentOutOfRangeException($"{nameof(vehicle)} is not one of the supported vehicles!");
        }
    }
}
