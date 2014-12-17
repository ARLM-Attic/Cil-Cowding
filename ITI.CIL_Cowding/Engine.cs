using ITI.CIL_Cowding.Interfaces;
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

        // Execution
        PreExecutionContext _pec;
        IExecutionContext _ctx;
        
        // Gestion du code source
        public event EventHandler SourceCodeChanged;
        string _sourceCode;

        public Engine()
        {
            _sourceCode = "";
        }

        public string SourceCode
        {
            get { return _sourceCode; }
            set 
            {
                if( _sourceCode != value )
                {
                    _sourceCode = value;
                    if( SourceCodeChanged != null ) SourceCodeChanged( this, EventArgs.Empty );
                }
            }
        }

        public bool IsRunning
        {
            get { return _strTok != null; }
        }

        public void Start()
        {
            List<Function> fct = new List<Function>();

            // Initialise
            _strTok = new StringTokenizer(_sourceCode);
            _analyzer = new Analyzer(_strTok);
            _tree = _analyzer.ParseBody();
            PreExecutionContext pec = new PreExecutionContext();

            
            /* List<FunctionNode> _tree
             * StringTok = sourceCode
            
             * Analyser(stk_tk).ParseBody;
             * PreExecution(_tree); -> AST List<Function>
             * Execution (AST)
            */
        }

        public void NextInstruction()
        {
            /*
             * ExecutionContext.NextLine();
             * 
             * 
             */

        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public IStack GetStack(IExecutionContext iec)
        {
            return iec.Stack;
        }
    }
}