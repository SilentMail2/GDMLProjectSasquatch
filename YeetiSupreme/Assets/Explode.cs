using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Explode : MonoBehaviour
{
    [SerializeField] bool story;
    public string message;
    public GameObject Explosive;

    public void ExplodeThisObject()
    {
        if (story)
        {
            Flowchart.BroadcastFungusMessage(message);
        }
        Instantiate(Explosive);
        Destroy(this.gameObject);
    }
}
