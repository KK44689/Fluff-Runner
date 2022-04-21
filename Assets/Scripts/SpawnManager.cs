using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;

    public GameObject[] Foods;

    public GameObject[] Player;

    public Text distanceText;

    private Vector3 spawnPlayerPos;

    private GameObject player;

    private GameObject ground;

    private PlayerController playerScript;

    private Vector3 SpawnObstaclesPos;

    private Vector3 SpawnFoodPos;

    public bool isGameActive { get; set; }

    private Coroutine spawnObstacles;

    private Coroutine spawnFood;

    // Start is called before the first frame update
    void Awake()
    {
        ActivePlayer();
    }

    void Start()
    {
        // SpawnPlayer();
        player = GameObject.FindWithTag("Player");
        isGameActive = true;
        spawnFood = StartCoroutine(SpawnFood());
        spawnObstacles = StartCoroutine(SpawnObstacles());

        ground = GameObject.FindWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            ShowDistances();
        }
        if (player.GetComponent<PlayerController>().hasCollideObstacle)
        {
            isGameActive = false;
        }
    }

    void ActivePlayer()
    {
        switch (DataManager.Instance.animalType)
        {
            case "Cat":
                Player[0].SetActive(true);
                break;
            case "Chick":
                Player[1].SetActive(true);
                break;
            case "Sheep":
                Player[2].SetActive(true);
                break;
            case "Penguin":
                Player[3].SetActive(true);
                break;
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (isGameActive)
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
        while (isGameActive)
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

    void ShowDistances()
    {
        distanceText.text =
            "Distance : " + (int) player.transform.position.x + " m";
    }
}
