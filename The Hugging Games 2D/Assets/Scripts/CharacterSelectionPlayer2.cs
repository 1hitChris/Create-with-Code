﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionPlayer2 : MonoBehaviour
{
    public GameObject[] characters2;
    public int selectedCharacter2 = 0;
    public GameObject[] description;
    public int selectedDescription = 0;

    public void NextCharacter()
    {
        //Set the current character displayed to false
        characters2[selectedCharacter2].SetActive(false);
        //Increase the selectedCharacter by 1
        selectedCharacter2 = (selectedCharacter2 + 1) % characters2.Length;
        //Set the next character display to true
        characters2[selectedCharacter2].SetActive(true);
        
        description[selectedDescription].SetActive(false);
        selectedDescription = (selectedDescription + 1) % description.Length;
        description[selectedDescription].SetActive(true);
    }

    public void PrevoiusCharacter()
    {
        characters2[selectedCharacter2].SetActive(false);
        selectedCharacter2--;
        if (selectedCharacter2 < 0)
        {
            selectedCharacter2 += characters2.Length;
        }
        characters2[selectedCharacter2].SetActive(true);

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
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter2);
        SceneManager.LoadScene("Game");
    }
}
