namespace PedZed.StringManipulation
{
    public abstract class StringManipulator
    {
        protected string inputString;
        protected string outputString;
        
        public string GetManipulatedString()
        {
            return outputString;
        }
    }
}
