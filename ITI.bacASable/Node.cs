
namespace ITI.bacASable
{
    public abstract class Node
    {
        readonly int _line;

        protected Node( int line )
        {
            _line = line;
        }

        public int Line
        {
            get { return _line; }
        }

        public virtual void PreExecute( PreExecutionContext pec )
        {
        }
    }

}
