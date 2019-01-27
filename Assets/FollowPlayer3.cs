using UnityEngine;

public class FollowPlayer3 : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {

        if (player.position.z > 2)
        {
            if (player.position.x < -17.5)
            {
                transform.position = new Vector3(-17.5f, 15, -8);
            }
            else if (player.position.x > 17.5)
            {
                transform.position = new Vector3(17.5f, 15, -8);
            }
            else
            {
                transform.position = new Vector3(player.position.x, 15, -8);
            }
        }
        else if(player.position.z < -22)
        {
            if (player.position.x < -17.5)
            {
                transform.position = new Vector3(-17.5f, 15, -32);
            }
            else if (player.position.x > 17.5)
            {
                transform.position = new Vector3(17.5f, 15, -32);
            }
            else
            {
                transform.position = new Vector3(player.position.x, 15, -32);
            }
        }
        else
        {
            if (player.position.x < -17.5)
            {
                transform.position = new Vector3(-17.5f, 15, player.position.z-10);
            }
            else if (player.position.x > 17.5)
            {
                transform.position = new Vector3(17.5f, 15, player.position.z-10);
            }
            else
            {
                transform.position = new Vector3(player.position.x, 15, player.position.z-10);
            }
        }
    }
}