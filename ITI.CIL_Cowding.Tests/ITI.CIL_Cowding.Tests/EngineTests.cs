using NUnit.Framework;
using System;
using System.IO;
using ITI.CIL_Cowding;
using System.Collections.Generic;

namespace ITI.CIL_Cowding.Tests
{

    [TestFixture]
    public class UTEngine
    {
        [Test]
        public void engine_creates_all_of_the_functions()
        {

            string txt = File.ReadAllText( @"..\..\..\..\Codes IL\TestFct5.il" );

            IEngine engine = new Engine();

            engine.SourceCode = txt;

            engine.Start();

            Assert.That( engine.IsRunning, Is.True );

            Assert.That( engine.SourceCode != null );

            Assert.That( engine.Pec != null );

            Assert.That( engine.Pec.Classes.ContainsKey( "TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs" ) );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "main" ) );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "Say" ) );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "Say2" ) );

            Assert.That( !engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "UnknownFunction" ) );

            engine.Stop();

        }

        [Test]

        public void engine_creates_all_of_the_labels()
        {

            string txt = File.ReadAllText( @"..\..\..\..\Codes IL\code_factoriel_nop.il" );

            IEngine engine = new Engine();

            List<InstructionNode> lin;

            engine.SourceCode = txt;

            engine.Start();

            Assert.That( engine.IsRunning, Is.True );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "fact" ) );

            lin = engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions["fact"].Body;

            string str = lin[4].ToString();

            Assert.That( str == "ITI.bacASable.BrfalseNode" );

            engine.Stop();

        }

        [Test]

        public void engine_creates_all_local_vars()
        {

            string txt = File.ReadAllText( @"..\..\..\..\Codes IL\code_factoriel_nop.il" );

            IEngine engine = new Engine();

            engine.SourceCode = txt;

            engine.Start();

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "fact" ) );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions["fact"].LocVar.Count == 1 );

            engine.Stop();

        }

        [Test]

        public void engine_creates_all_parameters()
        {

            string txt = File.ReadAllText( @"..\..\..\..\Codes IL\code_factoriel_nop.il" );

            IEngine engine = new Engine();

            engine.SourceCode = txt;

            engine.Start();

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions.ContainsKey( "fact" ) );

            Assert.That( engine.Pec.Classes["TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"].Functions["fact"].ArgVar.Count == 1 );

            engine.Stop();

        }


        [Test]
        public void branch_execution_goto_right_label()
        {
            IEngine engine = new Engine();
            engine.SourceCode = File.ReadAllText( @"..\..\..\..\Codes IL\debug.il" );
            Assert.That( engine.Build() == 0 );
            IExecutionContext ctx = new ExecutionContext( engine.Code, engine );
            
        }
    }

}
