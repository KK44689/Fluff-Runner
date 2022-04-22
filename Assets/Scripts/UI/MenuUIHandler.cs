using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clickSound;

    public void StartGame()
    {
        if (DataManager.Instance.animalType == null)
        {
            DataManager.Instance.animalType = "Cat";
        }
        Debug.Log(DataManager.Instance.animalType);
        SceneManager.LoadScene(1);
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot (clickSound);
    }
}
