using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class StartMenuController : MonoBehaviour
{
    public List<GameObject> uIElements = new List<GameObject>();
    public List<TextMeshProUGUI> loadbuttons = new List<TextMeshProUGUI>();

    public AudioController audiocontroller;
    public int graphicsQualityIndex;


    int numofsavefile = 0;
    public static int currentsavefile = 0;
    bool saveorloadstate;

    private void Start()
    {
        audiocontroller = FindObjectOfType<AudioController>();


        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
        {
            LoadGameSetting();
        }

        // Turn off all the UI Elements beside the MainMenu 
        for (int i = 0; i <= uIElements.Count - 1; i++)
        {

            if (uIElements[i].name != "MainMenu")
            {

                uIElements[i].SetActive(false);

            }
        }
    }

    public void StartGame()
    {
        StartCoroutine(StartGameTransition());
    }

    public void OptionMenu()
    {

        uIElements[0].SetActive(false);
        uIElements[1].SetActive(true);

    }

    public void LoadGame()
    {
        saveorloadstate = false;
        uIElements[0].SetActive(false);
        uIElements[2].SetActive(true);


        foreach (GameData game in SaveLoad.savedGames)
        {

            if (numofsavefile >= loadbuttons.Count)
            {

                SaveLoad.savedGames.RemoveRange(6, 1);
                return;
            }
            loadbuttons[numofsavefile].text = game.audioValue.ToString();
            

            numofsavefile++;
        }
        numofsavefile = 0;
    }

    public void GoBack()
    {
        for (int i = 0; i <= uIElements.Count - 1; i++)
        {
            if (uIElements[i].name == "MainMenu")
            {
                uIElements[i].SetActive(true);
            }
            else
            {
                uIElements[i].SetActive(false);
            }
        }
    }

    public void LoadGameSetting()
    {
        SaveLoad.Load();

        audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
    }

    void GamefileExist()
    {
        if (!File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
        {
            GameData.current = new GameData();
        }
        else if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.gd"))
        {
            if(SaveLoad.savedGames.Count <= currentsavefile)
            {
                GameData.current = new GameData();
                SaveLoad.savedGames.Add(GameData.current);
                GameData.current = SaveLoad.savedGames[SaveLoad.savedGames.Count -1];
            }
            else if (SaveLoad.savedGames[currentsavefile] != null)
            {
                //This code is passing the GameData store at savegames[currentsavefile #] to GameData.current so that it can overide the GameData.
                GameData.current = SaveLoad.savedGames[currentsavefile];
            }

            print(SaveLoad.savedGames.Count);
            print(currentsavefile);
        }
    }

    public void SaveGame()
    {
        saveorloadstate = true;
        uIElements[0].SetActive(false);
        uIElements[2].SetActive(true);


        foreach (GameData game in SaveLoad.savedGames)
        {

            if (numofsavefile >= loadbuttons.Count)
            {

                SaveLoad.savedGames.RemoveRange(6, 1);
                return;
            }
            loadbuttons[numofsavefile].text = game.audioValue.ToString();

            numofsavefile++;
        }
        numofsavefile = 0;
        
    }

    public void LoadSelectedFile()
    {
        //Load Music volume
        switch (EventSystem.current.currentSelectedGameObject.name)
        {

            case "SaveFile000":
                currentsavefile = 0;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }

                    SaveGame();
                }

                break;
            case "SaveFile001":
                currentsavefile = 1;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }
                    SaveGame();
                }
                break;
            case "SaveFile002":
                currentsavefile = 2;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }
                    SaveGame();
                }
                break;
            case "SaveFile003":
                currentsavefile = 3;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }
                    SaveGame();
                }
                break;
            case "SaveFile004":
                currentsavefile = 4;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }
                    SaveGame();
                }
                break;
            case "SaveFile005":
                currentsavefile = 5;
                if (saveorloadstate == false)
                {
                    audiocontroller.masterVolumeSlider.value = SaveLoad.savedGames[currentsavefile].audioValue;
                    GamefileExist();
                }
                else if (saveorloadstate == true)
                {
                    GamefileExist();

                    if (uIElements[2].activeSelf == true)
                    {
                        GameData.current.audioValue = ((int)audiocontroller.masterVolumeSlider.value);
                        SaveLoad.Save();
                    }
                    SaveGame();
                }
                break;
        }

    }

    IEnumerator StartGameTransition() {

        FadingManger.StartFading();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }
}
