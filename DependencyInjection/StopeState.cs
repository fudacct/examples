using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class StopeState :IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("player is in stop state");
            context.setState(this);
        }
        public string toString() {
            return "Stop State";
        }
    }
}
