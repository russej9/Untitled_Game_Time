using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{
    public int m_Wood;
    public int m_Stone;
    public int m_Iron;

    private float startTime;
    public float interval;

    public void Start()
    {
        startTime = 0.0f;
    }

    public void FixedUpdate()
    {
        startTime += Time.fixedDeltaTime;

        if(startTime > interval)
        {
            EconomyManager.Instance.totalWood += m_Wood;
            startTime = 0.0f;
            Debug.Log("Total Water: " + EconomyManager.Instance.totalWood);
        }
    }
}
