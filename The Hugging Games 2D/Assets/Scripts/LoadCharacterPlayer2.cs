using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacterPlayer2 : MonoBehaviour
{
    public GameObject[] characterPrefabs2;
    public Transform spawnPoint;
    public int selectedCharacter2;

    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter2 = PlayerPrefs.GetInt("selectedCharacter2");
        GameObject prefab = characterPrefabs2[selectedCharacter2];
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
