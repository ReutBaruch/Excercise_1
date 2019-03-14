using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    class ComposedMission : IMission
    {
        private string missionName;
        private string missionType;
        private List<funcDelegate> funcList;

        public String Name { get { return missionName; } }
        public String Type { get { return missionType; } }

        public event EventHandler<double> OnCalculate; // An Event of when a mission is activated

        public ComposedMission(string name)
        {
            this.funcList = new List<funcDelegate>();
            this.missionName = name;
            this.missionType = "Composed";
        }

        public double Calculate(double value)
        {
            double result = value;

            //we will calculate a result for one func and then send its result to the next func
            foreach (funcDelegate f in funcList)
            {
                result = f(result);
            }

            //invoke the event
            OnCalculate?.Invoke(this, result);

            return result;
        } //end of Calculate

        public ComposedMission Add(funcDelegate func)
        {
            this.funcList.Add(func);

            return this;
        }
    }
}
