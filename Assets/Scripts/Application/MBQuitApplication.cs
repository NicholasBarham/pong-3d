using UnityEngine;

public class MBQuitApplication : MonoBehaviour
{
    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
