using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public FloatVariable playerWood;
    public FloatVariable playerStone;
    public FloatVariable playerIron;

    public string job;

    public void CollectResources()      //player will send an npc to go collect items
    {
        if(job == "lumber")
        {
            playerWood.value = Random.Range(30f, 55f);
        }
        else if(job == "mining")
        {
            playerStone.value = Random.Range(30f, 55f);
            playerIron.value = Random.Range(5f, 15f);
        }
    }
}
