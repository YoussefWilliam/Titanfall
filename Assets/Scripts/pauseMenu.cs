using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject menu;
    public   bool p = false;
    public GameObject options;
    public GameObject mainMenu;
    public GameObject startMenu;
    public GameObject credits;
    public GameObject gameOver;
    public new GameObject audio;
    public GameObject howToPlay;
    public GameObject primary;
    public GameObject heavy;
    public GameObject titan;
    public int PrimDamage;
    public int PrimRate;
    public int PrimCount;
    public int PrimRange;
    public string PrimMode;
    public string primaryWeapon;
    public string heavyWeapon;
    public string titanChoice;



    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (p)
            {
                menu.SetActive(false);
                p = false;
                Time.timeScale = 1;

            }
            else if(!p)
            {
                menu.SetActive(true);
                p = true;
                Time.timeScale = 0;

                    
            }
        }
    }
public void resumeGame()
    {

        p = !p;
        Time.timeScale = 1;
        menu.SetActive(false);
        

    }

public void optionsMenu()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);


    }

public void backToMain()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }

public void startGame()
    {
        mainMenu.SetActive(false);
        startMenu.SetActive(true);


    }

    public void goToCredits()
    {
        options.SetActive(false);
        credits.SetActive(true);

    }

    public void restartGame()
    {
        gameOver.SetActive(false);
        startMenu.SetActive(true);
    }

    public void backToMainPause()
    {
        menu.SetActive(false);
        mainMenu.SetActive(true);

    }
    public void goToHow()
    {
        options.SetActive(false);
        howToPlay.SetActive(true);

    }
    public void goToAudio()
    {
        options.SetActive(false);
        audio.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void backCredits()
    {
        credits.SetActive(false);
        options.SetActive(true);
    }

    public void backAudio()
    {
        audio.SetActive(false);
        options.SetActive(true);
    }

    public void backGameover()
    {
        gameOver.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void backHowToPlay()
    {
        howToPlay.SetActive(false);
        options.SetActive(true);
    }

    public void backPrimary()
    {
        primary.SetActive(false);
        mainMenu.SetActive(true);
        
    }

    public void backHeavy()
    {
        heavy.SetActive(false);
        primary.SetActive(true);

    }

    public void backTitan()
    {
        titan.SetActive(false);
        heavy.SetActive(true);
    }

    public void rifle()
    {
        primary.SetActive(false);
        heavy.SetActive(true);
        primaryWeapon = "rifle";
        PrimCount = 35;
        PrimDamage = 10;
        PrimRange = 65;
        PrimRate = 10;
        PrimMode = "A";
    }

    public void Sniper()
    {
        primary.SetActive(false);
        heavy.SetActive(true);
        primaryWeapon = "sniper";
        PrimCount = 6;
        PrimDamage = 85;
        PrimRange = 100;
        PrimRate = 1;
        PrimMode = "S";
    }

    public void shotgun()
    {
        primary.SetActive(false);
        heavy.SetActive(true);
        primaryWeapon = "shotgun";
        PrimCount = 12;
        PrimDamage = 70;
        PrimRange = 4;
        PrimRate = 3;
        PrimMode = "S";
    }

    public void rocket()
    {
        heavy.SetActive(false);
        titan.SetActive(true);
        heavyWeapon = "rocket";
    }

    public void grenade()
    {
        heavy.SetActive(false);
        titan.SetActive(true);
        heavyWeapon = "grenade";
    }

    public void ion()
    {
        titan.SetActive(false);
        titanChoice = "ion";

    }

    public void legion()
    {
        titan.SetActive(false);
        titanChoice = "legion";    }

    public void restartPause()
    {
        menu.SetActive(false);
        startMenu.SetActive(true);
    }

}
                  