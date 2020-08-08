namespace Util.Variables
{
    [System.Serializable]
    public class BoolReference
    {
        public bool useConstant = false;
        public bool constantValue;
        public BoolVariable variableValue;

        public bool Value => useConstant ? constantValue : variableValue.Value;
    }
}