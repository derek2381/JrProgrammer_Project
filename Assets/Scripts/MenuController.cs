using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Correct capitalization
using UnityEngine.UI; // Include this to reference the Button class

public class MenuController : MonoBehaviour
{
    public Button btn; // Correct capitalization of Button

    void Start()
    {
        if (btn != null)
        {
            btn.onClick.AddListener(GoToMainScene); // Attach the GoToMainScene method to the button click event
        }
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene(1);
    }
}