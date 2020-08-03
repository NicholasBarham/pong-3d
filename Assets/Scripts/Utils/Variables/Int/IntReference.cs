namespace Util.Variables
{
    [System.Serializable]
    public class IntReference
    {
        public bool useConstant = false;
        public int constantValue;
        public IntVariable variableValue;

        public float Value => useConstant ? constantValue : variableValue.Value;
    }
}