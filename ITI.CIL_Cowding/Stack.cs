using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
        static List<Container> _frame;
        static Stack<IValue> _topFrame;


        /*
         * PROPERTIES
         * */
        // La frame TMP
        public Stack<IValue> TopFrame
        {
            get { return _topFrame; }
        }
        // La frame la plus haute
        public Container LastFrame
        {
            get { return _frame[_frame.Count-1]; }
        }
        // Liste des Containers
        public static List<Container> Frame
        {
            get { return _frame; } 
        }

        // Constructeur
        public Stack() 
		{
            _frame = new List<Container>();
            _topFrame = new Stack<IValue>();
		}


        /*
         * GESTION DES VARIABLES AVEC LA FRAME LA PLUS HAUTE
         * */
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

        public void CreateVar(ICILType type)
        {
            LastFrame.CreateVar(new Value(type,null));
        }

        	
       /*
        * GESTION DE LA TOP_FRAME POP ET PUSH
        * */
        public void Push(IValue var)
        {
            throw new NotImplementedException();
        }

        public IValue Pop()
        {
            throw new NotImplementedException();
        }
        
        /*
         * GESTION DE LA CREATION DES FRAMES
         * */
        public void CallFonction(IFunction fct)
        {
            throw new NotImplementedException();
        }
        public void CloseFunction()
        {
            throw new NotImplementedException();
        }
        

    }

	
}


