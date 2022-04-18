using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    private GameObject player;

    private Vector3 SpawnObstaclesPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 0f, 3f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnObstacles()
    {
        int index = Random.Range(0, Obstacles.Length);
        SpawnObstaclesPos =
            new Vector3(player.transform.position.x + 24f,
                -6.2f,
                player.transform.position.z);
        Instantiate(Obstacles[index],
        SpawnObstaclesPos,
        Obstacles[index].transform.rotation);
    }
}
