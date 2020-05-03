using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{

    public GameObject startPanel, controlPanel, utensilPanel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        startPanel.SetActive(true);
        controlPanel.SetActive(false);
        utensilPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene_v3");
    }

    public void GoTitle()
    {
        //Camera.main.transform.position = new Vector3(0, 0, -99);
        startPanel.SetActive(true);
        controlPanel.SetActive(false);
        utensilPanel.SetActive(false);
        
    }

    public void GoUtensil()
    {
        //Camera.main.transform.position = new Vector3(223, 0, -99);
        startPanel.SetActive(false);
        controlPanel.SetActive(false);
        utensilPanel.SetActive(true);
    }
    public void GoControl()
    {
        //Camera.main.transform.position = new Vector3(-223,0,-99);
        startPanel.SetActive(false);
        controlPanel.SetActive(true);
        utensilPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 }
