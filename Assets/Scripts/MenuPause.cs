using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool showMenu = false;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (showMenu)
            {
                OcultarMenu();
            }
            else
            {
                MostrarMenu();
            }
        }
    }

    private void Awake()
    {


        menu.SetActive(false);
    }

    public void MostrarMenu()
    {
        showMenu = true;
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OcultarMenu()
    {
        showMenu = false;
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void VolverAlMenu()
    {
        OcultarMenu();
       // SceneManager.LoadScene("Menu");
    }
}
