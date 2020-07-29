using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementCollision : MonoBehaviour
{
    public bool buildingCollider = false;
    public bool placed = false;
    public bool cleaning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TerrainObject")
        {
            Destroy(other.gameObject);
        }
        if (placed)
        {
            if (other.gameObject.tag == "Worker")
            {

            }
            else
            {
                other.gameObject.GetComponent<BuildingPlacementCollision>().buildingCollider = true;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (placed)
        {
            if (other.gameObject.tag == "Worker")
            {

            }
            else
            {
                other.gameObject.GetComponent<BuildingPlacementCollision>().buildingCollider = false;
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }

}
