using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckPoint", menuName = "ScriptableObject/CheckPoint", order = 3)]
public class ChecKPointSO : ScriptableObject
{
    public Vector3 checkpointPosition = new Vector3();
    public Vector3 camaraCheckpointPosition = new Vector3();
    public Material checkPointMat;
}
