using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [Header("UI_Gameobjects")]
    public GameObject gameplayUI;
    public GameObject endboardScore;

    [Header("UI_Texts")]
    public TextMeshProUGUI finalscore;
    public TextMeshProUGUI rating;
    public MoveLevel endLvlCam;

    private void Start()
    {

        endLvlCam = FindObjectOfType<MoveLevel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {

            gameplayUI.SetActive(false);
            endboardScore.SetActive(true);
            finalscore.text = string.Format("Score: {0}", UIController.uiController.pscore.ToString("0000000"));
            endLvlCam.enabled = false;

            if (UIController.uiController.pscore <= 10000)
            {
                rating.text = string.Format("Bad");
            }
            else if (UIController.uiController.pscore >= 10001 && UIController.uiController.pscore <= 100000)
            {
                rating.text = string.Format("GOOD");
            }
            else if (UIController.uiController.pscore >= 100001)
            {
                rating.text = string.Format("AMAZING");
            }
        }
    }
}
