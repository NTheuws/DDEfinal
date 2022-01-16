using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public TextMesh AnswerText;
    public int Answer;
    private float arrowSpeed = 0.12f;

    void Start()
    {
        AnswerText.text = Answer.ToString();
    }
    void Update()
    {
        // Move the arrow.
        Vector3 curPos = this.transform.position;
        this.transform.position = new Vector3(curPos.x, curPos.y + arrowSpeed, curPos.z);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
