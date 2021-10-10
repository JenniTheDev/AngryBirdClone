using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    // this script sits on all instances of the LevelSelect buttons
    Button selectedButton;
    LevelLoader levelLoader;
    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        selectedButton = gameObject.GetComponent<Button>();
        selectedButton.onClick.AddListener(delegate () { GetButton(); });
    }
    public void GetButton()
    {
        levelLoader.LoadLevel(selectedButton);
    }

}
