using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInArea : MonoBehaviour
{
    public static bool InArea = false;
    public static bool IsTriggered = true;

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
        if (this.transform.position.y > 175 && this.transform.position.y < 205)
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
