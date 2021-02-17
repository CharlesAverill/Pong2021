using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public bool isPlayerOne;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        if (isPlayerOne)
        {
            transform.Translate(0f, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Translate(0f, Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0f);
        }

        if (transform.position.y > 3.75f)
        {
            transform.position = new Vector3(transform.position.x, 3.75f, transform.position.z);
        }
        else if (transform.position.y < -3.75f)
        {
            transform.position = new Vector3(transform.position.x, -3.75f, transform.position.z);
        }
    }
}
