using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl_0 : MonoBehaviour
{
    [Header("BackgroundNum 0 -> 3")]
    public int backgroundNum;

    public Sprite[] Layer_Sprites;

    private GameObject[] Layer_Object = new GameObject[5];

    private int max_backgroundNum = 3;

    void Start()
    {
        for (int i = 0; i < Layer_Object.Length; i++)
        {
            Layer_Object[i] = GameObject.Find("Layer_" + i);
        }

        ChangeSprite();
    }

    void Update()
    {
        //for presentation without UIs
        // if (Input.GetKeyDown(KeyCode.RightArrow)) NextBG();
        // if (Input.GetKeyDown(KeyCode.LeftArrow)) BackBG();
        switch (DataManager.Instance.animalType)
        {
            case "Chick":
                SetBG(0);
                break;
            case "Sheep":
                SetBG(1);
                break;
            case "Cat":
                SetBG(2);
                break;
            case "Penguin":
                SetBG(3);
                break;
            default:
                SetBG(2);
                break;
        }
    }

    void ChangeSprite()
    {
        Layer_Object[0].GetComponent<SpriteRenderer>().sprite =
            Layer_Sprites[backgroundNum * 5];
        for (int i = 1; i < Layer_Object.Length; i++)
        {
            Sprite changeSprite = Layer_Sprites[backgroundNum * 5 + i];

            //Change Layer_1->7
            Layer_Object[i].GetComponent<SpriteRenderer>().sprite =
                changeSprite;

            //Change "Layer_(*)x" sprites in children of Layer_1->7
            Layer_Object[i]
                .transform
                .GetChild(0)
                .GetComponent<SpriteRenderer>()
                .sprite = changeSprite;
            Layer_Object[i]
                .transform
                .GetChild(1)
                .GetComponent<SpriteRenderer>()
                .sprite = changeSprite;
        }
    }

    public void SetBG(int bgNumber)
    {
        backgroundNum = bgNumber;
        DataManager.Instance.animalType = SetAnimalType(bgNumber);

        // if (backgroundNum > max_backgroundNum) backgroundNum = 0;
        ChangeSprite();
    }

    string SetAnimalType(int bgNumber)
    {
        switch (bgNumber)
        {
            case 0:
                return "Chick";
                break;
            case 1:
                return "Sheep";
                break;
            case 2:
                return "Cat";
                break;
            case 3:
                return "Penguin";
                break;
            default:
                return "Cat";
                break;
        }
    }
    // public void NextBG(){
    //     backgroundNum = backgroundNum + 1;
    //     if (backgroundNum > max_backgroundNum) backgroundNum = 0;
    //     ChangeSprite();
    // }
    // public void BackBG(){
    //     backgroundNum = backgroundNum - 1;
    //     if (backgroundNum < 0) backgroundNum = max_backgroundNum;
    //     ChangeSprite();
    // }
}
