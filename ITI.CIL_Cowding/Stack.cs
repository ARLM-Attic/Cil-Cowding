using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
        static List<Container> _frame;
        static Stack<IValue> _topFrame;

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
        public static List<Container> Frame
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
        public void CreateVar( ICILType type )
        {
            LastFrame.CreateVar( new Value( type, null ) );
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
            throw new NotImplementedException();
        }

        public IValue Pop()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Frames creation managment
        public void CallFunction(IFunction fct)
        {
            throw new NotImplementedException();
        }
        public void CloseFunction()
        {
            throw new NotImplementedException();
        }
        #endregion

    }

	
}


