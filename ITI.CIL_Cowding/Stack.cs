using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Stack : IStack 
    {
        List<Container> _frame;
        Stack<IValue> _topFrame;
        IEngine _engine;
        

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
            get 
            {
                if (_frame.Count == 0) { return null; }
                return _frame[_frame.Count-1]; 
            }
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
        public Stack(IEngine engine) 
		{
            _frame = new List<Container>();
            _topFrame = new Stack<IValue>();
            _engine = engine;
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

            List<ICILType> fct_param = fct.ArgVar;


            // On créer tout ce qu'il faut pour faire un container
            // Variables locales, que l'on trouve dans la définition de la fct
            foreach(var locvar in fct.LocVar) 
            {
                locvars.Add(new Value(locvar , null));
            }

            // Paramètres, que l'on trouve sur la stack
            int i = 0;

            while(i < fct_param.Count) {

                // On choppe le paramètre
                IValue tmp;

                try
                {
                    tmp = TopFrame.Pop();
                }
                catch (Exception e)
                {
                    _engine.ClashError(new RunTimeError(_engine, "Pas assez de paramètre"));
                    return;
                }
                // On regarde si le type correspond avec celui de la fct
                if (tmp.Type.FullName == fct_param[i].FullName)
                {
                    parameters.Add(tmp);

                }
                else
                {
                    _engine.ClashError(new RunTimeError(_engine, "Error with type params") );
                }
                i++;
            }            
            
            _frame.Add(new Container(locvars, parameters, fct, this));



        }
        
        public void CloseFunction()
        {
            if(_frame.Count -1 < 0) {
                throw new NotImplementedException("Là on doit finir le programme :D");
            }
            _frame.RemoveAt(_frame.Count - 1);
            // C'est uniquement ça nan ? 
        }
        
        #endregion

    }

	
}


