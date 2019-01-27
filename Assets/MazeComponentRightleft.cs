using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeComponentRightleft : MonoBehaviour
{
    public int right = 0;
    // Update is called once per frame
    void Update()
    {
        if (right == 0)
        {
            transform.position += new Vector3(0.05f, 0, 0);
            if (transform.position.x >= 47.5)
            {
                right = 1;
            }

        }

        if (right != 0)
        {
            transform.position -= new Vector3(0.05f, 0, 0);
            if (transform.position.x <= 43)
            {
                right = 0;
            }
        }
    }
}
