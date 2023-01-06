using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    // first we need empty array to store columns
    private GameObject[] columns;
    public GameObject columnPrefab;
    public float spawnRate = 4f;
    private float timeSinceLastSpawned;
    private int spawnXPosition = 10;
    public float minY = -3f;
    public float maxY = 2f;
    // above 2 values are set up as per game window
    private int currentColumn = 0;
    public int columnPoolSize = 5; 
    private Vector2 objectPoolPosition = new Vector2 (-15f, -15f);
    // Start is called before the first frame update
    void Start()
    {
        // initialize the array with 5 empty slots
        columns = new GameObject[columnPoolSize];       
        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(minY, maxY);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
