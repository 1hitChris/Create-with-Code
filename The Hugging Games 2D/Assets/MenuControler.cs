using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuControler : MonoBehaviour
{

    public GameObject menuFirstButton, characterFirstButton;

    // Start is called before the first frame update
    void Start()
    {
        //Clear slected object
        EventSystem.current.SetSelectedGameObject(null);
        //Set new selected object
        EventSystem.current.SetSelectedGameObject(menuFirstButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
