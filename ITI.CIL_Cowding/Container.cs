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
        private IStack _stack;


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
        

        // Ici, à un moment, ça va péter.
        public InstructionNode CurrentInstruction
        {
            get { return Fct.Code[_currentInstruction];  }
        }

		public Container(List<IValue>locvar, List<IValue>args, IFunction fct_reference, IStack stack) 
		{
			_localVars = locvar;
            _args = args;
            _fct = fct_reference;
            _currentInstruction = 0;
             _stack = stack;
        }

        
        #region LocManagment
        // Pas de sécurité sur l'index pour le moment
        public void SetLOCVar(int index, Object val) 
		{
            _localVars[index].Data = val;         
		}

        // Pas de sécurité sur l'index pour le moment
		public IValue GetLOCVar(int index) 
		{
            return _localVars[index];
		}
        #endregion


        #region ArgManagment
        // Pas de sécurité sur l'index pour le moment
        public void SetARGVar(int index, Object val)
        {
             _args[index].Data = val; // wtf cerveau
                    
        }
        // Pas de sécurité sur l'index pour le moment
        public IValue GetARGVar(int index)
        {
            return _args[index];
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


        public void NextInstruction()
        {
            _currentInstruction++;

            if (_currentInstruction >= Fct.Code.Count)
            {
                _stack.CloseFunction();
            }
        }
    }
}
