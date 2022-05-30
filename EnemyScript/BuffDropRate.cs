using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDropRate : MonoBehaviour
{
    [Header("Buff")]
    public bool dropBuffisActive = true;
    public List<GameObject> buffs = new List<GameObject>();
    public List<int> droprate = new List<int>();

    [Header(" Buff Setup")]
    private GameObject player;
    private ShootingControl playerShoot;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            playerShoot = player.GetComponent<ShootingControl>();
        }
    }
    public void Dropbuff()
    {

        if (dropBuffisActive)
        {
            int randnum = Mathf.Abs(Random.Range(0, 11));
            if (playerShoot != null) {
                if (playerShoot.buff < 6)
                {
                    if (randnum < droprate[0])
                    {
                        Instantiate(buffs[0], transform.position, transform.rotation = Quaternion.Euler(0f, 0f, 0f));

                    }
                }
                if (randnum > droprate[0] && randnum <= droprate[1])
                {
                    Instantiate(buffs[1], transform.position, transform.rotation = Quaternion.Euler(0f, 0f, 0f));
                }
            }

        }
    }
}
