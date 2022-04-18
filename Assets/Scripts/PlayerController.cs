using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_speed = 3f;

    public float speed
    {
        get
        {
            return m_speed;
        }
    }

    [SerializeField]
    private float jumpForce = 4f;

    private Rigidbody playerRb;

    private bool isGrounded;

    private ParallaxBackground_0 bgScript;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        bgScript =
            GameObject
                .Find("Parallax Controler")
                .GetComponent<ParallaxBackground_0>();
        isGrounded = true;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    void PlayerMove()
    {
        transform.Translate(Vector3.right * m_speed * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isGameActive)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("collide obstacles");
            m_speed = 0;
            bgScript.Camera_MoveSpeed = 0;
            isGameActive = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
