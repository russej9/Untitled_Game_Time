using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacement : MonoBehaviour{

    public Camera m_camera;

    RaycastHit hit;
    Ray ray;

    public GameObject m_selectedBuilding;
    GameObject m_tmpObj;

    public GameObject m_currentSpwnObj;

    public int m_Wood;
    public int m_Stone;
    public int m_Iron;

    // Update is called once per frame
    void Update()
    {
        BuildingCursor();

        if (Input.GetMouseButtonDown(0)) //if the left mouse button is clicked then building gets placed
        {
            if (m_selectedBuilding != null)
            {
                if (m_Stone >= 10 && m_Wood >= 30)
                {
                    m_tmpObj = Instantiate(m_selectedBuilding);
                    m_tmpObj.transform.position = hit.point;
                    m_tmpObj.transform.parent = GameObject.Find("Terrain").transform;


                    Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGeneration>().NearestGridPoint(hit.point); //makes sure it hits the landscape

                    m_tmpObj.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 1.5f, nearestPoint.z), m_tmpObj.transform.rotation);
                    m_tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;

                    m_Stone = m_Stone - 10; //removes resources
                    m_Wood = m_Wood - 30;
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) //if right mouse button clicked then it stops the placement and deletes the building you are trying to place
        {
            Destroy(m_selectedBuilding);
        }
        else
        {
            if (m_selectedBuilding != null) //I believe that this checks for all the times that you don't click and helps keep the green building attached to landscape
            {
                Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGeneration>().NearestGridPoint(hit.point);
                m_selectedBuilding.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 1.5f, nearestPoint.z), m_selectedBuilding.transform.rotation);
            }
        }
    }

    public void SelectBuilding(string buildingName)
    {
        if(m_Stone >= 10 && m_Wood >= 30)
        {
            if (m_currentSpwnObj == null || m_currentSpwnObj.name != buildingName)
            {
                if (m_selectedBuilding != null) //this is I think supposed to be what stops it from letting you place a ton of buildings but doesn't work
                {
                    Destroy(m_selectedBuilding);
                }
            }
            m_currentSpwnObj = GameObject.Find(buildingName); //finds the name of the building which is put on its associated button
            m_selectedBuilding = Instantiate(m_currentSpwnObj); //creates the initial building for choosing placement
            m_selectedBuilding.GetComponent<MeshRenderer>().material.color = Color.green; //makes its color green
            //eventually I will make it detect collisions and turn red if you can't place it
        }
        else if (m_Stone < 10 || m_Wood < 30) //stops it from letting you press button if not enough resources
        {
            Destroy(m_selectedBuilding);
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
