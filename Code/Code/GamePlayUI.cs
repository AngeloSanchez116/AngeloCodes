using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI gameplayInstance;

    [Header("UI Text")]
    public TextMeshProUGUI livestxt;
    public TextMeshProUGUI bufftxt;
    public TextMeshProUGUI scoretxt;

    public int score { get; private set; }
    [SerializeField]
    private int buffValue;

    private void Awake()
    {
        if (gameplayInstance == null) {

            gameplayInstance = this;
        }

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
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                buffValue = FindObjectOfType<ShootingControl>().buff;
            }
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
        scoretxt.text = string.Format($"Score:{score.ToString("00000000")}");
    }

    public void Displaylives(int LivesValue)
    {
        livestxt.text = string.Format($"Lives: x{LivesValue} ");
    }
}
