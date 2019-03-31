using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScriptPC : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Yeeti");
    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane ground = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);

            this.transform.position = (new Vector3(pointToLook.x, Player.transform.position.y+0.5f, pointToLook.z));
        }
    }
}
