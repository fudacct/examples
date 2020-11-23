using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class Boy
    {
        private IState state;
        public Boy()
        {
            state = null;
        }

        public void setState(IState state)
        {
            this.state = state;
        }
        public void play(string action)
        { 
        }
    }
}
