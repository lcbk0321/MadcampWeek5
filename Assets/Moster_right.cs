using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster_right : MonoBehaviour
{
    public int right = 0;
    // Update is called once per frame
    void Update()
    {
        if (right == 0)
        {
            transform.position += new Vector3(0.1f, 0, 0);
            if (transform.position.x >= 30)
            {
                right = 1;
            }

        }

        if (right != 0)
        {
            transform.position -= new Vector3(0.1f, 0, 0);
            if (transform.position.x <= 4)
            {
                right = 0;
            }
        }
    }
}
