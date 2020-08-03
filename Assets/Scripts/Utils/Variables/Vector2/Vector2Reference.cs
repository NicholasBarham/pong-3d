using UnityEngine;

namespace Util.Variables
{
    [System.Serializable]
    public class Vector2Reference
    {
        public bool useConstant = false;
        public Vector2 constantValue;
        public Vector2Variable variableValue;

        public Vector2 Value
        {
            get 
            {
                return useConstant ? constantValue :
                    variableValue ? variableValue.Value : Vector2.zero;
            }
        }
    }
}