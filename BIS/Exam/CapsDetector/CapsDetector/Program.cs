using System;

namespace CapsDetector
{
    internal class Program
    {
        static void Main()
        {
            var state = Console.CapsLock ? CapsState.OFF : CapsState.ON;
            do
            {
                var curState = Console.CapsLock ? CapsState.ON : CapsState.OFF;
                if (curState != state)
                {
                    state = curState;
                    Console.WriteLine(state.ToString());
                }
            } 
            while (true);
        }

        enum CapsState { ON, OFF }
    }
}
