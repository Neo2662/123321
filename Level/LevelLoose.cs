using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoose : MonoBehaviour
{
    public PlayerUI ui;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.LoosePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
