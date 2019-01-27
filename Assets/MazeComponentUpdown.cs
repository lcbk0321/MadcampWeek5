using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeComponentUpdown : MonoBehaviour
{
    public int up = 0;
    // Update is called once per frame
    void Update()
    {
        if (up == 0)
        {
            transform.position += new Vector3(0,0,0.05f);
            if (transform.position.z >= -18)
            {
                up = 1;
            }

        }

        if (up != 0)
        {
            transform.position -= new Vector3(0,0,0.05f);
            if (transform.position.z <= -30)
            {
                up = 0;
            }
        }
    }
}
