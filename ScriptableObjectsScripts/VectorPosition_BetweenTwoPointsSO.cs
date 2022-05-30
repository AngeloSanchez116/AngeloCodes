using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VectorPostionBetweenTwoPoints", menuName = "ScriptableObject/VectorPostionBetweenTwoPoints", order = 4)  ]
public class VectorPosition_BetweenTwoPointsSO : ScriptableObject
{
    public List<Vector3> startPoint = new List<Vector3>();
    public List<Vector3> endPoint = new List<Vector3>();
}
