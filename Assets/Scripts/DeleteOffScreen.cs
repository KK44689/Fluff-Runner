using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOffScreen : MonoBehaviour
{
    private GameObject Obstacles;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Obstacles = GameObject.FindWithTag("Obstacles");

        // int index = Random.Range(0, Obstacles.Length);
        if (Obstacles != null)
        {
            if (
                Obstacles.transform.position.x <
                player.transform.position.x - 14f
            )
            {
                Destroy (Obstacles);
            }
        }
    }
}
