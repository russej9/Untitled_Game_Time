using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour{

    public int m_playerWood;
    public int m_playerStone;
    public int m_playerIron;

    public void BuildButton()
    {
        //after click needs to have cursor area for how big building asset is then when another click is made if it is valid area the building gets made
    }

    private void RemoveResources() //probably pass in parameter of building object to this and below method
    {
        
    }

    public void SpawnBuildingAndAnimation()
    {
        RemoveResources();
        //half built building asset appears
        //over period of time half built disappears and finished building appears in the same spot 
    }
}
