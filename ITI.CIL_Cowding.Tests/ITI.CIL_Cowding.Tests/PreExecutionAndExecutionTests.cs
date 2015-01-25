using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.bacASable;
using NUnit.Framework;

namespace ITI.Tests
{
    [TestFixture]
    public class PreExecutionAndExecutionTests
    {
        [Test]
        public void label_is_not_an_instruction()
        {
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());
            CILTypeManager typeManager = new CILTypeManager();
            Assert.That( pec.IsInFunction, Is.False );
            Assert.That( pec.AddNewFunctionToCurrentClass( "toto", typeManager.Find("int32"), new List<ICILType>() ) );
            Assert.That( pec.IsInFunction );
            NopNode nop = new NopNode( 0 );
            LabelNode label = new LabelNode( "thelabel", 0 );

            nop.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );

            label.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );

            IFunction function = pec.EndCurrentFunction();
            Assert.That( function.Body.Count == 1 );
            Assert.That( pec.IsInFunction, Is.False );
        }

    }
}
