using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingAnswer : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject Up;

    private RectTrigger LeftTrigger;
    private RectTrigger RightTrigger;
    private RectTrigger UpTrigger;

    private int leftNum;
    private int rightNum;
    private int upNum;
    private int rightAnswer;

    public int totalPlayerPoints = 0;
    public TextMesh points;

    public GameObject checkmark;
    public GameObject redCross;


    // Start is called before the first frame update
    void Start()
    {
        // Turn the wrong/right image invisible
        checkmark.SetActive(false);
        redCross.SetActive(false);

        // Get triggers.
        LeftTrigger = Left.GetComponent<RectTrigger>();
        RightTrigger = Right.GetComponent<RectTrigger>();
        UpTrigger = Up.GetComponent<RectTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CheckInArea.InArea)
        {
            
            leftNum = ArrowBehaviour.leftnum;
            rightNum = ArrowBehaviour.rightnum;
            upNum = ArrowBehaviour.upnum;
            rightAnswer = ArrowBehaviour.correctAnswer;

            if (UpTrigger.mIsTriggered)
            {
                CheckAnswer(upNum);
            }
            else if (LeftTrigger.mIsTriggered)
            {
                CheckAnswer(leftNum);
            }
            else if (RightTrigger.mIsTriggered)
            {
                CheckAnswer(rightNum);
            }
        }
    }

    private void CheckAnswer(int compareVal)
    {
        if (rightAnswer == compareVal)
        {
            // Answer was correct.
            totalPlayerPoints++;
            points.text = totalPlayerPoints.ToString();
            ShowResult(true);
        }
        else
        {
            // Answer was wrong.
            //ShowResult(false);
        }
    }

    private void ShowResult(bool answer)
    {
        if (answer)
        {
            StartCoroutine(ShowAndHide(3.5f, checkmark));
        }
        else
        {
            StartCoroutine(ShowAndHide(3.5f, redCross));
        }
    }

    // Show right/wrong for a few seconds.
    IEnumerator ShowAndHide(float delay, GameObject obj)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }
}
