using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class CILTypeManager
    {
        readonly Dictionary<string, ICILType> _types;

        public CILTypeManager()
        {
            _types = new Dictionary<string, ICILType>();

            Add( new CILNetType( typeof( Int32 ) ) );
            Add( new CILNetType( typeof( UInt32 ) ) );
            Add( new CILNetType( typeof( Int64 ) ) );
            Add( new CILNetType( typeof( UInt64 ) ) );
            Add( new CILNetType( typeof( Int16 ) ) );
            Add( new CILNetType( typeof( UInt16 ) ) );
            Add( new CILNetType( typeof( SByte ) ) );
            Add( new CILNetType( typeof( Byte ) ) );
            Add( new CILNetType( typeof( Double ) ) );
            Add( new CILNetType( typeof( Single ) ) );
            Add( new CILNetType( typeof( Boolean ) ) );
            Add( new CILNetType( typeof( DateTime ) ) );
            Add( new CILNetType( typeof( Guid ) ) );
            Add( new CILNetType( typeof( char ) ) );
            Add( new CILNetType( typeof( string ) ) );
        }

        void Add( ICILType type )
        {
            _types.Add( type.FullName, type );
        }

        /*
        public void CreateNewType (ICILType name)
        {
            Add( new CILUserType( name ) );
        }
        */

    }
}
