using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject title;
    public GameObject choose;
    void Start()
    {
        
    }

    public void Play()
    {
        title.SetActive(false);
        choose.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Settings()
    {

    }

    public void Continue()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
