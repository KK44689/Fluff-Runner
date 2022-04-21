using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : PlayerController
{
    private SpawnManager spawnManagerSheepScript;

    private Rigidbody sheepRb;

    void Start()
    {
        spawnManagerSheepScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        sheepRb =
            GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
    }

    public override void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerSheepScript.isGameActive
        )
        {
            sheepRb.AddForce(Vector3.up * 40f, ForceMode.Impulse);
        }
    }
}
