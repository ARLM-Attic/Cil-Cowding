using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
  
    public class Container
    {
		private List<IValue> _localVars;
        private List<IValue> _args;

		public List<IValue> LocalVars
		{
			get {return _localVars;}
		}
        public List<IValue> ArgsVars
        {
            get { return _args;}
        }
        
		
		public Container() 
		{
			_localVars = new List<IValue>();
            _args = new List<IValue>();
        }
		
        /*
         * GESTION DES VARIABLES LOCALES
         *  */
		public void CreateVar(IValue var) 
		{
			_localVars.Add(var);
		}
		
		public void SetLOCVar(int index, IValue val) 
		{
            // faut ajouter l'index en fait /!\/!\/!\/!\/!\/!\/!\/!\/!\
			if( _localVars.Contains(val) )
			{
                for ( int i = 0 ; i < _localVars.Count ; i++ )
                {
                    if ( _localVars[i] == val )
                    {
                        _localVars[i] = val; // wtf cerveau
                    }
                }
			} 

           

		
		}	
		
		public IValue GetLOCVar(int index) 
		{
            return _localVars[index];
		}

        /*
         * GESTION DES VARIABLES ARGUMENTS
         * */
        public void SetARGVar(int index, IValue val)
        {
            // faut ajouter l'index en fait /!\/!\/!\/!\/!\/!\/!\/!\/!\
            if (_localVars.Contains(val))
            {
                for (int i = 0; i < _localVars.Count; i++)
                {
                    if (_localVars[i] == val)
                    {
                        _localVars[i] = val; // wtf cerveau
                    }
                }
            }




        }

        public IValue GetARGVar(int index)
        {
            return _localVars[index];
        }
        
        /* 
         * Sécurité histoire de savoir si on ne fait pas de la merde
         * */
        public bool IsExistVarLOC(int index)
        {
            return index <= LocalVars.Count - 1 && index >= 0 ;
        }
        
        public bool IsExistVarARG(int index)
        {
            return index <= ArgsVars.Count - 1 && index >=0;
        }
		
    }
}
