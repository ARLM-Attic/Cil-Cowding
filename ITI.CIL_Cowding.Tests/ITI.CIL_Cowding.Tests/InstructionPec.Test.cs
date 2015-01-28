using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.CIL_Cowding;
using NUnit.Framework;


namespace ITI.CIL_Cowding.Tests
{
    [TestFixture]
    class InstructionPec
    {
        [Test]
        public void ldstr_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);
            
            //Initialize nodes
            NopNode nop = new NopNode(0);
            LdstrNode Ldstr = new LdstrNode("coucou", 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            Ldstr.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }

        [Test]
        public void ldarg_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);


            //Initialize nodes
            NopNode nop = new NopNode(0);
            LdargNode Ldarg = new LdargNode(1, 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            Ldarg.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }

        [Test]
        public void starg_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);


            //Initialize nodes
            NopNode nop = new NopNode(0);
            StargNode Starg = new StargNode(1, 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            Starg.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }

        [Test]
        public void Ldc_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);


            //Initialize nodes
            NopNode nop = new NopNode(0);
            LdcNode Ldc = new LdcNode(1, 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            Ldc.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }

        [Test]
        public void Ldloc_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);


            //Initialize nodes
            NopNode nop = new NopNode(0);
            LdlocNode Ldloc = new LdlocNode(1, 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            Ldloc.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }

        [Test]
        public void Stloc_are_instruction()
        {
            // Initialize components
            PreExecutionContext pec = new PreExecutionContext(new CILTypeManager());

            //Initialize pec
            Assert.That(pec.AddNewClass("TheOnlyOneClassInThisOPProgramBecauseWeAreNoobs"));
            Assert.That(pec.IsInFunction, Is.False);
            Assert.That(pec.AddNewFunctionToCurrentClass("toto", pec.TypeManager.Find("int32"), new List<ICILType>()));
            Assert.That(pec.IsInFunction);


            //Initialize nodes
            NopNode nop = new NopNode(0);
            StlocNode stloc = new StlocNode(1, 0);

            // test it
            nop.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 1);

            stloc.PreExecute(pec);
            Assert.That(pec.CurrentLineInstruction == 2);

            IFunction function = pec.EndCurrentFunction();
            Assert.That(function.Body.Count == 2);
            Assert.That(pec.IsInFunction, Is.False);

            pec.EndNewClass();
            pec.GetFinalProgram();
        }
    }
}
