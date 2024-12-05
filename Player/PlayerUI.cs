using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public GolfBallPlayer player;
    public TextMeshProUGUI forceText;
    public TextMeshProUGUI availableText;
    public GameObject InGamePanel;
    public GameObject WinPanel;
    public GameObject LoosePanel;

    public string level1;
    public string level2;
    public string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        InGamePanel.active = true;
        WinPanel.active = false;
        LoosePanel.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        forceText.text = "Force: " + player.force.ToString();
        if (player.isPlayable)
        {
            availableText.text = "Óהאנüעו לÿק!";
            availableText.color = Color.green;
        }
        else
        {
            availableText.text = "Â ןמכועו";
            availableText.color = Color.red;
        }
    }
    public void WinButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(level2);
        print("Clicked");
    }
    public void LooseButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentLevel);
        print("Clicked");
    }
}
