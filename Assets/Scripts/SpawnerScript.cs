using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    //Static instance of GameManager which allows it to be accessed by any other script.
    public static SpawnerScript instance = null;

    public int spawnLimit;
    public int spawnCount;
    public Transform[] spawnPoints;
    public float[] xNum;
    public GameObject npc;
    int randX;
    Vector2 whereToSpawn;
    public float spawnRate = 5f;
    float nextSpawn = 2.0f;
    private int randY;
    public Transform[] waypoints;

    // Delegates
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        //Sets this to not be destroyed when reloading scene
        //DontDestroyOnLoad(gameObject);
    }

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
                newCat.GetComponent<NPC_Data>().Initialize((CatType)Random.Range(0, (int)CatType.TOTAL));
                spawnCount += 1;

            }
        }
    }
}
