using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_speed = 3f;

    // ENCAPSULATION
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

    protected Rigidbody playerRb;

    protected bool isGrounded;

    private ParallaxBackground_0 bgScript;

    private SpawnManager spawnManagerScript;

    private bool isFoodCollected;

    // ENCAPSULATION
    public bool hasCollideObstacle { get; private set; }

    public GameObject foodIndicator;

    public Animator playerAnim;

    public AudioSource audioSource;

    public AudioClip collideSound;

    public AudioClip collectFoodSound;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        bgScript =
            GameObject.FindWithTag("BG").GetComponent<ParallaxBackground_0>();
        isGrounded = true;

        spawnManagerScript =
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        isFoodCollected = false;
        hasCollideObstacle = false;
        foodIndicator.SetActive(false);
    }

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

    // ABSTRACTION
    void PlayerMove()
    {
        transform.Translate(Vector3.right * m_speed * Time.deltaTime);
    }

    // ABSTRACTION & // POLYMORPHISM
    public virtual void PlayerJump()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isGrounded &&
            spawnManagerScript.isGameActive
        )
        {
            playerRb.AddForce(Vector3.up * 4f, ForceMode.Impulse);
        }
    }

    // ABSTRACTION
    IEnumerator GetFood()
    {
        yield return new WaitForSeconds(5);
        isFoodCollected = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnim.SetBool("Walk", true);
            playerAnim.SetBool("Jump", false);
        }
        if (other.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("collide obstacles");
            m_speed = 0;

            audioSource.PlayOneShot (collideSound);
            hasCollideObstacle = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot (collectFoodSound);
            isFoodCollected = true;
            StartCoroutine(GetFood());
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("Walk", false);
            playerAnim.SetBool("Jump", true);
            isGrounded = false;
        }
    }
}
