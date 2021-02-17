using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float moveSpeed;
    public float xSpeed;
    public float ySpeed;

    public GameManager gm;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        initSpeed();
        source = GetComponent<AudioSource>();
    }

    void initSpeed()
    {
        float initialDirection = Random.Range(0, 10) > 5 ? getLeftDirection() : getRightDirection();

        xSpeed = Mathf.Cos(0.0174533f * initialDirection);
        ySpeed = Mathf.Sin(0.0174533f * initialDirection);
    }

    float getLeftDirection()
    {
        return (float)Random.Range(135, 225);
    }

    float getRightDirection()
    {
        return (Random.Range(0, 10) > 5 ? (float)Random.Range(0, 45) : (float)Random.Range(315, 360));
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkPoints();
        if (Input.GetAxis("Jump") > 0f)
        {
            StartCoroutine(resetBall(true, true));
            gm.reset();
        }
    }

    void move()
    {
        if (transform.position.y >= 4.75f)
        {
            ySpeed = -1 * Mathf.Abs(ySpeed);
            source.Play();

        }
        else if (transform.position.y <= -4.75f)
        {
            ySpeed = Mathf.Abs(ySpeed);
            source.Play();
        }

        transform.Translate(new Vector3(xSpeed * Time.deltaTime * moveSpeed, ySpeed * Time.deltaTime * moveSpeed, 0f));
    }

    void checkPoints()
    {
        if(transform.position.x < -8.9f)
        {
            gm.incrementRight();
            StartCoroutine(resetBall(false));
        }
        else if(transform.position.x > 8.9f)
        {
            gm.incrementLeft();
            StartCoroutine(resetBall(true));
        }
    }

    IEnumerator resetBall(bool startLeft=true, bool hardReset=false)
    {
        transform.position = new Vector3(0f, 0f, 0f);
        xSpeed = 0f;
        ySpeed = 0f;

        yield return new WaitForSeconds(1f);

        if (!hardReset)
        {
            float initialDirection = startLeft ? getLeftDirection() : getRightDirection();
            xSpeed = Mathf.Cos(0.0174533f * initialDirection);
            ySpeed = Mathf.Sin(0.0174533f * initialDirection);
        }
        else
        {
            float initialDirection = Random.Range(0, 10) > 5 ? getLeftDirection() : getRightDirection();

            xSpeed = Mathf.Cos(0.0174533f * initialDirection);
            ySpeed = Mathf.Sin(0.0174533f * initialDirection);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        xSpeed *= -1;
        c.gameObject.GetComponent<AudioSource>().Play();
    }
}
