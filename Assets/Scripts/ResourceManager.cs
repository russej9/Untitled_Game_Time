using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public int m_playerWood;
    public int m_playerStone;
    public int m_playerIron;

    public string job;

    public void CollectResources()      //player will send an npc to go collect items
    {
        if(job == "lumber")
        {
            m_playerWood = Random.Range(30, 55);
        }
        else if(job == "mining")
        {
            m_playerStone = Random.Range(30, 55);
            m_playerIron = Random.Range(0, 15);
        }
    }
}
