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

            Add( new CILNetType( typeof( Int32 ) ), "int" );
            Add( new CILNetType( typeof( UInt32 ) ), "uint" );
            Add( new CILNetType( typeof( Int64 ) ), "long" );
            Add( new CILNetType( typeof( UInt64 ) ), "ulong" );
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
        public void AddUsing( string nameSpace )
        {
            if ( string.IsNullOrWhiteSpace( nameSpace ) )
            {
                throw new ArgumentException();
            }
            if ( nameSpace[nameSpace.Length - 1] != '.' )
            {
                nameSpace += '.';
            }
            if ( !this._namespaces.Contains( nameSpace ) )
            {
                this._namespaces.Add( nameSpace );
            }
        }
        public void ClearUsings()
        {
            this._namespaces.Clear();
        }
        public ICILType Find( string typeName )
        {
            ICILType t;
            if ( !this._types.TryGetValue( typeName, out t ) )
            {
                foreach ( string ns in this._namespaces )
                {
                    if ( this._types.TryGetValue( ns + typeName, out t ) )
                    {
                        break;
                    }
                }
            }
            return t;
        }
        private void Add( ICILType type, params string[] aliases )
        {
            this._types.Add( type.FullName, type );
            for ( int i = 0 ; i < aliases.Length ; i++ )
            {
                string a = aliases[i];
                this._types.Add( a, type );
            }
        }

        /*
        public void CreateNewType (ICILType name)
        {
            Add( new CILUserType( name ) );
        }
        */

    }
}
