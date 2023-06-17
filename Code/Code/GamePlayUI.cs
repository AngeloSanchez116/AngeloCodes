using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//use a namespace
public class GamePlayUI : MonoBehaviour
{
    //I see that you are trying to make a signleton, 
    //but you need to use a MonoBehaviour specific version.
    //Example
    /*
        public static Singleton Instance { get; private set; }
        private void Awake() 
        { 
            // If there is an instance, and it's not me, delete myself.
    
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }
     */


    public static GamePlayUI gameplayInstance;

    [Header("UI Text")]
    public TextMeshProUGUI livestxt;
    public TextMeshProUGUI bufftxt;
    public TextMeshProUGUI scoretxt;

    //good use of property
    public int score { get; private set; }
    [SerializeField]
    private int buffValue;

    private void Awake()
    {
        if (gameplayInstance == null) {

            gameplayInstance = this;
        }
        //If you set a subscribe, then you need to have a unsubscribe option. Where you put it depends on the architecture
        //for this type of script, it would be in OnDestroy
        //example
        /*
        private void OnDestroy()
        {
            ResetPlayerAfterDeath.OnLevelReset -= ResetScore;
            ShootingControl.buffUpdate -= currentbuff;
        }
        //This would be an example of a unsubscribe in the OnDestroy function called by Unity
         */

        ResetPlayerAfterDeath.OnLevelReset += ResetScore;
        ShootingControl.buffUpdate += currentbuff;

        if (GameObject.FindGameObjectWithTag("Player") != null) {
            buffValue = FindObjectOfType<ShootingControl>().buff;
        }
    }

    private void Start()
    {
        currentbuff();
        Displayscore();
    }

    void currentbuff()
    {
        if (buffValue < 6)
        {
            //Try to find ways to avoid Find statements. Find statements are not good to get in the habbit of using
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                buffValue = FindObjectOfType<ShootingControl>().buff;
            }
            //You don't need string.Format if you are going to write formatted strings
            //When you place a `$` before your string and place the variable name directly inside the brackets then you don't need string.Format
            //string.Format is for doing stuff like
            /*
            int aNum = 5;
            string.Format("I need to buy {0} things", aNum);
            */
            bufftxt.text = string.Format($"Buff:x{buffValue}");
        }

    }

    public void UpdateScore(int value)
    {
        score += value;
        Displayscore();
    }

    public void ResetScore()
    {
        score = 0;
        Displayscore();
    }

    void Displayscore()
    {
        //Again for both of these, you don't need string.format here unless you are going to add aditional formatting.

        //check out what string.format does, examples further down after you scroll https://learn.microsoft.com/en-us/dotnet/api/system.string.format?view=net-7.0
        scoretxt.text = string.Format($"Score:{score.ToString("00000000")}");
    }

    public void Displaylives(int LivesValue)
    {
        livestxt.text = string.Format($"Lives: x{LivesValue} ");
    }
}
