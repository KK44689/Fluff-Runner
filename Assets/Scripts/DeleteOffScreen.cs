using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOffScreen : MonoBehaviour
{
    private GameObject Obstacles;

    private GameObject Food;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Obstacles = GameObject.FindWithTag("Obstacles");
        Food = GameObject.FindWithTag("Food");

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
        if (Food != null)
        {
            if (Food.transform.position.x < player.transform.position.x - 14f)
            {
                Destroy (Food);
            }
        }
    }
}
