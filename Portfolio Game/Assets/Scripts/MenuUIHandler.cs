using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIHandler : MonoBehaviour
{
    public ColourPicker ColourPicker;


    // Start is called before the first frame update
    void Start()
    {
        ColourPicker.Init();
        ColourPicker.onColourChanged += NewColourSelected;
        ColourPicker.SelectColor(GameManager.Instance.Colour);
    }

    public void NewColourSelected(Color colour)
    {
        GameManager.Instance.Colour = colour;
    }

    public void SaveColour()
    {
        GameManager.Instance.SaveColour();
    }

    public void StartNew()
    {
        GameManager.Instance.StartGame();
    }

    public void Exit()
    {
        GameManager.Instance.SaveColour();
        GameManager.Instance.Quit();
    }

}
