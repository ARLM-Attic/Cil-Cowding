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
        private IFunction _fct;
        private int _currentInstruction;


		public List<IValue> LocalVars
		{
			get {return _localVars;}
		}
        public List<IValue> ArgsVars
        {
            get { return _args;}
        }
        public IFunction Fct
        {
            get { return _fct; }
        }
        public InstructionNode CurrentInstruction
        {
            get { return Fct.Code[_currentInstruction++]; }
        }

		public Container(List<IValue>locvar, List<IValue>args, IFunction fct_reference) 
		{
			_localVars = locvar;
            _args = args;
            _fct = fct_reference;
            _currentInstruction = 0;
        }

        
        #region LocManagment
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
        #endregion


        #region ArgManagment
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
        #endregion
        

        #region IsExist ?
        public bool IsExistVarLOC(int index)
        {
            return index <= LocalVars.Count - 1 && index >= 0 ;
        }
        
        public bool IsExistVarARG(int index)
        {
            return index <= ArgsVars.Count - 1 && index >=0;
        }
        #endregion
    }
}
