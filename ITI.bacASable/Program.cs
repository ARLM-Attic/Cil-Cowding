using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.bacASable
{
    class Program
    {
        static void Main( string[] args )
        {
            PreExecutionContext pec = new PreExecutionContext();
            LabelNode label = new LabelNode( "thelabel", 2 );
            BrNode br = new BrNode( "thelabel", 3 );
            LdargNode ldarg = new LdargNode( 0, 1 );

            label.PreExecute( pec );
            br.PreExecute( pec );
            ldarg.PreExecute( pec );
            Console.ReadKey();
        }
    }
}
