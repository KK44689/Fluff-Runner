using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    public GameObject[] Foods;

    private GameObject player;

    private GameObject ground;

    private PlayerController playerScript;

    private Vector3 SpawnObstaclesPos;

    private Vector3 SpawnFoodPos;

    private Coroutine foodSpawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacles", 0f, 3f);
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerController>();
        StartCoroutine(SpawnFood());
        StartCoroutine(SpawnObstacles());
        ground = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstacles()
    {
        while (playerScript.isGameActive)
        {
            yield return new WaitForSeconds(3);
            int index = Random.Range(0, Obstacles.Length);
            SpawnObstaclesPos =
                new Vector3(player.transform.position.x + 34f,
                    -4.5f,
                    player.transform.position.z);
            Instantiate(Obstacles[index],
            SpawnObstaclesPos,
            Obstacles[index].transform.rotation);
        }
    }

    IEnumerator SpawnFood()
    {
        while (playerScript.isGameActive)
        {
            float randX = Random.Range(2.5f, 13.5f);
            float foodSpawnTime = Random.Range(5, 10);
            yield return new WaitForSeconds(foodSpawnTime);
            int index = 0;
            SpawnFoodPos =
                new Vector3(player.transform.position.x + randX,
                    ground.transform.position.y + 3f,
                    player.transform.position.z);
            Instantiate(Foods[index],
            SpawnFoodPos,
            Foods[index].transform.rotation);
        }
    }
}
