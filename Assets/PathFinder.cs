using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    public GameObject m_workPlace;
    public GameObject m_home;
    private GameObject m_Destination;
    private NavMeshAgent m_nav;

    // Start is called before the first frame update
    void Start()
    {
        m_nav = GetComponent<NavMeshAgent>();
        m_nav.autoRepath = true;
        m_Destination = m_workPlace;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(m_Destination == null))
        {
            m_nav.destination = m_Destination.transform.position;
            if (transform.position == m_Destination.transform.position)
            {
                m_Destination = null;
            }
        }
        
    }

}
