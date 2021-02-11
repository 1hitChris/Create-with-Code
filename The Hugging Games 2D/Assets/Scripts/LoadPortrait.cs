using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPortrait : MonoBehaviour
{
    public GameObject parent;
    private LoadCharacter portrait;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            parent.transform.GetChild(i).gameObject.SetActive(false);
        }
        //portrait = GameObject.Find("GameManager").GetComponent<LoadCharacter>();
        portrait = GameObject.FindObjectOfType<LoadCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        parent.transform.GetChild(portrait.selectedCharacter).gameObject.SetActive(true);
    }
}
