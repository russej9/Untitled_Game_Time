using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOperator : MonoBehaviour{

    Transform player;
    Transform blockGenerator;

    public FloatVariable darkness;

    int blocknumber;

    public float lightGenerated = 0.2f;

    public void SpawnAndSetBlockNumber(int _blocknumber, Transform _player, Transform _blockgenerator)
    {
        blocknumber = _blocknumber;
        player = _player;
        blockGenerator = _blockgenerator;

        Vector3 pos = transform.position;
        pos.x = player.position.x + 1.75f + blocknumber; //ensures the lights will appear between the blocks
        pos.y = UnityEngine.Random.Range(0.40f, 2.0f);
        transform.position = pos;
    }

    void EnableRenderer()
    {
        GetComponent<Renderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<Renderer>().enabled = false; //when the light object is picked up it will quit rendering itself
            darkness.value = lightGenerated;
            Invoke("EnableRenderer", 3f); //after 3 seconds the light will start rendering again
        }
        else if(collision.tag == "Cleaner")
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 pos = transform.position;
        pos.x = blockGenerator.position.x;
        pos.y = UnityEngine.Random.Range(0.40f, 2.0f);

        transform.position = pos;
    }
}
