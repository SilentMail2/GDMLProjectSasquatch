using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistScript : MonoBehaviour
{
    [SerializeField] Player_Control player;
    [SerializeField] Animator animator;
    [SerializeField] HealthScript enemy;
    private void Awake()
    {

        player = GameObject.Find("Yeeti").GetComponent<Player_Control>();
        player.unarmedReady = false;
    }
    public void hitTarget()
    {

        enemy.TakeHealth(5);
        DestroySelf();
    }
    public void DestroySelf()
    {
        player.unarmedReady = true;
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Debug.Log("HasHitEnemy");
            enemy = other.GetComponent<HealthScript>();
            hitTarget();
        }
    }
}
