using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            if (transform.position.y >= -1) jump = false;

            transform.position += new Vector3(0f, 0.07f, 0f);

        }
        else
        {
            if (transform.position.y <= -3) jump = true;
            transform.position -= new Vector3(0f, 0.07f, 0f);
        }
    }
}
