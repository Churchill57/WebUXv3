using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gold.Core.Attributes;
using Gold.Core.Components;
using Gold.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gold.Core.Tests.Components
{
    [TestClass]
    public class ComponentStateHandlerTests
    {
        public class MyComponentWithState
        {
            public class MyCustomClass
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public DateTime DOB { get; set; }
            }

            [ComponentState]
            public int IntegerState { get; set; }

            [ComponentState]
            internal string StringState { get; set; }

            [ComponentState]
            internal MyCustomClass ObjectState { get; set; }

            [ComponentState]
            private string PrivateStringState { get; set; } = "private string value";
        }

        private class MyComponentWithoutState
        {
            public int IntegerNotState { get; set; }
            public string StringNotState { get; set; }
        }

        private class MyComponentWithInheritedState : MyComponentWithState
        {
            [ComponentState]
            internal int MoreIntegerState { get; set; }

            private string StringNotState { get; set; } = "string not state";

        }

        private readonly IComponentStateHandler _target = new ComponentStateHandler();

        [TestMethod]
        public void GetStateMyComponentWithState()
        {
            var obj = new MyComponentWithState();
            obj.IntegerState = 99;
            obj.StringState = "Hello world";
            obj.ObjectState = new MyComponentWithState.MyCustomClass() { Id = 5, Name = "foo", DOB = new DateTime(1990, 12, 31) };

            var state = new ComponentState();
            _target.GetState(obj, state);

            Assert.AreEqual(obj.IntegerState, state["IntegerState"]);
            Assert.AreEqual(obj.StringState, state["StringState"]);
            Assert.AreEqual(obj.ObjectState, state["ObjectState"]);
            Assert.IsTrue(state.ContainsKey("PrivateStringState"));
        }

        [TestMethod]
        public void GetStateMyComponentWithoutState()
        {
            var obj = new MyComponentWithoutState();
            obj.IntegerNotState = 98;
            obj.StringNotState = "Hello moon";

            var state = new ComponentState();
            _target.GetState(obj, state);

            Assert.AreEqual(0, state.Count);

        }

        [TestMethod]
        public void GetStateMyComponentWithInheritedState()
        {
            var obj = new MyComponentWithInheritedState();
            obj.IntegerState = 97;
            obj.StringState = "Hello venus";
            obj.ObjectState = new MyComponentWithState.MyCustomClass() { Id = 8, Name = "bar", DOB = new DateTime(2017, 12, 31) };
            obj.MoreIntegerState = 77;

            var state = new ComponentState();
            _target.GetState(obj, state);

            Assert.AreEqual(obj.IntegerState, state["IntegerState"]);
            Assert.AreEqual(obj.StringState, state["StringState"]);
            Assert.AreEqual(obj.ObjectState, state["ObjectState"]);
            Assert.AreEqual(obj.MoreIntegerState, state["MoreIntegerState"]);

        }


    }
}
