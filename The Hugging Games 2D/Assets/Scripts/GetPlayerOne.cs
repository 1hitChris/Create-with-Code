using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerOne : MonoBehaviour
{
    public Sprite blue, red;
    private SpriteRenderer mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";

    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = blue;
                break;
            case 2:
                mySprite.sprite = red;
                break;
            default:
                break;
        }
    }
}
