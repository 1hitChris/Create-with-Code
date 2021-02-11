using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartIndicator : MonoBehaviour
{
    public GameObject parent;
    private HeartThrow hearts;
    // Start is called before the first frame update
    void Start()
    {
        parent.transform.GetChild(2).gameObject.SetActive(true);
        parent.transform.GetChild(4).gameObject.SetActive(false);
        parent.transform.GetChild(5).gameObject.SetActive(false);
        parent.transform.GetChild(6).gameObject.SetActive(false);
        hearts = GetComponent<HeartThrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hearts.currentHearts == 0)
        {
            parent.transform.GetChild(2).gameObject.SetActive(true);
            parent.transform.GetChild(4).gameObject.SetActive(false);
        }
        if (hearts.currentHearts == 1)
        {
            parent.transform.GetChild(2).gameObject.SetActive(false);
            parent.transform.GetChild(4).gameObject.SetActive(true);
            parent.transform.GetChild(5).gameObject.SetActive(false);
        }
        if (hearts.currentHearts == 2)
        {
            parent.transform.GetChild(4).gameObject.SetActive(false);
            parent.transform.GetChild(5).gameObject.SetActive(true);
            parent.transform.GetChild(6).gameObject.SetActive(false);
        }
        if (hearts.currentHearts == 3)
        {
            parent.transform.GetChild(5).gameObject.SetActive(false);
            parent.transform.GetChild(6).gameObject.SetActive(true);
        }
    }
}
