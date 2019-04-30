using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    [SerializeField] GameObject door;
    // Start is called before the first frame update
 public void OpenDoor()
    {
        door.SetActive(false);
    }
}
