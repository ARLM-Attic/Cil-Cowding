using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding.Tests
{
    [TestFixture]
    public class NodesTests
    {
        /*
        [Test]
        public void is_ldarg_set_correct_argument()
        {
            // initialize
            IEngine engine = new Engine();
            List<IFunction> file = new List<IFunction>();
            CILTypeManager typeManager = new CILTypeManager();
            List<ICILType> argvars = new List<ICILType>();
            argvars.Add( typeManager.Find( "int" ) );
            file.Add( new Function( "test", typeManager.Find( "void" ), argvars, new List<ICILType>(), new List<InstructionNode>() ) );
            IExecutionContext ctx = new ExecutionContext( file, engine );
            // ldarg
            InstructionNode ldarg = new LdargNode( 0,0 );
            ldarg.Execute( ctx );

            // starg
            //InstructionNode starg = new StargNode(0);
            //starg.Execute( ctx );

        }
        [Test]
        public void NotNode_execute_correctly()
        {
            // initialize
            IEngine engine = new Engine();
            List<IFunction> file = new List<IFunction>();
            CILTypeManager typeManager = new CILTypeManager();
            List<ICILType> argvars = new List<ICILType>();
            argvars.Add( typeManager.Find( "int" ) );
            file.Add( new Function( "test", typeManager.Find( "void" ), argvars, new List<ICILType>(), new List<InstructionNode>() ) );
            IExecutionContext ctx = new ExecutionContext( file, engine );
            ctx.Stack.Push( new Value(typeManager.Find("int"), (int)0 ));
            // not
            InstructionNode not = new NotNode( _tokenizer.CurrentLine );
            not.Execute( ctx );
            IValue value = ctx.Stack.Pop();
            // test
            Assert.That( 1, Is.EqualTo( value.Data ) );

          

        }
        [Test]
        public void ceqnode_compare_correctly()
        {
            CeqNode ceq = new CeqNode();
            CILTypeManager typeManager = new CILTypeManager();
            IValue value1 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value2 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value3 = new Value( typeManager.Find( "int" ), (int)17 );

            IValue result = ceq.Comparator( value1, value2 );
            IValue result2 = ceq.Comparator( value1, value3 );

            Assert.That( result.Data, Is.EqualTo( 1 ) );
            Assert.That( result2.Data, Is.EqualTo( 0 ) );
            Assert.That( result.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
            Assert.That( result2.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
        }
        [Test]
        public void cgtnode_compare_correctly()
        {
            CgtNode cgt = new CgtNode();
            CILTypeManager typeManager = new CILTypeManager();
            IValue value1 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value2 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value3 = new Value( typeManager.Find( "int" ), (int)17 );
            IValue value4 = new Value( typeManager.Find( "int" ), (int)46 );

            IValue result = cgt.Comparator( value1, value2 );
            IValue result2 = cgt.Comparator( value1, value3 );
            IValue result3 = cgt.Comparator( value3, value4 );

            Assert.That( result.Data, Is.EqualTo( 0 ) );
            Assert.That( result2.Data, Is.EqualTo( 1 ) );
            Assert.That( result3.Data, Is.EqualTo( 0 ) );
            Assert.That( result.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
            Assert.That( result2.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
        }
        public void cltnode_compare_correctly()
        {
            CltNode clt = new CltNode();
            CILTypeManager typeManager = new CILTypeManager();
            IValue value1 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value2 = new Value( typeManager.Find( "int" ), (int)25 );
            IValue value3 = new Value( typeManager.Find( "int" ), (int)17 );
            IValue value4 = new Value( typeManager.Find( "int" ), (int)46 );

            IValue result = clt.Comparator( value1, value2 );
            IValue result2 = clt.Comparator( value1, value3 );
            IValue result3 = clt.Comparator( value3, value4 );

            Assert.That( result.Data, Is.EqualTo( 0 ) );
            Assert.That( result2.Data, Is.EqualTo( 0 ) );
            Assert.That( result3.Data, Is.EqualTo( 1 ) );
            Assert.That( result.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
            Assert.That( result2.Type, Is.EqualTo( typeManager.Find( "int" ) ) );
        }
         */
    }
}
