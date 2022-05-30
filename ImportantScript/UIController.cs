using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController uiController = new UIController();

    [Header("UI Text")]
    public TextMeshProUGUI plivestxt;
    public TextMeshProUGUI pbufftxt;
    public TextMeshProUGUI pscoretxt;

    [Header("Pause Menu")]
    public List<GameObject> uiItems = new List<GameObject>();

    public ShootingControl playerShoot;
    public PlayerState playerState;
    public bool pMenu = false;
    public int check;
    public int pscore;

    private void Awake()
    {
        uiController = this;
    }

    private void Start()
    {
        playerShoot = FindObjectOfType<ShootingControl>();
        playerState = FindObjectOfType<PlayerState>();
        uiItems.AddRange(GameObject.FindGameObjectsWithTag("UIElements"));
        CloseEverything();
    }
    // Update is called once per frame
    void Update()
    {
        plivestxt.text = string.Format("Lives x {0}", playerState.plives);
        currentbuff();
        currentscore();

        if (Input.GetKeyDown(KeyCode.Escape) && pMenu == false)
        {

            pMenu = true;
            uiItems[0].SetActive(true);
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pMenu == true) {

            pMenu = false;
            CloseEverything();
            Time.timeScale = 1;
        }

    }

    void currentbuff() {

        switch (playerShoot.buff) {

            case 1:
                pbufftxt.text = string.Format("Buff: Single Shot");
                break;
            case 2:
                pbufftxt.text = string.Format("Buff: Double Shot");
                break;
            case 3:
                pbufftxt.text = string.Format("Buff: Triple Shot");
                break;
            case 4:
                pbufftxt.text = string.Format("Buff: Quad Shot");
                break;
            case 5:
                pbufftxt.text = string.Format("Buff: Penta Shot");
                break;
        }
    }

    void currentscore() {

        pscoretxt.text = string.Format("Score:{0}", pscore.ToString("00000000"));
    
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CloseEverything() {
        // Turn off all the UI Elements beside the MainMenu 
        for (int i = 0; i <= uiItems.Count - 1; i++)
        {
                uiItems[i].SetActive(false);
        }
    }

    public void GameSetting() {
        // Turn off all the UI Elements beside the MainMenu 
        for (int i = 0; i <= uiItems.Count - 1; i++)
        {
            if (uiItems[i].name == "OptionMenu") { 
            
                uiItems[i].SetActive(true);
            }
            else{
                uiItems[i].SetActive(false);
            }
        }
    }

    public void Goback() {

        // Turn off all the UI Elements beside the MainMenu 
        for (int i = 0; i <= uiItems.Count - 1; i++)
        {

            if (uiItems[i].name == "PauseBG")
            {

                uiItems[i].SetActive(true);
            }
            else
            {
                uiItems[i].SetActive(false);
            }
        }
    }
    public void score(int score)
    {
        pscore += score;
    }

}
