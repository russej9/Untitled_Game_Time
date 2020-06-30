using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class TerrainGeneration : MonoBehaviour
{
    Mesh mesh;

    Vector3[] points;
    int[] triangles;

    public int xBlocks = 30;
    public int zBlocks = 30;

    public float y;

    [Range(0.1f, 10.0f)]
    public float xOffset = 0.5f;
    [Range(0.1f, 10.0f)]
    public float zOffset = 0.5f;
    [Range(0.1f, 10.0f)]
    public float yOffset = 1.5f;

    public int numTree_01;
    public GameObject tree_01;

    public int numTree_02;
    public GameObject tree_02;

    public int numTree_06;
    public GameObject tree_06;

    public int numTree_07;
    public GameObject tree_07;

    public int numTree_09;
    public GameObject tree_09;

    public int numTree_10;
    public GameObject tree_10;

    public int numStump_01;
    public GameObject stump_01;

    public int numStump_02;
    public GameObject stump_02;

    public int numStump_03;
    public GameObject stump_03;

    public int numStump_04;
    public GameObject stump_04;

    public int numFlower_01;
    public GameObject flower_01;

    public int numFlower_02;
    public GameObject flower_02;

    public int numFlower_03;
    public GameObject flower_03;

    public int numFlower_04;
    public GameObject flower_04;

    public int numFlower_05;
    public GameObject flower_05;

    public int numGrass_01;
    public GameObject grass_01;

    public int numGrass_02;
    public GameObject grass_02;

    public int numGrass_03;
    public GameObject grass_03;

    public int numGrass_04;
    public GameObject grass_04;

    public int numGrass_05;
    public GameObject grass_05;

    public int numGrass_06;
    public GameObject grass_06;

    public int numGrass_07;
    public GameObject grass_07;

    public int numLog_01;
    public GameObject log_01;
    
    public int numLog_02;
    public GameObject log_02;

    public int numMush_01;
    public GameObject mush_01;

    public int numMush_02;
    public GameObject mush_02;

    public int numMush_03;
    public GameObject mush_03;

    public int numMush_04;
    public GameObject mush_04;

    public int numMush_05;
    public GameObject mush_05;

    public int numMush_06;
    public GameObject mush_06;

    public int numPlant_01;
    public GameObject plant_01;

    public int numPlant_02;
    public GameObject plant_02;

    public int numPlant_03;
    public GameObject plant_03;

    public int numPlant_04;
    public GameObject plant_04;

    public int numSmallRock_01;
    public GameObject smallRock_01;

    public int numSmallRock_02;
    public GameObject smallRock_02;

    public int numSmallRock_03;
    public GameObject smallRock_03;

    public int numSmallRock_08;
    public GameObject smallRock_08;

    public int numSmallRock_09;
    public GameObject smallRock_09;

    public int numLargeRock_01;
    public GameObject largeRock_01;

    public int numLargeRock_03;
    public GameObject largeRock_03;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateTerrainGeometry();
        UpdateMesh();
        GenerateNature();
    }

    void FixedUpdate()
    {
        CreateTerrainGeometry();
        UpdateMesh();
    }


    void CreateTerrainGeometry() //this essentially makes the landscape have the subtle waves as well as create all the triangles of the ground itself
    {
        points = new Vector3[(xBlocks + 1) * (zBlocks + 1)];
        int i = 0;
        for(int z = 0; z <= zBlocks; z++)
        {
            for(int x = 0; x <= xBlocks; x++)
            {
                y = Mathf.PerlinNoise(x * xOffset, z * zOffset) * yOffset;
                points[i] = new Vector3(x * 2, y, z * 2);
                i++;
            }
        }

        triangles = new int[xBlocks * zBlocks * 6];

        int vertex = 0;
        int trianglecount = 0;

        for(int z = 0; z < zBlocks; z++)
        {
            for(int x = 0; x < xBlocks; x++)
            {
                triangles[0 + trianglecount] = vertex;
                triangles[1 + trianglecount] = vertex + xBlocks + 1;
                triangles[2 + trianglecount] = vertex + 1;
                triangles[3 + trianglecount] = vertex + 1;
                triangles[4 + trianglecount] = vertex + xBlocks + 1;
                triangles[5 + trianglecount] = vertex + xBlocks + 2;

                vertex++;
                trianglecount += 6;
            }

            vertex++;
        }
    }

    void UpdateMesh() //this will make a new mesh for the unique terrain each time the game is started and a new terrain is created
    {
        mesh.Clear();
        mesh.vertices = points;
        mesh.triangles = triangles;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
    }

    void OnDrawGizmos() //this will actually make the geometry
    {
        if (points == null) return;

        for(int i = 0; i < points.Length; i++)
        {
            Gizmos.DrawSphere(points[i], 0.5f);
        }
    }

    public Vector3 GetRandPoint()
    {
        return points[Random.Range(0, xBlocks * zBlocks)];
    }

    public Vector3 NearestGridPoint(Vector3 point)
    {
        int xPoint = (int)Mathf.Floor(point.x);
        int zPoint = (int)Mathf.Floor(point.z);
        return new Vector3(xPoint, 1, zPoint);
    }

    public void GenerateNature() //all of these create a certain number of nature objects (there are a lot of things and this is the last method in this script)
    {
        if(tree_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for(int i = 0; i < numTree_01; i++)
            {
            tmpGameObject = Instantiate(tree_01);
            spawnPoint = NearestGridPoint(GetRandPoint());
            spawnPoint.y = 1.23f;

            tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (tree_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numTree_02; i++)
            {
                tmpGameObject = Instantiate(tree_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (tree_06 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numTree_06; i++)
            {
                tmpGameObject = Instantiate(tree_06);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (tree_07 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numTree_07; i++)
            {
                tmpGameObject = Instantiate(tree_07);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (tree_09 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numTree_09; i++)
            {
                tmpGameObject = Instantiate(tree_09);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (tree_10 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numTree_10; i++)
            {
                tmpGameObject = Instantiate(tree_10);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (stump_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numStump_01; i++)
            {
                tmpGameObject = Instantiate(stump_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (stump_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numStump_02; i++)
            {
                tmpGameObject = Instantiate(stump_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (stump_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numStump_03; i++)
            {
                tmpGameObject = Instantiate(stump_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (stump_04 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numStump_04; i++)
            {
                tmpGameObject = Instantiate(stump_04);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (flower_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numFlower_01; i++)
            {
                tmpGameObject = Instantiate(flower_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (flower_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numFlower_02; i++)
            {
                tmpGameObject = Instantiate(flower_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (flower_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numFlower_03; i++)
            {
                tmpGameObject = Instantiate(flower_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (flower_04 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numFlower_04; i++)
            {
                tmpGameObject = Instantiate(flower_04);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (flower_05 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numFlower_05; i++)
            {
                tmpGameObject = Instantiate(flower_05);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_01; i++)
            {
                tmpGameObject = Instantiate(grass_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_02; i++)
            {
                tmpGameObject = Instantiate(grass_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_03; i++)
            {
                tmpGameObject = Instantiate(grass_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_04 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_04; i++)
            {
                tmpGameObject = Instantiate(grass_04);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_05 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_05; i++)
            {
                tmpGameObject = Instantiate(grass_05);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_06 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_06; i++)
            {
                tmpGameObject = Instantiate(grass_06);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (grass_07 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numGrass_07; i++)
            {
                tmpGameObject = Instantiate(grass_07);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (log_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numLog_01; i++)
            {
                tmpGameObject = Instantiate(log_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (log_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numLog_02; i++)
            {
                tmpGameObject = Instantiate(log_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_01; i++)
            {
                tmpGameObject = Instantiate(mush_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_02; i++)
            {
                tmpGameObject = Instantiate(mush_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_03; i++)
            {
                tmpGameObject = Instantiate(mush_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_04 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_04; i++)
            {
                tmpGameObject = Instantiate(mush_04);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_05 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_05; i++)
            {
                tmpGameObject = Instantiate(mush_05);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (mush_06 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numMush_06; i++)
            {
                tmpGameObject = Instantiate(mush_06);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (plant_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numPlant_01; i++)
            {
                tmpGameObject = Instantiate(plant_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (plant_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numPlant_02; i++)
            {
                tmpGameObject = Instantiate(plant_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (plant_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numPlant_03; i++)
            {
                tmpGameObject = Instantiate(plant_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (plant_04 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numPlant_04; i++)
            {
                tmpGameObject = Instantiate(plant_04);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (smallRock_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numSmallRock_01; i++)
            {
                tmpGameObject = Instantiate(smallRock_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (smallRock_02 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numSmallRock_02; i++)
            {
                tmpGameObject = Instantiate(smallRock_02);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (smallRock_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numSmallRock_03; i++)
            {
                tmpGameObject = Instantiate(smallRock_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (smallRock_08 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numSmallRock_08; i++)
            {
                tmpGameObject = Instantiate(smallRock_08);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (smallRock_09 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numSmallRock_09; i++)
            {
                tmpGameObject = Instantiate(smallRock_09);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (largeRock_01 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numLargeRock_01; i++)
            {
                tmpGameObject = Instantiate(largeRock_01);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }

        if (largeRock_03 == null)
        {
            return;
        }
        else
        {
            GameObject tmpGameObject;
            Vector3 spawnPoint;

            for (int i = 0; i < numLargeRock_03; i++)
            {
                tmpGameObject = Instantiate(largeRock_03);
                spawnPoint = NearestGridPoint(GetRandPoint());
                spawnPoint.y = 1.23f;

                tmpGameObject.transform.position = spawnPoint;
            }
        }
    }

}
