using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2OpenDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject destButton;
    public GameObject boom;

    public MeshRenderer Lvl2Mesh;
    public MeshCollider lvl2Collider;
    public Animator dooranimator;
    private void Awake()
    {
        Lvl2Mesh = GetComponent<MeshRenderer>();
        lvl2Collider = GetComponent<MeshCollider>();
    }
    private void Start()
    {
        dooranimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) {

            if (Lvl2Mesh.isVisible == true) {

                Lvl2Mesh.enabled = false;
                lvl2Collider.enabled = false;
                StartCoroutine(goboom());
                destButton.SetActive(true);
                if (door != null) {
                    dooranimator.enabled = true;
                }
            }
        }
    }

    IEnumerator goboom() {

        boom.SetActive(true);
        yield return new WaitForSeconds(1f);
        boom.SetActive(false);
    }
}
