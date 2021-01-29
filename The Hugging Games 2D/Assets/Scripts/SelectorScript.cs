using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorScript : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    private Vector2 characterPosition;
    private Vector2 offScreen;
    private int characterInt = 1;
    private SpriteRenderer blueRender, redRender;
    private readonly string selectedCharacter = "SelectedCharacter";

    private void Awake()
    {
        characterPosition = blue.transform.position;
        offScreen = red.transform.position;
        blueRender = blue.GetComponent<SpriteRenderer>();
        redRender = red.GetComponent<SpriteRenderer>();
    }

    public void NextCharacter()
    {
        switch (characterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                blueRender.enabled = false;
                blue.transform.position = offScreen;
                red.transform.position = characterPosition;
                redRender.enabled = true;
                characterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                redRender.enabled = false;
                red.transform.position = offScreen;
                blue.transform.position = characterPosition;
                blueRender.enabled = true;
                characterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreviousCharacter()
    {
        switch (characterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                blueRender.enabled = false;
                blue.transform.position = offScreen;
                red.transform.position = characterPosition;
                redRender.enabled = true;
                characterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                redRender.enabled = false;
                red.transform.position = offScreen;
                blue.transform.position = characterPosition;
                blueRender.enabled = true;
                characterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }
    
    private void ResetInt()
    {
        if (characterInt >= 2)
        {
            characterInt = 1; 
        }
        else
        {
            characterInt = 2;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Game");
    }
}
