using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public List<GameObject> arrows;
    public TextMesh TableText;

    private float nextActionTime = 0.0f;
    private float period = 6f;

    public static int table = 2;
    public static int num = 1;

    public static int leftnum;
    public static int rightnum;
    public static int upnum;
    public static int correctAnswer;

    void Start()
    {
        ShowCurrentTable();
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            nextActionTime += period;
            ShowCurrentTable();
            CreateNewRow();
        }
        
    }

    // Generate a new row of arrows and numbers.
    private void CreateNewRow()
    {
        GiveNumbers();
        foreach (GameObject obj in arrows)
        {
            Instantiate(obj);
        }
    }

    // Assign Numbers to each arrow.
    private void GiveNumbers()
    {
        int ran = Random.Range(1, 4);

        for (int i = 0; i < arrows.Count; i++)
        {
            ArrowMovement arrowMove = arrows[i].GetComponent<ArrowMovement>();
            // right arrows.
            
            if (i < 2)
            {
                if (ran == 1)
                {
                    arrowMove.Answer = table * num;
                }
                else
                {
                    arrowMove.Answer = table * num + 4;
                }
                rightnum = arrowMove.Answer;
            }
            // left arrows.
            else if (i >= 2 && i < 4)
            {
                if (ran == 2)
                {
                    arrowMove.Answer = table * num;
                }
                else
                {
                    arrowMove.Answer = table * num - 1;
                }
                leftnum = arrowMove.Answer;
            }
            // Up arrows.
            else if (i >= 4 && i < 6)
            {
                if (ran == 3)
                {
                    arrowMove.Answer = table * num;
                }
                else
                {
                    arrowMove.Answer = table * num + 2;
                }
                upnum = arrowMove.Answer;
            }
        }
        correctAnswer = num * table;
        num++;
    }

    // Show the current question.
    private void ShowCurrentTable()
    {
        TableText.text = table.ToString() + " x " + num.ToString();
     }
}