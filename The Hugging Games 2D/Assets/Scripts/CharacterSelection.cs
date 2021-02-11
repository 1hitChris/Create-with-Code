using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] description;
    public int selectedCharacter = 0;
    public int selectedDescription = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        description[selectedDescription].SetActive(false);
        selectedDescription = (selectedDescription + 1) % description.Length;
        description[selectedDescription].SetActive(true);
    }

    public void PrevoiusCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

        description[selectedDescription].SetActive(false);
        selectedDescription--;
        if (selectedDescription < 0)
        {
            selectedDescription += description.Length;
        }
        description[selectedDescription].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene("Character Selection 2");
    }
}
