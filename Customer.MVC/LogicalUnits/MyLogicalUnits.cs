using System;
using Gold.Core.Components;
using Gold.Core.Events;
using Gold.Core.Interfaces;

namespace Customer.MVC.LogicalUnits
{
    public class MyLogicalUnit : LogicalUnit
    {
        public override IComponent GetNextComponent(IComponentEventArgs componentEventArgs)
        {
            var johnSmith = new Models.Customer() { Id = 1, Name = "John Smith" };
            var jsonString = GoldServices.TaskManager.ObjectToJson(johnSmith);
            return null;
        }
    }

    //public class MyLogicalUnit1 : ILogicalUnit
    //{
    //    private readonly IGoldServices _goldServices;
    //    public MyLogicalUnit1(IGoldServices goldServices)
    //    {
    //        _goldServices = goldServices;
    //    }
    //    public int TaskId { get; set; }
    //    public string ClientRef { get; set; }
    //    public IComponent GetNextComponent(IComponentEventArgs componentEventArgs)
    //    {
    //        var johnSmith = new Models.Customer() { Id = 1, Name = "John Smith" };
    //        var jsonString = _goldServices.TaskManager.ObjectToJson(johnSmith);
    //        return null;
    //    }

    //}

    //public class MyLogicalUnit2 : AbstractLogicalUnitV2
    //{
    //    public MyLogicalUnit2(IGoldServices goldServices) : base(goldServices)
    //    {
    //    }
    //    public override IComponent GetNextComponent(IComponentEventArgs componentEventArgs)
    //    {
    //        var johnSmith = new Models.Customer() { Id = 1, Name = "John Smith" };
    //        var jsonString = GoldServices.TaskManager.ObjectToJson(johnSmith);
    //        return null;
    //    }
    //}

}