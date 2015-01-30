using System;

namespace ITI.CIL_Cowding
{
    /// <summary>
    /// Push 1 (of type int32) if value1 equals value2, else push 0.
    /// </summary>
    public class CeqNode : BinaryComparatorNode
    {
       
        public CeqNode(int line)
            : base( line )
        {
        }
        public override IValue Comparator( IValue value1, IValue value2 )
        {
            {
                if ( !String.IsNullOrWhiteSpace( value2.Data.ToString() ) && !String.IsNullOrWhiteSpace( value1.Data.ToString() ) )
                {
                    if ( value1.Type.FullName == "System.Int32" )
                    {
                        if ( (int)value1.Data == (int)value2.Data )
                        {
                            return new Value( value1.Type, 1 );
                        }
                        else
                        {
                            return new Value( value1.Type, 0 );
                        }
                    }
                    else if ( value1.Type.FullName == "System.Double" )
                    {
                        if ( (double)value1.Data == (double)value2.Data )
                        {
                            return new Value( value1.Type, 1.0 );
                        }
                        else
                        {
                            return new Value( value1.Type, 0.0 );
                        }
                    }
                }
                else
                {
                    return new Value( value1.Type, 0 );
                }
                return new Value( value1.Type, 0 );
            }
        }
    }
}
