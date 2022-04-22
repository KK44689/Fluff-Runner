using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : PlayerController
{
    private SpawnManager spawnManagerPenguinScript;

    private Rigidbody penguinRb;

    AudioSource audioSource;

    public AudioClip jumpSound;

    void Start()
    {
        spawnManagerPenguinScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        penguinRb =
            GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
            audioSource.PlayOneShot (jumpSound);
        }
    }
}
