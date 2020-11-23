using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class Context
    {
        private IState state;
        public Context() {
            state = null;
        }

        public void setState(IState state)
        {
            this.state = state;
        }

        public IState GetState()
        {
            return state;
        }
    }
}
