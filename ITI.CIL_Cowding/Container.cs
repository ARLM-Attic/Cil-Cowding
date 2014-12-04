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
		private Dictionary<String, Variable> _var;
		
		
		// Properties
		public Dictionary<String, Variable> Var 
		{
			get {return _var;}
		}
		
		// Constructor
		public Container() 
		{
			
			_var = new Dictionary<String, Variable>();
		
		}
		
		// Methodes
		private void CreateVar(Variable var) 
		{
			
			Var.Add(var.Label, var);
			
		}
		
		public void SetVar(Variable var) 
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
            Variable tmp;
			return Var.TryGetValue(label, out tmp);
		}
		
		
		
	
    }
}
