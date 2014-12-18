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

        //public bool IsRunning
        //{
        //    get { return _strTok != null && _analyzer != null; }
        //}

        public void Start()
        {
            List<Function> fct = new List<Function>();

            _strTok = new StringTokenizer(_sourceCode);
            _analyzer = new Analyzer(_strTok);
            _tree = _analyzer.ParseBody();
            fct = _pec.PreExecut(_tree);

            // Manque execution de List<Function> fct
        }

        public void NextInstruction()
        {
            ExecutionContext ec = new ExecutionContext();
            ec.NextInstruction();
        }

        public void CanRun()
        {

        }

        public void Stop()
        {
            _strTok = null;
            _analyzer = null;
            _tree = null;
            _sourceCode = "";
        }

        public IStack GetStack(IExecutionContext iec)
        {
            return iec.Stack;
        }
    }
}