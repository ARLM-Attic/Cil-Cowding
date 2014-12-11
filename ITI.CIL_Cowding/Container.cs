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

		public List<IValue> LocalVars
		{
			get {return _localVars;}
		}
		
		public Container() 
		{
			_localVars = new List<IValue>();
		}
		
		private void CreateVar(IValue var) 
		{
			_localVars.Add(var);
		}
		
        /// <summary>
        /// If var don't exist, CreateVar() is called
        /// </summary>
        /// <param name="var"></param>
		public void SetVar(IValue var) 
		{
            // faut ajouter l'index en fait /!\/!\/!\/!\/!\/!\/!\/!\/!\
			if( _localVars.Contains(var) )
			{
                for ( int i = 0 ; i < _localVars.Count ; i++ )
                {
                    if ( _localVars[i] == var )
                    {
                        _localVars[i] = var; // wtf cerveau
                    }
                }
			} 
			else 
			{
				CreateVar(var);
			}
		
		}	
		
		public IValue GetVar(int index) 
		{
            return _localVars[index];
            // gérer l'erreur d'index ? OutOfRangeExeption ? Try Catch ?
            
            /*if( _localVars.TryGetValue(label, out variablereturn ) ) 
            {
				return variablereturn;
			} else 
            {
				throw new Exception("_localVars doesn't exist...");
			}
            */
		}
		/*
		public bool IsExistVar(String label) 
		{
            Variable tmp;
			return _localVars.TryGetValue(label, out tmp);
		}
		*/
    }
}
