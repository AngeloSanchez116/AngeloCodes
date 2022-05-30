using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlashAnimation : MonoBehaviour
{
    [Header("Flash Setup")]
    public Material spirteRender;
    public Material flashRender;
    public MeshRenderer enemyMeshRender;
    public SkinnedMeshRenderer enemyMeshRend;

    public void GetTexture()
    {
        if (GetComponentInChildren<SkinnedMeshRenderer>() != null)
        {
            spirteRender = GetComponentInChildren<SkinnedMeshRenderer>().material;
            enemyMeshRend = GetComponentInChildren<SkinnedMeshRenderer>();
        }
        else if (GetComponentInChildren<MeshRenderer>() != null)
        {

            spirteRender = GetComponentInChildren<MeshRenderer>().material;
            enemyMeshRender = GetComponentInChildren<MeshRenderer>();
        }
    }

    public void setFlash() {

        if (enemyMeshRend != null)
        {

            enemyMeshRend.material = flashRender;
        }
        else if (enemyMeshRender != null)
        {

            enemyMeshRender.material = flashRender;
        }
        Invoke("ResetMaterial", .1f);
    }
    public void ResetMaterial()
    {

        if (enemyMeshRend != null)
        {
            enemyMeshRend.material = spirteRender;
        }
        else if (enemyMeshRender != null)
        {

            enemyMeshRender.material = spirteRender;
        }
    }

    public IEnumerator PassFlashMaterial()
    {

        ResourceRequest resourceRequest = Resources.LoadAsync<Material>("Material/M_Flash");
        while (!resourceRequest.isDone)
        {
            yield return 0;
        }
        flashRender = resourceRequest.asset as Material;
    }
}
