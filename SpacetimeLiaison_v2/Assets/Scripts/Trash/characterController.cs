using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float scrollDirection, pickerZPos;
    public GameObject pickUpper;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        

    }
}
