using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : PlayerController
{
    private SpawnManager spawnManagerPenguinScript;

    private Rigidbody penguinRb;

    void Start()
    {
        spawnManagerPenguinScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        penguinRb =
            GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
    }

    public override void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerPenguinScript.isGameActive
        )
        {
            penguinRb.AddForce(Vector3.up * 35f, ForceMode.Impulse);
        }
    }
}
