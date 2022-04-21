using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{
    private PlayerController playerScript;

    private ParallaxBackground_0 bgScript;

    private Coroutine speedCoroutine;

    private SpawnManager spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        bgScript =
            GameObject
                .Find("Parallax Controler")
                .GetComponent<ParallaxBackground_0>();

        spawnManagerScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        speedCoroutine = StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnManagerScript.isGameActive)
        {
            playerScript.speed = 0;
            StopCoroutine (speedCoroutine);
            Debug.Log("increase speed " + spawnManagerScript.isGameActive);
        }
    }

    IEnumerator IncreaseSpeed()
    {
        while (spawnManagerScript.isGameActive)
        {
            yield return new WaitForSeconds(5);
            playerScript.speed += 0.2f;

            // bgScript.Camera_MoveSpeed += 0.2f;
            Debug.Log("player speed " + playerScript.speed);
        }
    }
}
