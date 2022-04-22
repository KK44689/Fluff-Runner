using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParallaxBackground_0 : MonoBehaviour
{
    public bool Camera_Move;

    public float Camera_MoveSpeed = 1.5f;

    [Header("Layer Setting")]
    public float[] Layer_Speed = new float[7];

    public GameObject[] Layer_Objects = new GameObject[7];

    protected Transform _camera;

    protected float[] startPos = new float[7];

    protected float boundSizeX;

    protected float sizeX;

    protected GameObject Layer_0;

    protected GameObject player;

    protected int sceneIndex;

    void Start()
    {
        _camera = Camera.main.transform;
        sizeX = Layer_Objects[0].transform.localScale.x;
        boundSizeX =
            Layer_Objects[0]
                .GetComponent<SpriteRenderer>()
                .sprite
                .bounds
                .size
                .x;
        for (int i = 0; i < 5; i++)
        {
            startPos[i] = _camera.position.x;
        }
        player = GameObject.FindWithTag("Player");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        //Moving camera
        if (Camera_Move)
        {
            // if (sceneIndex == 1)
            // {
            //     _camera.position =
            //         new Vector3(player.transform.position.x + 7f,
            //             _camera.position.y,
            //             _camera.position.z);
            // }
            // _camera.position +=
            //     Vector3.right * Time.deltaTime * Camera_MoveSpeed;
            MoveCamera();
        }

        // for (int i = 0; i < 5; i++)
        // {
        //     float temp = (_camera.position.x * (1 - Layer_Speed[i]));
        //     float distance = _camera.position.x * Layer_Speed[i];
        //     Layer_Objects[i].transform.position =
        //         new Vector2(startPos[i] + distance, _camera.position.y + 3f);
        //     if (temp > startPos[i] + boundSizeX * sizeX)
        //     {
        //         startPos[i] += boundSizeX * sizeX;
        //     }
        //     else if (temp < startPos[i] - boundSizeX * sizeX)
        //     {
        //         startPos[i] -= boundSizeX * sizeX;
        //     }
        // }
        SetLayerSpeed();
    }

    public virtual void MoveCamera()
    {
        _camera.position += Vector3.right * Time.deltaTime * Camera_MoveSpeed;
    }

    public virtual void SetLayerSpeed()
    {
        for (int i = 0; i < 5; i++)
        {
            float temp = (_camera.position.x * (1 - Layer_Speed[i]));
            float distance = _camera.position.x * Layer_Speed[i];
            Layer_Objects[i].transform.position =
                new Vector2(startPos[i] + distance, _camera.position.y);
            if (temp > startPos[i] + boundSizeX * sizeX)
            {
                startPos[i] += boundSizeX * sizeX;
            }
            else if (temp < startPos[i] - boundSizeX * sizeX)
            {
                startPos[i] -= boundSizeX * sizeX;
            }
        }
    }
}
