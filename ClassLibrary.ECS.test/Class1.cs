using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ECS.Legacy;

namespace ClassLibrary.ECS.test
{
    [TestFixture]
    public class Class1
    {
        private global::ECS.Legacy.ECS _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;


        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            _uut = new global::ECS.Legacy.ECS(25,28, _tempSensor, _heater);
        }

        [Test]
        public void RunSelfTest_TempSensorFails_SelfTestFails()
        {
            _tempSensor.RunSelfTest().Returns(false);
            _heater.RunSelfTest().Returns(true);
            Assert.IsFalse(_uut.RunSelfTest());
        }
        [Test]
        public void Regulate_TempBelowThreshold_HeaterTurnedOn()
        {
            _tempSensor.GetTemp().Returns(_uut.GetThreshold1()-10);
            _uut.Regulate();
            _heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempAboveThreshold_HeaterTurnedOff()
        {
            _tempSensor.GetTemp().Returns(_uut.GetThreshold2() + 1);
            _uut.Regulate();
            _heater.Received(1).TurnOff();
        }

    }

}
