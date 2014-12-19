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

        // Execution
        IPreExecutionContext _pec;
        IExecutionContext _ctx;
        
        // Gestion du code source
        public event EventHandler SourceCodeChanged;
        string _sourceCode;

        public Engine()
        {
            _sourceCode = "";
            // Init SourceCodeChanged
        }

        /*Normalement ça vire
         * 
        public List<IFunction> GetFunctionsList
        {
            get { return _code; }
        }

         * */
        
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

        public void Start()
        {
            
            _strTok = new StringTokenizer(_sourceCode);
            _analyzer = new Analyzer(_strTok);
            _tree = _analyzer.ParseBody();

            _pec = new PreExecutionContext();
            _code = _pec.PreExecut(_tree);

            _ctx = new ExecutionContext(_code);
        }

        public void NextInstruction()
        {
            bool tmp = _ctx.NextInstruction();
            if (!tmp) Stop();
        }

        public void Stop()
        {

            _strTok = null;
            _analyzer = null;
            _tree = null;

            // Là on pète un event END_RUNNING

        }

        public IStack GetStack()
        {
            return _ctx.Stack;
        }
    }
}