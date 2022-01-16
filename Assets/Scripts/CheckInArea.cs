using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInArea : MonoBehaviour
{
    public static bool InArea = false;
    public static bool IsTriggered = true;

    // Scoring area.
    private int minimalValY = 175; 
    private int maximalValY = 205;

    private void Start()
    {
        IsTriggered = false;
    }
    void Update()
    {
        CheckIfInArea();
    }
    private void CheckIfInArea()
    {
        if (this.transform.position.y > minimalValY && this.transform.position.y < maximalValY)
        {
            InArea = true;
            IsTriggered = true;
        }
        else
        {
            InArea = false;
        }
    }
}
