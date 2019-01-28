using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < -17.5)
        {
            transform.position = new Vector3(-17.5f, player.position.y + 15, -8.5f);
        }
        else if(player.position.x >17.5)
        {
            transform.position = new Vector3(17.5f, player.position.y + 15, -8.5f);
        }
        else {
            transform.position = new Vector3(player.position.x, player.position.y + 15, -8.5f);
        }
        
    }
}