using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToEnterCut()
    {
        SceneManager.LoadScene("EnterCutScene");

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");

    }
    public void GoEndGameSceneVic()
    {
        SceneManager.LoadScene("EndGame");
    }

    public void GoEndGameSceneLost()
    {
        SceneManager.LoadScene("EndGame");
    }
}
