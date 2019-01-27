using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public int spawnLimit;
    public int spawnCount;
    public Transform[] spawnPoints;
    public float[] xNum;
    public GameObject npc;
    int randX;
    Vector2 whereToSpawn;
    public float spawnRate = 5f;
    float nextSpawn = 10f;
    private int randY;
    public Transform[] waypoints;

    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 0;   
    }

    // Update is called once per frame
    void Update()       
    {
        if (Time.time > nextSpawn)
        {
            if ( spawnCount < spawnLimit)
            {
                randY = Random.Range(0, spawnPoints.Length);
                nextSpawn = Time.time + spawnRate;

                randX = Random.Range(0, 1);

                whereToSpawn = new Vector2(xNum[randX], spawnPoints[randY].transform.position.y);
                GameObject newCat = Instantiate(npc, whereToSpawn, Quaternion.identity);
                newCat.GetComponent<NPC_WayPoint>().waypoints = waypoints;
                spawnCount += 1;

            }
        }
    }
}
