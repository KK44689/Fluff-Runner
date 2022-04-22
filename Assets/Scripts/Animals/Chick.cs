using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Chick : PlayerController
{
    private SpawnManager spawnManagerChickScript;

    private Rigidbody chickRb;

    AudioSource audioSource;

    public AudioClip jumpSound;

    void Start()
    {
        spawnManagerChickScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        chickRb =
            GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // POLYMORPHISM
    public override void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerChickScript.isGameActive
        )
        {
            chickRb.AddForce(Vector3.up * 45f, ForceMode.Impulse);
            audioSource.PlayOneShot (jumpSound);
        }
    }
}
