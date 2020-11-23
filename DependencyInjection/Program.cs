using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Context context = new Context();
            StartState startState = new StartState();
            startState.doAction(context);
            Console.WriteLine(context.GetState().ToString());

            StopeState stopeState = new StopeState();
            stopeState.doAction(context);
            Console.WriteLine(context.GetState().ToString());
        }
    }
}
