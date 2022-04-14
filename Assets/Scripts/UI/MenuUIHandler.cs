using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        if (DataManager.Instance.animalType == null)
        {
            DataManager.Instance.animalType = "Cat";
        }
        Debug.Log(DataManager.Instance.animalType);
        SceneManager.LoadScene(1);
    }
}
