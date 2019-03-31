using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] float health;
    public bool isPlayer;
    [SerializeField] float maxHealth;
    [SerializeField] bool questable;
    [SerializeField] QuestBlock quest;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject[] drop;
    private void Start()
    {
        if (isPlayer)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }
    private void FixedUpdate()
    {
        CheckDeath();
    }
    public void TakeHealth(float dam)
    {

        /*if (dam > 0)
        {*/
        if (health > 0)
        {
            health -= dam;
        }
        /*}
        if (dam < 0)
        {
            float newHealth = health;
            newHealth -= dam;
            health = Mathf.Lerp(health, newHealth, Time.deltaTime * 3);
            
        }*/
        if (isPlayer)
        {
            healthBar.value = health;
        }
    }
    public void HitByUnarmed ()
    {
        if (health>0)
        {
            health -= 5;
        }
    }
    public void CheckDeath()
    {
        if (health <= 0)
        {
            if (questable)
            {
                quest.KillAdd();
            }
            if (!isPlayer)
            {
                int randomDrop = (Random.Range(0, (drop.Length)));
                if (randomDrop > drop.Length)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    Instantiate(drop[randomDrop], transform.position, transform.rotation);
                    Destroy(this.gameObject);
                }
            }
            if (isPlayer)
            {
                Debug.Log("Yeeti no longer");
            }
        }
        else { return; }
    }
}
