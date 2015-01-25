
namespace ITI.bacASable
{
    public interface IError
    {
        int Line
        {
            get;
        }
        object Data
        {
            get;
        }
        string StackTrace
        {
            get;
        }
        string ToString();
        void Write();
        
    }
}