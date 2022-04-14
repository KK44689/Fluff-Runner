using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log(DataManager.Instance.animalType);
        SceneManager.LoadScene(1);
    }
}
