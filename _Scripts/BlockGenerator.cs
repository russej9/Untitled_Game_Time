using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour{

    public List<GameObject> smallBlocks;
    public List<GameObject> largeBlocks;
    public List<GameObject> clouds;

    public GameObject Light;
    public Transform Player;


    public int blocksToGenerate = 12;
    public int cloudsToGenerate = 20;
    int blockNum = 1;
    int lightNum = 1;

    System.Random rand = new System.Random();

    private void Awake()
    {
        for(int i = 0; i < blocksToGenerate; i++)
        {
            int smallBlockToGenerate = rand.Next(0, smallBlocks.Count);
            GameObject smallBlock = GameObject.Instantiate(smallBlocks[smallBlockToGenerate]);  //generates a small block
            smallBlock.GetComponent<Block>().SetBlockNumAndSpawn(blockNum, transform, true); //method in Block.cs, GetComponent will let it use it

            int largeBlockToGenerate = rand.Next(0, largeBlocks.Count);
            GameObject largeBlock = GameObject.Instantiate(largeBlocks[largeBlockToGenerate]);  //generates a large block
            largeBlock.GetComponent<Block>().SetBlockNumAndSpawn(blockNum, transform, false); //method in Block.cs, GetComponent will let it use it

            blockNum++;

            GameObject lightGO = GameObject.Instantiate(Light);
            Light.GetComponent<LightOperator>().SpawnAndSetBlockNumber(lightNum, Player, transform);
            lightNum++;
        }

        for(int i = 0; i < cloudsToGenerate; i++)
        {
            int cloudToGenerate = rand.Next(0, clouds.Count);
            GameObject cloud = GameObject.Instantiate(clouds[cloudToGenerate]);

            float cloudHeight = Random.Range(1.8f, 2.4f);
            float cloudDistance = Random.Range(3.35f, 15f);

            cloud.transform.position = new Vector3(cloudDistance, cloudHeight, 0);

            cloud.GetComponent<CloudMover>().SpawnCloud(transform);
        }


    }


}
