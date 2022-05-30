using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayTutorial : MonoBehaviour
{
    [Header("Tutorial Key Items")]
    public MoveLevel moveLevel;
    public SpawnEnemy spawnEnemy;
    public GameObject tutorial;
    public GameObject pointer;


    private bool passtut = true;
    public int pressE = 0;
    private bool nexttextdialogue = true;
    public bool holdUntoTextIsDone = true;
    private bool starttext = false;
    public float timeuntotextstart;

    [Header("Make Game Run Better Stuff")]
    public TypeWritereffect typeWriterEff;
    public TextMeshProUGUI textbox;
    public PlayerMovementControl playerMove;
    public ShootingControl playerShoot;
    public Animator greenArrow;
    public Animator tutorialbox;

    private void Start()
    {
        typeWriterEff = GetComponent<TypeWritereffect>();
        textbox = tutorial.GetComponentInChildren<TextMeshProUGUI>();
        playerMove = FindObjectOfType<PlayerMovementControl>();
        playerShoot = FindObjectOfType<ShootingControl>();
        greenArrow = pointer.GetComponent<Animator>();
        tutorialbox = tutorial.GetComponent<Animator>();
        opentextbox();

    }
    private void Update() 
    {
        if (tutorial.gameObject.TryGetComponent(out Animator anim)) {
            if (anim.isActiveAndEnabled) {
                timeuntotextstart += Time.deltaTime;
            }
        }


        if (passtut == true) {

            if (Input.GetKeyDown(KeyCode.E) && holdUntoTextIsDone == true) {

                pressE++;
                nexttextdialogue = true;
                
            }
            else if (pressE == 0 && nexttextdialogue == true && timeuntotextstart >= 1.3f)
            {

                nexttextdialogue = false;
                
               typeWriterEff.Run(string.Format("Hey pilot, do you like your new\nship? YOU BETTER,because it\ncost us alot of money.But\nanyway do you remember how\nto controlleryour ship?\n\n               Press E To Continue"),
               textbox);
            }
            else if (pressE == 1 && nexttextdialogue == true) {

                nexttextdialogue = false;
                typeWriterEff.Run(string.Format("Don't worry i will tell you how,\nbut shouldn't you already know \nthis?, O well, you can press \nW A S D to move, and left click\nto shoot your blaster. \n\n               Press E To Continue"),
                textbox);
                playerMove.enabled = true;
                playerShoot.enabled = true;
            }
            else if (pressE == 2 && nexttextdialogue == true)
            {
                nexttextdialogue = false;
                typeWriterEff.Run(string.Format("On the bottom left you can see\nthe number of lives you have\nleft. Make sure this number\ndoesn't reach zero.\n\n\n               Press E To Continue"),
                textbox);
                pointer.SetActive(true);
            }
            else if (pressE == 3 && nexttextdialogue == true)
            {
                nexttextdialogue = false;
                typeWriterEff.Run(string.Format("Next to your lives is your\ncurrent active buff. If you lose\na live you lose all your buff\nso be carefull.\n\n\n               Press E To Continue"),
                textbox);
                greenArrow.SetInteger("PressE", pressE);
            }
            else if (pressE == 4 && nexttextdialogue == true)
            {
                nexttextdialogue = false;
                typeWriterEff.Run("Your current high score can be\nfound here make sure you get\nthis number as high as possible\nto get cool reward\n\n\n               Press E To Continue",
                textbox);
                pointer.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 180, -25f);
                greenArrow.SetInteger("PressE", pressE);
            }
            else if (pressE >= 5 && nexttextdialogue == true)
            {
                StartCoroutine(Finishtut());
            }            
        }
    }

    void opentextbox() {

        tutorial.GetComponent<Animator>().enabled = true;
        timeuntotextstart = 0;

    }

    IEnumerator Finishtut() {

        tutorial.GetComponent<Animator>().SetBool("Closebox", true);

        yield return new WaitForSeconds(1.5f);
            moveLevel.enabled = true;
            spawnEnemy.enabled = false;
            moveLevel.movecamerax = true;
            pointer.SetActive(false);
            tutorial.SetActive(false);
            passtut = false;
    }
}
