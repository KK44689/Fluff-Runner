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
        set
        {
            if (m_speed < 0)
            {
                Debug.Log("player speed can't be negative!");
                return;
            }
            m_speed = value;
        }
    }

    // private float jumpForce = 4f;
    protected Rigidbody playerRb;

    protected bool isGrounded;

    private ParallaxBackground_0 bgScript;

    public bool isGameActive { get; set; }

    private bool isFoodCollected;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        bgScript =
            GameObject.FindWithTag("BG").GetComponent<ParallaxBackground_0>();
        isGrounded = true;
        isGameActive = true;
        isFoodCollected = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();
        PlayerJump();
        if (isFoodCollected)
        {
            // playerRb
            //     .GetComponent<Renderer>()
            //     .material
            //     .SetColor("_Color", Color.red);
            if (GameObject.FindWithTag("Obstacles") != null)
            {
                Physics
                    .IgnoreCollision(GetComponent<Collider>(),
                    GameObject
                        .FindWithTag("Obstacles")
                        .GetComponent<Collider>());
            }
        }
        else
        {
            // playerRb
            //     .GetComponent<Renderer>()
            //     .material
            //     .SetColor("_Color", Color.white);
            if (GameObject.FindWithTag("Obstacles") != null)
            {
                Physics
                    .IgnoreCollision(GetComponent<Collider>(),
                    GameObject
                        .FindWithTag("Obstacles")
                        .GetComponent<Collider>(),
                    false);
            }
        }
    }

    void PlayerMove()
    {
        transform.Translate(Vector3.right * m_speed * Time.deltaTime);
    }

    public virtual void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isGameActive)
        {
            playerRb.AddForce(Vector3.up * 4f, ForceMode.Impulse);
        }
    }

    IEnumerator GetFood()
    {
        yield return new WaitForSeconds(8);
        isFoodCollected = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            isFoodCollected = true;
            StartCoroutine(GetFood());
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
