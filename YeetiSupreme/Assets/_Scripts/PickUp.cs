using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Visuals")]
    [SerializeField] private Vector3 floatY;
    [SerializeField] private float originalY;
    [SerializeField] private float floatStrength;
    [SerializeField] private float Rotate;
    
    public enum pickUpType
    {
        weapon, health, throwable
    }
    public pickUpType type;
    public enum weaponType
    {
        shotgun, handgun, autoMat
    }
    public float health;
    public weaponType Weapon;
    // Start is called before the first frame update
    void Start()
    {
        originalY = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
        Floating();
    }
    private void Rotation()
    {
        transform.Rotate (new Vector3(0, Rotate * Time.deltaTime, 0));
    }
    private void Floating ()
    {
        transform.position = new Vector3(transform.position.x, originalY + (Mathf.Sin(Time.time) * floatStrength), transform.position.z);
    }

}
