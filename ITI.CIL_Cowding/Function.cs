using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Function : IFunction
    {

        #region Fields
        string _nameFct;
        ICILType _returnType;
        List<ICILType> _parameters;
        List<ICILType> _locVar;
        List<InstructionNode> _body;
        Dictionary<string, int> _labels;
        #endregion

        #region Properties
        public String Name
        {
            get { return _nameFct; }
        }

        public ICILType ReturnType
        {
            get { return _returnType; }
        }

        public List<ICILType> LocVar
        {
            get { return _locVar; }
        }

        public List<InstructionNode> Body
        {
            get { return _body; }
        }
        public List<ICILType> ArgVar
        {
            get { return _parameters; }
        }

        #endregion

        #region Constructor
        public Function(string nameFct, ICILType returnType, List<ICILType> parameters, List<ICILType> locVar, List<InstructionNode> body)
        {
            _nameFct = nameFct;
            _returnType = returnType;
            _parameters = parameters;
            _body = body;
            _locVar = locVar;
            _labels = new Dictionary<string, int>();
        }
        #endregion

        #region Methods
        public String GetSignature()
        {
            throw new NotImplementedException();
        }

        public void AddLocalVariable( IValue var )
        {
            throw new NotImplementedException();
        }
        public IValue GetLocalVariable( int index )
        {
            throw new NotImplementedException();
        }
        public IValue SetLocalVariable( IValue var )
        {
            throw new NotImplementedException();
        }

        public void AddLabel(string label,int index )
        {
            _labels.Add( label, index );
        }

        public int GetIndexLabel(string label)
        {
            int index;
            _labels.TryGetValue( label, out index );
            return index;

        }

        #endregion

    }
}

