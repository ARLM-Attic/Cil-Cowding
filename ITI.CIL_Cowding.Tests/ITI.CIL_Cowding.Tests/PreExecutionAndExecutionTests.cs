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
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That( pec.AddNewClass( "TheOnlyOneClassInThisOPProgram" ) );
            Assert.That( pec.IsInFunction, Is.False );
            Assert.That( pec.AddNewFunctionToCurrentClass( "toto", pec.TypeManager.Find("int32"), new List<ICILType>() ) );
            Assert.That( pec.IsInFunction );

            //Initialize nodes
            NopNode nop = new NopNode( 0 );
            LabelNode label = new LabelNode( "thelabel", 0 );

            // test it
            nop.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );

            label.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );

            IFunction function = pec.EndCurrentFunction();
            Assert.That( function.Body.Count == 1 );
            Assert.That( pec.IsInFunction, Is.False );

            pec.EndNewClass();
            pec.GetFinalProgram();
        }
        [Test]
        public void label_is_not_an_instruction_test_with_program_but_cant_test_know_this_test_is_useless_imo()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext( new CILTypeManager() );

            //Initialize pec
            Assert.That( pec.AddNewClass( "TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs" ) );
            Assert.That( pec.IsInFunction, Is.False );

            //Initialize nodes
            NopNode nop = new NopNode( 0 );
            LabelNode label = new LabelNode( "thelabel", 0 );

            // Create function body
            List<Node> body = new List<Node>();
            body.Add( nop );
            body.Add( label );

            FunctionNode functionNode = new FunctionNode( "toto", "int32", body, new List<string>(), 0 );

            functionNode.PreExecute( pec );

            CILClass cilClass = pec.EndNewClass();
            CILProgram cilProgram = pec.GetFinalProgram();

            Assert.That( cilProgram.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions["toto"].Body.Count == 1 );
            //same as
            Assert.That( cilClass.Functions["toto"].Body.Count == 1 );

            Assert.That( pec.IsInFunction, Is.False );

        }

    }
}
