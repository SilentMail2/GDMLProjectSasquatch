﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    enum faction { Player, enemy}
    [SerializeField] faction type;
    [SerializeField] float time;
    [SerializeField] float timeTaken;
    bool isRandom;
    [SerializeField] private float minSpread;
    [SerializeField] private float maxSpread;
    [SerializeField] private float spread;
    [SerializeField] private float speed;
    [SerializeField] private GameObject barrelEnd;
    [SerializeField] private string barrelName;
    [SerializeField] private bool isPrime;
    [SerializeField] private bool isSpear;
    [SerializeField] private float barrelAngle;
    [SerializeField] HealthScript damageStuff;
    [SerializeField] Rigidbody rb;
    [SerializeField] float dam;
    private void Start()
    {
      
            barrelEnd = GameObject.Find(barrelName);
      
        
        
          //  barrelEnd = this.transform.parent.gameObject;
          //  barrelAngle = barrelEnd.transform.localEulerAngles.y+this.transform.localEulerAngles.y;
        

        

        spread = Random.Range(minSpread, maxSpread);

    }
    private void Update()
    {
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
        time -= timeTaken * Time.deltaTime;
        if (!isPrime)
        {
            
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
           // transform.eulerAngles = new Vector3(0, spread + barrelAngle, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {

            if (type == faction.Player)
            {

                damageStuff = other.GetComponent<HealthScript>();
                if (!damageStuff.isPlayer)
                {
                    damageStuff.TakeHealth(dam);
                    Destroy(this.gameObject);
                }


            }
            if (type == faction.enemy)
            {

                damageStuff = other.GetComponent<HealthScript>();
                if (damageStuff.isPlayer)
                {
                    damageStuff.TakeHealth(dam);
                    Destroy(this.gameObject);
                }

            }
        }
        else if (other.gameObject.layer == 15)
        {
            if (!isSpear)
            {
                Destroy(this.gameObject);
            }
            else if (isSpear)
            {
                rb.useGravity = false;
            }
        }

    }
}
