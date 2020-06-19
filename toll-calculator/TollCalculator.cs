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

        public decimal CalculateToll(object vehicle) =>
            vehicle switch
            {
                Car c => c.Passengers switch
                {
                    0 => CarToll + 0.5m,
                    1 => CarToll,
                    2 => CarToll - 0.5m,
                    _ => CarToll - 1,
                },
                
                Taxi t => t.Fares switch
                {
                    0 => TaxiToll + 0.5m,
                    1 => TaxiToll,
                    2 => TaxiToll - 0.5m,
                    _ => TaxiToll - 1,
                },

                Bus b when ((double)b.Riders / (double)b.Capacity) < 0.5 => BusToll + 2m,
                Bus b when ((double)b.Riders / (double)b.Capacity) > 0.9 => BusToll - 1m,
                Bus b => BusToll,

                DeliveryTruck dt when (dt.GrossWeightClass > 5000) => DeliveryTruckToll + 5,
                DeliveryTruck dt when (dt.GrossWeightClass < 3000) => DeliveryTruckToll - 2,
                DeliveryTruck dt => DeliveryTruckToll,

                { } => throw new ArgumentOutOfRangeException(message: "This is not one of the supported vehicles!", paramName: nameof(vehicle)),
                null => throw new ArgumentNullException(nameof(vehicle))
            };
    }
}
