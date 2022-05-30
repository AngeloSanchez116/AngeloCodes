using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingManger : MonoBehaviour
{
    public static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public static void StartFading() {

        anim.enabled = true;
        anim.Play("Fading_to_Black");
    }

    public static void StopFading() {

        anim.Play("Fade_to_normal");
    }
}
