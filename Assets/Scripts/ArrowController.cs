using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    private void Update()
    {
        var from = new Vector2(PlayerController.Instance.transform.position.x, PlayerController.Instance.transform.position.z);
        var to = new Vector2(MazeGenerator.Instance.FinishPosition.x, MazeGenerator.Instance.FinishPosition.z);
        var diff = (to - from).normalized;
        var angle = Mathf.Asin(diff.y) * Mathf.Rad2Deg * Mathf.Sign(diff.x) - (diff.x > 0 ? 0 : 180);
        transform.rotation = Quaternion.Euler(90, 0, angle);
    }
}