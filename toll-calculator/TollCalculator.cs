using CommercialRegistration;
using ConsumerVehicleRegistration;
using LiveryRegistration;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace toll_calculator {
    public class TollCalculator {
        public decimal CarToll { get; set; }
        public decimal TaxiToll { get; set; }
        public decimal BusToll { get; set; }
        public decimal DeliveryTruckToll { get; set; }
        public TollCalculator(decimal carToll = 2, decimal taxiToll = 3.5m, decimal busToll = 5, decimal deliveryTruckToll = 10) {
            CarToll = carToll;
            TaxiToll = taxiToll;
            BusToll = busToll;
            DeliveryTruckToll = deliveryTruckToll;
        }

        public decimal Calculate(object vehicle) {
            if (vehicle is Car c) { return CarToll; }
            else if (vehicle is Taxi t) { return TaxiToll; }
            else if (vehicle is Bus b) { return BusToll; }
            else if (vehicle is DeliveryTruck d) { return DeliveryTruckToll; }
            else
                throw new ArgumentOutOfRangeException($"{nameof(vehicle)} is not one of the supported vehicles!");
        }
    }
}
