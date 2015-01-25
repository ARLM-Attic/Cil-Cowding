using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.bacASable
{
    public class CILProgram
    {
        Dictionary<string, CILClass> _classes;

        public CILProgram( Dictionary<string, CILClass> classes )
        {
            _classes = classes;
        }

        public Dictionary<string, CILClass> Classes
        {
            get{return _classes;}
        }
    }
}
