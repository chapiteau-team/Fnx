using System.Collections.Generic;
using Fnx.Core.DataTypes;
using static Fnx.Core.Prelude;

namespace Fnx.Core.Examples
{
    struct UserDetails
    {
    }

    struct Order
    {
    }

    struct Shipment
    {
    }

    struct Report
    {
    }

    static class UserRepository
    {
        public static Option<UserDetails> GetUserDetails(int userId) => Some(new UserDetails());
    }

    static class OrderRepository
    {
        public static Option<List<Order>> GetOrders() => Some(new List<Order>());
    }

    static class ShipmentRepository
    {
        public static Option<List<Shipment>> GetShipments() => Some(new List<Shipment>());
    }

    static class ReportManager
    {
        public static Report MakeReport(UserDetails userDetails, List<Order> orders, List<Shipment> shipments) =>
            new Report();
    }
}