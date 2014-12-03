using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.CIL_Cowding
{
    public class Container
    {
		// Fields
		private Dictionary<String, IVariable> _var;
		
		
		// Properties
		public Dictionary<String, IVariable> Var 
		{
			get {return _var;}
		}
		
		// Constructor
		public Container() 
		{
			
			_var = new Dictionary<String, IVariable>();
		
		}
		
		// Methodes
		private void CreateVar(IVariable var) 
		{
			
			Var.Add(var.Label, var);
			
		}
		
		public void SetVar(IVariable var) 
		{
		
			if( Var.ContainsKey(var.Label) ) 
			{
				Var[var.Label] = var;
			} 
			else 
			{
				CreateVar(var);
			}
		
		}	
		
		public IVariable GetVar(String label) 
		{
            Variable variablereturn; 
			if(Var.TryGetValue(label, out variablereturn) ) {
				return variablereturn;
			} else {
				throw new Exception("Var dosn't exist...");
			}
            
		}
		
		public bool IsExistVar(String label) 
		{
            IVariable tmp;
			return Var.TryGetValue(label, out tmp);
		}
		
		
		
	
    }
}
