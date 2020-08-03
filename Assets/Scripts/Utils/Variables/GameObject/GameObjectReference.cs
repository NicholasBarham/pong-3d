using UnityEngine;

namespace Util.Variables
{
    [System.Serializable]
    public class GameObjectReference
    {
        public bool useConstant = false;
        public GameObject constantValue;
        public GameObjectVariable variableValue;

        public GameObject Value
        {
            get 
            {
                return useConstant ? constantValue :
                    variableValue ? variableValue.Value : null;
            }
        }
    }
}