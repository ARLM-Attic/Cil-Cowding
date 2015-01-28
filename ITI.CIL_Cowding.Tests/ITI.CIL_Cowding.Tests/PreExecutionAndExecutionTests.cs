﻿using System;
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
        public void engine_preExecute_correctly()
        {
            string text = System.IO.File.ReadAllText( @"..\..\..\..\Codes IL\code_factoriel.il" );

            IEngine engine = new Engine();
            engine.SourceCode = text;
            engine.Start();
            Assert.That( engine.IsRunning );
            engine.Stop();
        }
        [Test]
        public void label_is_not_an_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That( pec.AddNewClass( "TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs" ) );
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
        public void label_pre_execute_has_correct_instruction_line_number()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext( new CILTypeManager() );

            //Initialize pec
            Assert.That( pec.AddNewClass( "test" ) );
            Assert.That( pec.IsInFunction, Is.False );
            Assert.That( pec.AddNewFunctionToCurrentClass( "toto", pec.TypeManager.Find( "int32" ), new List<ICILType>() ) );
            Assert.That( pec.IsInFunction );

            //Initialize nodes
            NopNode nop = new NopNode( 0 );
            NopNode nop2 = new NopNode( 0 );
            NopNode nop3 = new NopNode( 0 );
            NopNode nop4 = new NopNode( 0 );

            LabelNode label = new LabelNode( "thelabel", 0 );
            LabelNode label2 = new LabelNode( "thelabel2", 0 );
            LabelNode label3 = new LabelNode( "thelabel2", 0 );


            // test it
            label.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 0 );
            nop.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );
            label.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 1 );
            nop2.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 2 );
            nop3.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 3 );
            label2.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 3 );
            nop4.PreExecute( pec );
            Assert.That( pec.CurrentLineInstruction == 4 );

            Assert.That( label.InstructionLineNumber == 0 );
            Assert.That( label2.InstructionLineNumber == 2 );
            /*
             * nop     1
             * label   2
             * nop     2
             * nop     3
             * label   4
             * nop      4
             * 
             * */
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
