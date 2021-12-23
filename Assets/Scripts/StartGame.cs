using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button Btn;

    void Start()
    {
        Button btn = Btn.GetComponent<Button>();
        btn.onClick.AddListener(Play);
    }

    void Update()
    {
        // Close the game application when escape is pressed.
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    // Load the game scene when the button is pressed.
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
