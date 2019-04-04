using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoverScript : MonoBehaviour
{
    public void Rotate()
    {
        this.transform.rotation = new Quaternion (0, 90, 0, 0);
    }
}
