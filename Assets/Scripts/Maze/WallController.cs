using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public void Toggle(bool state) => gameObject.SetActive(state);
}
