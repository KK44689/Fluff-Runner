using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : PlayerController
{
    public override void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isGameActive)
        {
            playerRb.AddForce(Vector3.up * 50f, ForceMode.Impulse);
        }
    }
}
