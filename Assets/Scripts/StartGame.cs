using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Button startBtn;
    public Button up;
    public Button down;

    public Text tableNum;

    void Start()
    {
        // Set display to the correct value.
        tableNum.text = ArrowBehaviour.table.ToString();

        // Button to start the game.
        Button btn = startBtn.GetComponent<Button>();
        btn.onClick.AddListener(Play);
        
        // Up and down for table number.
        Button btnUp = up.GetComponent<Button>();
        btnUp.onClick.AddListener(tableValUp);
        Button btnDown = down.GetComponent<Button>();
        btnDown.onClick.AddListener(tableValDown);
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
        ArrowBehaviour.num = 1;
        SceneManager.LoadScene(1);
    }

    private void tableValUp()
    {
        if (ArrowBehaviour.table < 10)
        {
            ArrowBehaviour.table++;
            tableNum.text = ArrowBehaviour.table.ToString();
        }
    }
    private void tableValDown()
    {
        if (ArrowBehaviour.table > 1)
        {
            ArrowBehaviour.table--;
            tableNum.text = ArrowBehaviour.table.ToString();
        }
    }

}
