using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class StartState:IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("player is in start state");
            context.setState(this);
        }

        public String toString()
        {
            return "start state";
        }
    }
}
