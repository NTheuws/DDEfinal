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
        int ran = Random.Range(1, 4); // Randomize which arrow has the correct value. 
        int arrowsPerDirection = arrows.Count / 3; // Total set of arrows each direction has.

        for (int i = 0; i < arrows.Count; i++)
        {
            ArrowMovement arrowMove = arrows[i].GetComponent<ArrowMovement>();
            
            // right arrows.
            if (i < arrowsPerDirection) // First set of all arrows in the list
            {
                if (ran == 1) // Correct answer on right.
                {
                    arrowMove.Answer = table * num;
                }
                else
                {
                    arrowMove.Answer = table * (num + 1); // One multiplication higher than the correct answer.
                }
                rightnum = arrowMove.Answer;
            }
            // left arrows.
            else if (i >= arrowsPerDirection && i < arrowsPerDirection*2) // Middle set of arrows.
            {
                if (ran == 2) // Correct answer on left.
                {
                    arrowMove.Answer = table * num;
                }
                else if (ran == 1)
                {
                    arrowMove.Answer = table * (num + 1); // One multiplication higher than the correct answer.
                }
                else
                {
                    arrowMove.Answer = table * (num - 1); // One multiplication lower than the correct answer.
                }
                leftnum = arrowMove.Answer;
            }
            // Up arrows.
            else if (i >= arrowsPerDirection*2) // Last set of arrows.
            {
                if (ran == 3) // Correct answer on up.
                {
                    arrowMove.Answer = table * num;
                }
                else
                {
                    arrowMove.Answer = table * (num - 1); // One multiplication lower than the correct answer.
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