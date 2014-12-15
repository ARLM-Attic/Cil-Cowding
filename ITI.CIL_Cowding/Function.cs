﻿using System;
using System.Collections.Generic;

namespace ITI.CIL_Cowding
{
    public class Function : IFunction
    {
        string _nameFct;
        ICILType _typeOfReturn;
        List<IValue> _parameters;
        List<IValue> _locVar;
        List<InstructionNode> _code;
        public String Name
        {
            get { return _nameFct; }
        }
        public ICILType TypeOfReturn
        {
            get { return _typeOfReturn; }
        }
        public Function(string nameFct, ICILType typeOfReturn, List<IValue> parameters, List<IValue> locVar, List<InstructionNode> code)
        {
            _nameFct = nameFct;
            _typeOfReturn = typeOfReturn;
            _parameters = parameters;
            _code = code;
            _locVar = locVar;
        }
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
    }
}



// lol je fais du 6sharp