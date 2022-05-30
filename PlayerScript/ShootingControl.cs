using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControl : MonoBehaviour
{
    [Header("Bullet Manager")]
    public List<GameObject> bulletSpawm = new List<GameObject>();
    public GameObject bullet;
    public int bulletSpeed;
    public float firetimer = 1;
    public float firerate;

    [Header("Bullet Buff")]
    public int buff;
    public Vector3 doubAngel;
    public Vector3 tripAngel;

    [Header("Things to Get")]
    public Rigidbody bulletrb;



    private void Awake()
    {
        bulletrb = bullet.GetComponent<Rigidbody>();
        bulletSpawm.AddRange(GameObject.FindGameObjectsWithTag("BulletSpawn"));
    }
    // Update is called once per frame

    void Update()
    {
        firetimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && firetimer <= 0)
        {

            Rigidbody clone;
            clone = Instantiate(bulletrb, bulletSpawm[0].transform.position, bulletSpawm[0].transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.left * bulletSpeed);

            if (buff >= 2)
            {
                clone = Instantiate(bulletrb, bulletSpawm[0].transform.position, bulletSpawm[0].transform.rotation);
                clone.velocity = transform.TransformDirection(-doubAngel * bulletSpeed);
            }
            if (buff >= 3)
            {
                clone = Instantiate(bulletrb, bulletSpawm[0].transform.position, bulletSpawm[0].transform.rotation);
                clone.velocity = transform.TransformDirection(-tripAngel * bulletSpeed);
            }
            if (buff >= 4)
            {
                clone = Instantiate(bulletrb, bulletSpawm[1].transform.position, bulletSpawm[1].transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.left * bulletSpeed);
            }
            if (buff >= 5)
            {
                clone = Instantiate(bulletrb, bulletSpawm[2].transform.position, bulletSpawm[2].transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.left * bulletSpeed);
            }
            firetimer = firerate;
        }

    }
}
