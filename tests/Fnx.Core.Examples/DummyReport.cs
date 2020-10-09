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

    enum Error
    {
        NotFound,
        NoAccess,
    }

    struct Report
    {
    }

    static class UserRepository
    {
        public static Result<UserDetails, Error> GetUserDetails(int userId) => Ok(new UserDetails());
    }

    static class OrderRepository
    {
        public static Result<List<Order>, Error> GetOrders(int userId) => Ok(new List<Order>());
    }

    static class ShipmentRepository
    {
        public static Result<List<Shipment>, Error> GetShipments(int userId) => Ok(new List<Shipment>());
    }

    static class ReportManager
    {
        public static Report MakeReport(UserDetails userDetails, List<Order> orders, List<Shipment> shipments) =>
            new Report();
    }
}