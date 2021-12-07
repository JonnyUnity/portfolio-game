using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Color Colour;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    private GameObject GetPauseMenu()
    {
        GameObject pauseMenu = null;

        var canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        if (canvas != null)
        {
            var trans = canvas.transform.Find("PauseMenu");
            if (trans != null)
            {
                return trans.gameObject;
            }
        }
        
        return pauseMenu;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void PauseGame()
    {
        GameObject pauseMenu = GetPauseMenu();
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
        }        
    }

    public void ResumeGame()
    {
        GameObject pauseMenu = GetPauseMenu();
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Colour = data.Colour;
        }
    }

    public void SaveColour()
    {
        SaveData data = new SaveData();
        data.Colour = Colour;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }


    [System.Serializable]
    class SaveData
    {
        public Color Colour;
    }

}
