namespace ECS.Legacy
{
    class FakeTempSensor : ITempSensor
    {
        public bool GetTempCalled { get; set; }

        public FakeTempSensor()
        {
            GetTempCalled = false;
        }

        public int GetTemp()
        {
            GetTempCalled = true;
            return 0;
        }

        public bool RunSelfTest()
        {
            if (GetTempCalled == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}