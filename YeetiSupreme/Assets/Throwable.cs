using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public bool explosive = true;
    public float time;
    public float aoeDistance;
    public SphereCollider aoe;
    public float health;
    private void Update()
    {
        aoe.radius = aoeDistance;
        time -= 1 * Time.deltaTime;
        if (time <= 0)
        {
            aoe.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<HealthScript>().TakeHealth(health);
        }
        else
        {
            return;
        }
    }
}
