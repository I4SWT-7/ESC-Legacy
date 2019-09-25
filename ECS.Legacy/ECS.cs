namespace ECS.Legacy
{
    public class ECS
    {
        private int _threshold1;
        private int _threshold2;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public ECS(int thr1, int thr2, ITempSensor temp, IHeater heater)
        {
            SetThreshold(thr1, thr2);
            _tempSensor = temp;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            if (t < _threshold1)
                _heater.TurnOn();
            else if
                (t > _threshold2)
                _heater.TurnOff();

        }

        public void SetThreshold(int thr1, int thr2)
        {
            _threshold1 = thr1;
            _threshold2 = thr2;
        }

        public int GetThreshold1()
        {
            return _threshold1;
        }
        public int GetThreshold2()
        {
            return _threshold2;
        }
        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
