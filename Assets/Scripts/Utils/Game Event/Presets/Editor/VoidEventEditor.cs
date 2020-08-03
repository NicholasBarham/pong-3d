using UnityEditor;
using UnityEngine;

namespace Util.GameEvents
{
    [CustomEditor(typeof(VoidEvent))]
    public class VoidEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var script = (VoidEvent)target;
            if (GUILayout.Button("Raise"))
            {
                script.Raise();
            }
        }
    }
}