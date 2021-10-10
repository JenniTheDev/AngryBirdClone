using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Button levelSelectButton;
    string[] levels = new string[] { "LevelOne", "LevelTwo", }; // add more levels in here as they are made
                                                                // make sure that the string name matches the scene name exactly
    
  
    void Start()
    {
        GameObject buttons = GameObject.Find("Buttons");

        for (int i = 0; i<levels.Length; i++)
        {
            Button buttonInstance = Instantiate(levelSelectButton, transform.position, Quaternion.identity);
            buttonInstance.transform.SetParent(buttons.transform);
            buttonInstance.transform.localScale = new Vector2(0.5f, 0.5f);
            int levelNumber = i + 1;
            buttonInstance.GetComponentInChildren<TextMeshProUGUI>().text = levelNumber.ToString();
        }
    }
    public void LoadLevel(Button b)
    {
        string buttonName = b.GetComponentInChildren<TextMeshProUGUI>().text;
        int sceneToLoad = int.Parse(buttonName);
        sceneToLoad = sceneToLoad - 1;
        SceneManager.LoadScene(levels[sceneToLoad]);
    }
}
