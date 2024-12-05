using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public GameObject player;
    public PlayerUI ui;
    private void Start()
    {
        PlayerUI ui = player.GetComponent<PlayerUI>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            ui.WinPanel.SetActive(true);
            ui.InGamePanel.SetActive(false);
            print("Win");
        }
    }
}
