using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0); // Unload game to reset timer.
            SceneManager.UnloadScene(1); // Load menu.
        }
    }
}
