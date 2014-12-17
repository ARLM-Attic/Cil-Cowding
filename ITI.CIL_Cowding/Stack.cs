using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
        List<Container> _frame;
        Stack<IValue> _topFrame;
        

        #region Properties
        // La frame TMP
        public Stack<IValue> TopFrame
        {
            get { return _topFrame; }
        }
        /// <summary>
        /// Get the highest frame
        /// </summary>
        public Container LastFrame
        {
            get { return _frame[_frame.Count-1]; }
        }
        /// <summary>
        /// Get Containers list ( all frames)
        /// </summary>
        public List<Container> Frame
        {
            get { return _frame; } 
        }
        #endregion
        /// <summary>
        /// Create a call stack.
        /// </summary>
        public Stack() 
		{
            _frame = new List<Container>();
            _topFrame = new Stack<IValue>();
		}


        #region Variables managment with highest frame
        public IValue GetLocalVar( int index )
        {
            Container frame = LastFrame;
            return frame.GetLOCVar( index );
        }
        
        public void SetLocalVar( IValue var , int index)
        {
            Container frame = LastFrame;
            frame.SetLOCVar( index, var );
        }
        
        #endregion
        


        #region Arguments managment with hihgest frame
        public IValue GetArgVar(int index)
        {
            Container frame = LastFrame;
            return frame.GetARGVar(index);
        }

        public void SetArgVar(int index, IValue var)
        {
            Container frame = LastFrame;
            frame.SetARGVar(index, var);
        }
        #endregion
       


        #region Pop and Push managment on top frame
        public void Push(IValue var)
        {
            _topFrame.Push(var);
            // C'est tout ?
        }

        public IValue Pop()
        {
            return _topFrame.Pop();
        }
        #endregion
        


        #region Frames managment
        
        public void CallFunction(IFunction fct)
        {
            List<IValue> locvars = new List<IValue>();
            List<IValue> parameters = new List<IValue>();


            // On créer tout ce qu'il faut pour faire un container
            // Variables locales, que l'on trouve dans la définition de la fct
            foreach(var locvar in fct.LocVar) 
            {
                locvars.Add(new Value(locvar , null));
            }

            // Paramètres, que l'on trouve sur la stack
            do{
                parameters.Add(TopFrame.Pop());
            }while(TopFrame.Count >= 0);

            _frame.Add(new Container(locvars, parameters, fct));


        }
        
        public void CloseFunction()
        {
            _frame.RemoveAt(_frame.Count - 1);
            // C'est uniquement ça nan ? 
        }
        
        #endregion

    }

	
}


