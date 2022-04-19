using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{
    private PlayerController playerScript;

    private ParallaxBackground_0 bgScript;

    private Coroutine speedCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        playerScript =
            GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        bgScript =
            GameObject
                .Find("Parallax Controler")
                .GetComponent<ParallaxBackground_0>();
        speedCoroutine = StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        // if (!playerScript.isGameActive)
        // {
        //     // playerScript.speed = 0;
        //     // bgScript.Camera_MoveSpeed = 0;
        //     // StopCoroutine (speedCoroutine);
        // }
    }

    IEnumerator IncreaseSpeed()
    {
        while (playerScript.isGameActive)
        {
            // Debug.Log("start coroutine ");
            yield return new WaitForSeconds(5);
            playerScript.speed += 0.2f;
            bgScript.Camera_MoveSpeed += 0.2f;
            Debug.Log("player speed " + playerScript.speed);
        }
    }
}
