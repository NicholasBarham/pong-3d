namespace Util.Variables
{
    [System.Serializable]
    public class FloatReference
    {
        public bool useConstant = false;
        public float constantValue;
        public FloatVariable variableValue;

        public float Value => useConstant ? constantValue : variableValue.Value;
    }
}