using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    public GameObject[] Foods;

    private GameObject player;

    private PlayerController playerScript;

    private Vector3 SpawnObstaclesPos;

    private Vector3 SpawnFoodPos;

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
                -4.5f,
                player.transform.position.z);
        GameObject ObstacleClone =
            Instantiate(Obstacles[index],
            SpawnObstaclesPos,
            Obstacles[index].transform.rotation);
        StartCoroutine(SpawnFood(ObstacleClone));
    }

    IEnumerator SpawnFood(GameObject Obstacle)
    {
        Debug.Log("start coroutine food");
        float foodSpawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(foodSpawnTime);
        int index = 0;
        SpawnFoodPos =
            new Vector3(Obstacle.transform.position.x,
                Obstacle.transform.position.y + 2f,
                Obstacle.transform.position.z);
        Instantiate(Foods[index],
        SpawnFoodPos,
        Foods[index].transform.rotation);
    }
}
