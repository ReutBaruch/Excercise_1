using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private string missionName;
        private string missionType;
        private funcDelegate funcD;
        public event EventHandler<double> OnCalculate; // An Event of when a mission is activated

        public SingleMission(funcDelegate func, string name)
        {
            this.funcD = func;
            this.missionType = "Single";
            this.missionName = name;
        }

        public String Name { get { return missionName; } }
        public String Type { get { return missionType; } }

        public double Calculate(double value)
        {
            //calculate the result
            double result = funcD(value);

            //invoke the event
            OnCalculate?.Invoke(this, result);

            return result;
        }
    }
}
