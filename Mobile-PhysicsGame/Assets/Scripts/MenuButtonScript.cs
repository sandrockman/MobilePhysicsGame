using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonScript : MonoBehaviour {

    public void _GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void _GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void _GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void _GoToInstructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void _GoToScene1()
    {
        SceneManager.LoadScene("PhysicsScene1");
    }

    public void _GoToScene2()
    {
        SceneManager.LoadScene("PhysicsScene2");
    }

    public void _GoToScene3()
    {
        SceneManager.LoadScene("PhysicsScene3");
    }

    public void _GoToScene4()
    {
        SceneManager.LoadScene("PhysicsScene4");
    }

    public void _GoToScene5()
    {
        SceneManager.LoadScene("PhysicsScene5");
    }

    public void _GoToScene6()
    {
        SceneManager.LoadScene("PhysicsScene6");
    }

    public void _QuitGame()
    {
        Application.Quit();
    }
}
