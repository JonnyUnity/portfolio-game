using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIHandler : MonoBehaviour
{

    public GameObject PauseMenu;


    public void PauseGame()
    {
        PauseMenu.SetActive(true);
    }


    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }


    public void QuitToMenu()
    {
        GameManager.Instance.QuitToMenu();
    }

}
