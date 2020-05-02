using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
        Camera.main.transform.position = new Vector3(0, 0, -99);
    }

    public void GoUtensil()
    {
        Camera.main.transform.position = new Vector3(220, 0, -99);
    }
    public void GoControl()
    {
        Camera.main.transform.position = new Vector3(-258,0,-99);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 }
