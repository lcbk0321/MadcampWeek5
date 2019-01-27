using UnityEngine;

public class FollowPlayer2 : MonoBehaviour
{
    public Transform playerMap2;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {

        transform.position = playerMap2.position + offset;

        if (playerMap2.position.z > -3.5f)
        {
            transform.position = new Vector3(playerMap2.position.x, transform.position.y, -3.5f);
        }

        if (playerMap2.position.z < -29f)
        {
            transform.position = new Vector3(playerMap2.position.x, transform.position.y, -29f);
        }

        if (playerMap2.position.x < 4.5f)
        {
            transform.position = new Vector3(4.5f, transform.position.y, transform.position.z);
        }

        if (playerMap2.position.x > 46f)
        {
            transform.position = new Vector3(46f, transform.position.y, transform.position.z);
        }


        //if (playerMap2.position.x < -17.5)
        //{
        //    transform.position = new Vector3(-playerMap2.position., 15, -8.5f);
        //}
        //else if (playerMap2.position.x > 17.5)
        //{
        //    transform.position = new Vector3(playerMap2.position., 15, -8.5f);
        //}
        //else
        //{
        //    transform.position = new Vector3(playerMap2.position.x, 15, -8.5f);
        //}



    }
}