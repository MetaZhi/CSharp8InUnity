// 需要.NET Core运行环境下

using System;
using System.Collections.Generic;
using System.Linq;

public interface IOrder
{
    DateTime Purchased { get; }
    decimal Cost { get; }
}

public interface ICustomer
{
    IEnumerable<IOrder> PreviousOrders { get; }

    DateTime DateJoined { get; }
    DateTime? LastOrder { get; }
    string Name { get; }
    IDictionary<DateTime, string> Reminders { get; }
    
    /*
    public decimal ComputeLoyaltyDiscount()
    {
        DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
        if ((DateJoined < TwoYearsAgo) && (PreviousOrders.Count() > 10))
        {
            return 0.10m;
        }
        return 0;
    }*/
}
