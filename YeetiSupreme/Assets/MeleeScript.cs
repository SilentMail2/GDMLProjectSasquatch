using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    [SerializeField] GameObject attackObject;
    KeyCode primaryAttack;
    KeyCode SecondaryAttack;
    [SerializeField] Animator animator;
    HealthScript enemy;
    [SerializeField] float primaryDam;
    [SerializeField] float secondaryDam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
