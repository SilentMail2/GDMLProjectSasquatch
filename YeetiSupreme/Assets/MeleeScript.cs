using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    [SerializeField] GameObject attackObject;
    KeyCode primaryAttack;
    KeyCode SecondaryAttack;
    [SerializeField] bool isAttacking = false;
    [SerializeField] Animator animator;
    HealthScript enemy;
    [SerializeField] float primaryDam;
    [SerializeField] float secondaryDam;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
            animator.SetBool("Melee", true);
        }
    }
    public void StopMelee()
    {
        animator.SetBool("Melee", false);
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.GetComponent<HealthScript>();
            enemy.TakeHealth(primaryDam);
            attackObject = other.gameObject;
        }
    }

}
