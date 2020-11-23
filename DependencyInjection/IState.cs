using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IState
    {
        void doAction(Context context);
    }
}
