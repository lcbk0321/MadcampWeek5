using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2_right : MonoBehaviour
{
    // Start is called before the first frame update
    public int right = 0;
    // Update is called once per frame
    void Update()
    {
        if (right == 0)
        {
            transform.position += new Vector3(0.07f, 0, 0);
            if (transform.position.x >= 30)
            {
                right = 1;
            }

        }

        if (right != 0)
        {
            transform.position -= new Vector3(0.07f, 0, 0);
            if (transform.position.x <= 5)
            {
                right = 0;
            }
        }
    }
}
