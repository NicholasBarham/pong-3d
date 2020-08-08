namespace Util.Variables
{
    [System.Serializable]
    public class IntReference
    {
        public bool useConstant = false;
        public int constantValue;
        public IntVariable variableValue;

        public int Value => useConstant ? constantValue : variableValue.Value;
    }
}