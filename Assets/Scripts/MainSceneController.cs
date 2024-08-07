using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainSceneController : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
         #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
    }
}
