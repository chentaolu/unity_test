using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class homePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goChooseMode() {
        SceneManager.LoadScene("chooseGameMode");
    }

    public void goChooseMap() {
        SceneManager.LoadScene("chooseMap");
    }

    public void goBack1() {
        SceneManager.LoadScene("homePage");
    }

    public void goBack2() {
        SceneManager.LoadScene("chooseGameMode");
    }

    public void Map1() {
        SceneManager.LoadScene("Map1");
    }

    public void quitGame() {
        Application.Quit();
    }
}
