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
        List<InstructionNode> _code;
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

        public List<InstructionNode> Code
        {
            get { return _code; }
        }
        #endregion

        #region Constructor
        public Function(string nameFct, ICILType returnType, List<ICILType> parameters, List<ICILType> locVar, List<InstructionNode> code)
        {
            _nameFct = nameFct;
            _returnType = returnType;
            _parameters = parameters;
            _code = code;
            _locVar = locVar;
        }
        #endregion

        #region Methodes
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
        #endregion

    }
}

