using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : EnemyAI
{
    public enum bossState { Intro, Idle, AttackPattern01, AttackPattern02, AttackPattern03, AttackPattern04, AttackPattern05, DeathAnimation}
    public Animator bossAnim;
    public bossState currentstate;
    public bool startBossFight = true;

    void Start()
    {
        if (startBossFight == true) {
            currentstate = bossState.Intro;
            bossAnim = GetComponentInParent<Animator>();
            AnimationChange();
            }
    }

    private void Update()
    {
        if (hp <= 0)
        {
            currentstate = bossState.DeathAnimation;
            AnimationChange();
           
        }
    }

    public void AnimationChange() {

        switch (currentstate)
        {
            case bossState.Intro:
                StartCoroutine(IntroAnim());
                break;
            case bossState.Idle:
                StartCoroutine(IdleAnim());
                break;
            case bossState.AttackPattern01:
                StartCoroutine(AttackPattern01Anim());
                break;
            case bossState.AttackPattern02:
                StartCoroutine(AttackPattern02Anim());
                break;
            case bossState.AttackPattern03:
                StartCoroutine(AttackPattern03Anim());
                break;
            case bossState.AttackPattern04:
                StartCoroutine(AttackPattern04Anim());
                break;
            case bossState.AttackPattern05:
                StartCoroutine(AttackPattern05Anim());
                break;
            case bossState.DeathAnimation:
                StartCoroutine(DeathAnimation());
                break;
        }

    }

    IEnumerator IntroAnim() {
        bossAnim.enabled = true;
        yield return new WaitForSeconds(4f);
        currentstate = bossState.Idle;
        AnimationChange();
    }
    IEnumerator IdleAnim() {

        bossAnim.Play("Boss_Snake_Idle");
        yield return new WaitForSeconds(.5f);
        ChangeState();
        AnimationChange();
    }
    IEnumerator AttackPattern01Anim() {

        bossAnim.Play("Boss_Snake_Attack01");
        yield return new WaitForSeconds(4f);
        DeathCheck();
    }
    IEnumerator AttackPattern02Anim()
    {
        bossAnim.Play("Boss_Snake_Attack02");
        yield return new WaitForSeconds(11f);
        DeathCheck();
    }
    IEnumerator AttackPattern03Anim()
    {
        bossAnim.Play("Boss_Snake_Attack03");
        yield return new WaitForSeconds(4.5f);
        DeathCheck();
        
    }
    IEnumerator AttackPattern04Anim()
    {
        bossAnim.Play("Boss_Snake_Attack04");
        yield return new WaitForSeconds(4.8f);
        DeathCheck();
    }
    IEnumerator AttackPattern05Anim()
    {
        
        bossAnim.Play("Boss_Snake_Attack05");
        yield return new WaitForSeconds(11f);
        DeathCheck();
    }
    IEnumerator DeathAnimation() {
        
        bossAnim.Play("Boss_DeathAnimation");
        yield return null;
    }
    private void ChangeState() {
        
        int num;
        num = Random.Range(2,7);
        if (num == 2) currentstate = bossState.AttackPattern01;
        else if (num == 3) currentstate = bossState.AttackPattern02;
        else if (num == 4) currentstate = bossState.AttackPattern03;
        else if (num == 5) currentstate = bossState.AttackPattern04;
        else if (num == 6) currentstate = bossState.AttackPattern05;
    }
    public void DeathCheck() {
        if (currentstate != bossState.DeathAnimation)
        {
            currentstate = bossState.Idle;
            AnimationChange();
        }
    }
}
