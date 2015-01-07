using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;

namespace ITI.CIL_Cowding
{
    public class Engine : IEngine
    {
        // Fields
        // Support exec
        StringTokenizer _strTok;    
        Analyzer _analyzer;
        List<FunctionNode> _tree;
        List<IFunction> _code;
        List<IError> _syntaxErrors;

        // Execution
        IPreExecutionContext _pec;
        IExecutionContext _ctx;
        
        // Gestion du code source
        public event EventHandler SourceCodeChanged;
        string _sourceCode;

        public Engine()
        {
            _sourceCode = "";
            _syntaxErrors = new List<IError>();
            // Init SourceCodeChanged
        }
        
        public bool IsRunning 
        {
            get { return _analyzer != null;}
        }

        public string SourceCode
        {
            get { return _sourceCode; }

            set 
            {
                // CODE TMP
                _sourceCode = value;

                /*
                // On réagit à l'event SourceCodeChanged
                if( _sourceCode != value )
                {
                    _sourceCode = value;
                    if( SourceCodeChanged != null ) SourceCodeChanged( this, EventArgs.Empty );
                }
                 * */
            }
        }

        public int Start()
        {

            _strTok = new StringTokenizer( _sourceCode );
            _analyzer = new Analyzer( _strTok, this );
            _tree = _analyzer.ParseBody();

            if (_syntaxErrors.Count >= 1)
            {
                return -1;
            }
            else
            {
                _pec = new PreExecutionContext( this );
                _code = _pec.PreExecut( _tree );

                _ctx = new ExecutionContext( _code, this );
                return 0;
            }

        }

        public bool NextInstruction()
        {
            if ( IsRunning )
            {
                if ( !_ctx.NextInstruction() ) 
                {
                    Stop();
                }
                return true;
            }
            else
            {
                Console.WriteLine( "End of program." );
                return false;
            }
            

        }

        public void Stop()
        {

            _strTok = null;
            _analyzer = null;
            _tree = null;
            _ctx = null;
            _pec = null;

            // Là on pète un event END_RUNNING

        }

        public void ClashError(IError error)
        {
            error.Write();
            Stop();
        }
        public void ClashError(List<IError> errors)
        {
            _syntaxErrors = errors;
            foreach (IError error in errors)
            {
                error.Write();
            }

            Stop();
        }

        public IStack GetStack()
        {
            return _ctx.Stack;
        }
    }
}