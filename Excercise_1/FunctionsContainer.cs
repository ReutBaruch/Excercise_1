using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double funcDelegate(double num);

    class FunctionsContainer
    {
        Dictionary<string, funcDelegate> funcDictionary = new Dictionary<string, funcDelegate>();

        // returns all the missions names as a list
        public List<string> getAllMissions()
        {
            return this.funcDictionary.Keys.ToList();
        }

        public funcDelegate this[string index]
        {
            get
            {
                // if the value is not in the dictionary then we add a func that returns the value
                if (!funcDictionary.ContainsKey(index))
                {
                    funcDictionary.Add(index, num => num);
                }
                return funcDictionary[index];
            } // end of get

            set
            {
                // if the value is in the dictionary then we change the value
                if (funcDictionary.ContainsKey(index))
                {
                    funcDictionary[index] = new funcDelegate(value);
                }
                // if the value is not in the dictionary then we add it
                else
                {
                    funcDictionary.Add(index, new funcDelegate(value));
                }
            } // end of set
        }
    }
}
