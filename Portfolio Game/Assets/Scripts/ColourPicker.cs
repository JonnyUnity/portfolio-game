using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPicker : MonoBehaviour
{

    private List<Button> ColourButtons = new List<Button>();

    public Color SelectedColour { get; private set; }
    public System.Action<Color> onColourChanged;


    public void Init()
    {
        var buttons = transform.GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() =>
            {
                SelectedColour = btn.image.color;
                foreach (var button in ColourButtons)
                {
                    button.interactable = true;
                }

                btn.interactable = false;

                onColourChanged.Invoke(SelectedColour);
            });

            ColourButtons.Add(btn);
        }


    }


    public void SelectColor(Color color)
    {
        var buttons = transform.GetComponentsInChildren<Button>();
        foreach (Button btn in buttons)
        {
            if (btn.image.color == color)
            {
                btn.onClick.Invoke();
            }
        }
    }


}
