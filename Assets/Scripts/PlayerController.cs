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

    // public bool isGameActive { get; set; }
    private SpawnManager spawnManagerScript;

    private bool isFoodCollected;

    public bool hasCollideObstacle { get; private set; }

    public GameObject foodIndicator;

    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        // playerAnim =
            // GameObject.FindWithTag("Player").transform.GetComponentInChildren<Animator>();
        bgScript =
            GameObject.FindWithTag("BG").GetComponent<ParallaxBackground_0>();
        isGrounded = true;

        // isGameActive = true;
        spawnManagerScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        isFoodCollected = false;
        hasCollideObstacle = false;
        foodIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        if (isFoodCollected)
        {
            foodIndicator.SetActive(true);

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
            foodIndicator.SetActive(false);

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

        // Debug.Log(player.name);
        // playerAnim.SetTrigger("Walk");
    }

    public virtual void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerScript.isGameActive
        )
        {
            playerRb.AddForce(Vector3.up * 4f, ForceMode.Impulse);
            // playerAnim.SetTrigger("Idle");
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

            // bgScript.Camera_MoveSpeed = 0;
            hasCollideObstacle = true;
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
