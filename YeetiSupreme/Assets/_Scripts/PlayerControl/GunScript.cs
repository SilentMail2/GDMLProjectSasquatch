using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    enum weaponType { Shotgun, Handgun, autoMat, unarmed, spear}
    [SerializeField] weaponType Weapon;
    [SerializeField] GameObject[] bullet;
    [SerializeField] GameObject barrelEnd;
    [SerializeField] GameObject Smoke;
    [SerializeField] Animator shotgunAnim;
    [SerializeField] Text ammoAmountUItext;
    [SerializeField] GameObject ammoAmmountUI;
    [SerializeField] int ammoAmount;
    [SerializeField] GameObject player;
    [SerializeField] float punchDist;
    // Start is called before the first frame update
    void Start()
    {
        ammoAmmountUI = GameObject.FindGameObjectWithTag("ammoUI");
       // ammoAmmountUI.SetActive(true);
        ammoAmountUItext = GameObject.Find("AmmoUIText").GetComponent<Text>();
        ammoAmountUItext.text = ammoAmount.ToString();
        player = GameObject.Find("Yeeti");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ammoAmount<=0)
        {
            player.GetComponent<Player_Control>().UnArm();
            player.GetComponent<Player_Control>().hasGun = false;
          //  ammoAmmountUI.SetActive(false);
            Destroy(this.gameObject);
        }
        ammoAmountUItext.text = ammoAmount.ToString();
        if (FindObjectOfType<Player_Control>().inDialogue == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Weapon == weaponType.spear)
                {
                    FireShot();
                }
                if (Weapon == weaponType.Shotgun)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
 
                        shotgunAnim.SetBool("ShotReady", false);

                    }
                }
                if (Weapon == weaponType.Handgun)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
                        Smoke.SetActive(true);
                        shotgunAnim.SetBool("ShotReady", false);

                    }
                }
                if (Weapon == weaponType.unarmed)
                {
                    
                }
            }
            if (Input.GetButton("Fire1"))
            {
                if (Weapon == weaponType.autoMat)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
                        Smoke.SetActive(true);
                        shotgunAnim.SetBool("ShotReady", false);

                    }
                }
            }

        }
    }

    public void ShotReady ()
    {
        Smoke.SetActive(false);
        shotgunAnim.SetBool("ShotReady", true);
        //this.transform.eulerAngles = new Vector3(0, 90, 0);
    }
    public void Punch()
    {
        int layermask = 11;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, punchDist, layermask))
        {
            HealthScript enemy = hit.transform.gameObject.GetComponent<HealthScript>();
            enemy.TakeHealth(5);
        }
    }
    public void Swing()
    { }
    public void FireShot()
    {
        if (Weapon != weaponType.autoMat)
        {
            Smoke.SetActive(true);
            Instantiate(bullet[0], barrelEnd.transform.position, barrelEnd.transform.rotation);
            ammoAmount--;
            Smoke.SetActive(false);
            shotgunAnim.SetBool("ShotReady", true);
           // this.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Weapon == weaponType.autoMat)
        {
            if (!shotgunAnim.GetBool("ShotReady"))
            {
                Smoke.SetActive(true);
                Instantiate(bullet[0], barrelEnd.transform.position, barrelEnd.transform.rotation);
                ammoAmount--;
                Smoke.SetActive(false);
                shotgunAnim.SetBool("ShotReady", true);
            //    this.transform.eulerAngles = new Vector3(0, 90, 0);
            }
        }
    }
    // press/hold trigger, play animation, at animation point fireshot
}
