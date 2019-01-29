using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage1_control : MonoBehaviour
{
    public GameObject m_monster1;
    public GameObject m_monster2;
    public GameObject m_monster3;
    public GameObject player;

    public bool check = false;

    public void Reset()
    {
        m_monster1.transform.position = new Vector3(0, 0, -1);
        m_monster2.transform.position = new Vector3(0, 0, -3.5f);
        m_monster3.transform.position = new Vector3(-31, 0, -7);
        player.transform.position = new Vector3(-29.7f, 0, 0.6f);

    }

    public void Update()
    {
        if (player.transform.position.y < -7)
        {
            SceneManager.LoadScene("Map2");
        }
    }

}
