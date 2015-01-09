using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Do nothing, but do it like a boss
    /// </summary>
    public class NopNode : InstructionNode
    {
        public override void Execute(IExecutionContext ctx)
        {
            // Il était une fois, un petit qui n'avait rien n'a faire. Il était tellement malheureux, du coup il voulait au moins faire chauffer le processeur des gens pour le délire.
            for (int i = 0; i < 100000; i++ )
            {
                Console.WriteLine("Nop :'(");
            }
        }
    }
}
