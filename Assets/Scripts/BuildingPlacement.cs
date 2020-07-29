using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BuildingPlacement : MonoBehaviour{

    private Camera m_camera;

    RaycastHit hit;
    Ray ray;
    private bool stillBuild = false;

    private GameObject m_selectedBuilding;
    GameObject m_tmpObj;
    private GameObject m_missingResources;

    public GameObject m_Build; //Building attached to be built

    public int m_woodCost;
    public int m_stoneCost;
    public int m_ironCost;
    public GameObject[] m_WorkersList;

    private ResourceManager resourceManager;
    public UnityAction a_build;
    private UnityEngine.UI.Button m_buildButton;


    private void Start()
    {
        //sets common variables and sets up the action for when the button is clicked
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        resourceManager = GameObject.Find("GameManager").GetComponent<ResourceManager>();
        m_missingResources = GameObject.Find("Missing Resources Text");

        m_missingResources.transform.localScale = Vector3.zero;
          
        a_build += SelectBuilding;
        m_buildButton = GetComponent<UnityEngine.UI.Button>();
        m_buildButton.onClick.AddListener(a_build);

    }

    // Update is called once per frame
    void Update()
    {
        BuildingCursor();

        if (m_selectedBuilding != null)
        {
            if (stillBuild)
            {
                Vector3 nearestPoint = GameObject.Find("Terrain").GetComponent<TerrainGeneration>().NearestGridPoint(hit.point);
                m_selectedBuilding.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 1.5f, nearestPoint.z), m_selectedBuilding.transform.rotation);
                if (resourceManager.m_playerStone >= m_stoneCost && resourceManager.m_playerWood >= m_woodCost && resourceManager.m_playerIron >= m_ironCost) //use for all material costs
                {
                    if (!m_selectedBuilding.GetComponent<BuildingPlacementCollision>().buildingCollider)
                    {
                        if (Input.GetMouseButtonDown(0)) //if the left mouse button is clicked then building gets placed
                        {
                            m_tmpObj = Instantiate(m_selectedBuilding, GameObject.Find("Terrain").transform);
                            m_tmpObj.transform.position = hit.point;
                            m_tmpObj.GetComponent<MeshCollider>().isTrigger = true;
                            m_tmpObj.GetComponent<BuildingPlacementCollision>().placed = true;

                            m_tmpObj.transform.SetPositionAndRotation(new Vector3(nearestPoint.x, 1.5f, nearestPoint.z), m_tmpObj.transform.rotation);
                            m_tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;

                            resourceManager.m_playerStone -= m_stoneCost; //removes resources
                            resourceManager.m_playerWood -= m_woodCost;
                            resourceManager.m_playerIron -= m_ironCost;

                            m_tmpObj.gameObject.AddComponent<NavMeshModifier>().overrideArea = true;
                            m_tmpObj.GetComponent<NavMeshModifier>().area = 1;
                            GameObject.Find("Terrain").GetComponent<NavMeshSurface>().BuildNavMesh(); //This adds the building to the navmesh

                        }//maybe add obstacle detection here
                        else if (Input.GetMouseButtonDown(1)) //if right mouse button clicked then it stops the placement and deletes the building you are trying to place
                        {
                            Destroy(m_selectedBuilding);
                            stillBuild = false;
                        }
                    }
                    else if (Input.GetMouseButtonDown(1)) //if right mouse button clicked then it stops the placement and deletes the building you are trying to place
                    {
                        Destroy(m_selectedBuilding);
                        stillBuild = false;
                    }

                }
                else if (Input.GetMouseButtonDown(1)) //if right mouse button clicked then it stops the placement and deletes the building you are trying to place
                {
                    Destroy(m_selectedBuilding);
                    stillBuild = false;
                    m_missingResources.transform.localScale = Vector3.zero;
                }
                else
                {
                    m_missingResources.transform.localScale = new Vector3(1.828224f, 1.875102f, 1.875102f);
                    m_selectedBuilding.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
        
    }

    public void SelectBuilding()
    {

        m_selectedBuilding = Instantiate(m_Build); //creates the initial building for choosing placement
        m_selectedBuilding.GetComponent<MeshRenderer>().material.color = Color.green; //makes its color green
        stillBuild = true;
        m_selectedBuilding.AddComponent<BuildingPlacementCollision>();
        m_selectedBuilding.GetComponent<MeshCollider>().isTrigger = false;
        //eventually I will make it detect collisions and turn red if you can't place it

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
