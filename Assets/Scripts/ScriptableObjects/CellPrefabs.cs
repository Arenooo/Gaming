using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Cell Prefabs")]
public class CellPrefabs : ScriptableObject
{
    public CellController Default;
    public CellController Finish;
}
