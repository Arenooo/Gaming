using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private List<WallController> _walls;

    public void ToggleWall(bool state, Wall wall)
    {
        _walls[(int) wall].Toggle(state);
        Debug.Log("toggling " + wall);
    }
}

public enum Wall
{
    Left,
    Right,
    Top,
    Bottom
}
