using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mob2Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public int right = 1;
    public bool check = true;
    // Update is called once per frame
    void Update()
    {
        if (right == 0)
        {
            transform.position += new Vector3(0.07f, 0, 0);
            if (transform.position.x >= -14)
            {
                right = 1;
            }

        }

        if (right != 0)
        {
            if (transform.position.x <= -28)
            {
                right = 0;
            }
            transform.position -= new Vector3(0.07f, 0, 0);
            if (transform.position.x == -15)
            {
                StartCoroutine(WaitForIt());
            }
        }
    }
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(5.0f);
        check = true;
    }
}
