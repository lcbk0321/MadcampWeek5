using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage1_control : MonoBehaviour
{
    public GameObject m_monster1;
    public GameObject m_monster2;
    public GameObject m_monster3;
    public GameObject player;

    public void Reset()
    {
        m_monster1.transform.position = new Vector3(31, 0, 0.2f);
        m_monster2.transform.position = new Vector3(0, 0, -3.5f);
        m_monster3.transform.position = new Vector3(-31, 0, -7);
        player.transform.position = new Vector3(-30, 0, 3);
    }
}