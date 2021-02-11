using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPortraitP2 : MonoBehaviour
{
    public GameObject parent;
    private LoadCharacterPlayer2 portrait;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
        }
        //portrait = GameObject.Find("GameManager").GetComponent<LoadCharacter>();
        portrait = GameObject.FindObjectOfType<LoadCharacterPlayer2>();
    }

    // Update is called once per frame
    void Update()
    {
        parent.transform.GetChild(portrait.selectedCharacter2).gameObject.SetActive(true);
    }
}
