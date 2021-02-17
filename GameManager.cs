using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int leftScore;
    public int rightScore;

    public Text leftScoreText;
    public Text rightScoreText;

    public GameObject paddleLeft;
    public GameObject paddleRight;

    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;

        leftScoreText.text = "0";
        rightScoreText.text = "0";
    }

    public void incrementLeft()
    {
        leftScore += 1;
        leftScoreText.text = "" + leftScore;

        resetPaddles();
    }

    public void incrementRight()
    {
        rightScore += 1;
        rightScoreText.text = "" + rightScore;

        resetPaddles();
    }

    void resetPaddles()
    {
        paddleLeft.transform.position = new Vector3(paddleLeft.transform.position.x, 0f, 0f);
        paddleRight.transform.position = new Vector3(paddleRight.transform.position.x, 0f, 0f);
    }

    public void reset()
    {
        leftScore = 0;
        rightScore = 0;

        leftScoreText.text = "0";
        rightScoreText.text = "0";

        resetPaddles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
