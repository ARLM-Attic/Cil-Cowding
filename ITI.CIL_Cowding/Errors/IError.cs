
namespace ITI.CIL_Cowding
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