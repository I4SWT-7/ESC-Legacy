using System;

namespace ECS.Legacy
{
    public class FakeHeater : IHeater
    {
        public bool BoolTurnOn { get; set; }
        public bool BoolTurnOff { get; set; }

        public FakeHeater()
        {
            BoolTurnOn = false;
            BoolTurnOff = false;
        }

        public void TurnOn()
        {
            BoolTurnOn = true;
        }

        public void TurnOff()
        {
            BoolTurnOff = true;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}