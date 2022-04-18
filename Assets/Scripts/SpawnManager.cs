using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    private GameObject player;

    private PlayerController playerScript;

    private Vector3 SpawnObstaclesPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 0f, 3f);
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.isGameActive)
        {
            CancelInvoke();
        }
    }

    void SpawnObstacles()
    {
        int index = Random.Range(0, Obstacles.Length);
        SpawnObstaclesPos =
            new Vector3(player.transform.position.x + 34f,
                -6.5f,
                player.transform.position.z);
        Instantiate(Obstacles[index],
        SpawnObstaclesPos,
        Obstacles[index].transform.rotation);
    }
}
