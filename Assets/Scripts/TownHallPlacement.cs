using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallPlacement : MonoBehaviour
{
    public Camera m_camera;

    RaycastHit hit;
    Ray ray;

    public GameObject m_currentSpwnObj;
    public GameObject m_townHall;
    GameObject m_tmpObj;


    // Start is called before the first frame update
    void Start()
    {
        //m_currentSpwnObj = GameObject.Find("Town Hall"); //finds the name of the building which is put on its associated button
        m_townHall = Instantiate(m_currentSpwnObj); //creates the initial building for choosing placement
        m_townHall.GetComponent<MeshRenderer>().material.color = Color.green; //makes its color green
    }

    // Update is called once per frame
    void Update()
    {
        BuildingCursor();

        if (Input.GetMouseButtonDown(0)) //if the left mouse button is clicked then building gets placed
        {
            if (m_townHall != null)
            {
                m_tmpObj = Instantiate(m_townHall);
                m_tmpObj.transform.position = hit.point;

                Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGeneration>().NearestGridPoint(hit.point); //makes sure it hits the landscape

                m_tmpObj.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 1.5f, nearestPoint.z), m_tmpObj.transform.rotation);
                m_tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void BuildingCursor() //this is the logic that places the building with the mouse
    {
        ray = m_camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(ray.origin, ray.direction * 2000, Color.green, 3000, false);
        }
    }
}
