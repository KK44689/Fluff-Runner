using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : PlayerController
{
    private SpawnManager spawnManagerCatScript;

    private Rigidbody catRb;

    void Start()
    {
        spawnManagerCatScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        catRb =
            GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
    }

    public override void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerCatScript.isGameActive
        )
        {
            catRb.AddForce(Vector3.up * 50f, ForceMode.Impulse);
        }
    }
}