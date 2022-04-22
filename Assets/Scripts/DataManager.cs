using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // ENCAPSULATION
    public static DataManager Instance { get; private set; }

    public string animalType = "Chick";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy (gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad (gameObject);
    }
}
