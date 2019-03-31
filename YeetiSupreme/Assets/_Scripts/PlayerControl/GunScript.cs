using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    enum weaponType { Shotgun, Handgun, autoMat}
    [SerializeField] weaponType Weapon;
    [SerializeField] GameObject[] bullet;
    [SerializeField] GameObject barrelEnd;
    [SerializeField] GameObject Smoke;
    [SerializeField] Animator shotgunAnim;
    [SerializeField] Text ammoAmountUItext;
    [SerializeField] GameObject ammoAmmountUI;
    [SerializeField] int ammoAmount;
    [SerializeField] GameObject player;
    
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
                if (Weapon == weaponType.Shotgun)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
                        Smoke.SetActive(true);
                        Instantiate(bullet[0], barrelEnd.transform.position, barrelEnd.transform.rotation);
                        shotgunAnim.SetBool("ShotReady", false);
                        ammoAmount--;
                    }
                }
                if (Weapon == weaponType.Handgun)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
                        Smoke.SetActive(true);
                        Instantiate(bullet[0], barrelEnd.transform.position, barrelEnd.transform.rotation);
                        shotgunAnim.SetBool("ShotReady", false);
                        ammoAmount--;
                    }
                }
            }
            if (Input.GetButton("Fire1"))
            {
                if (Weapon == weaponType.autoMat)
                {
                    if (shotgunAnim.GetBool("ShotReady"))
                    {
                        Smoke.SetActive(true);
                        Instantiate(bullet[0], barrelEnd.transform.position, barrelEnd.transform.rotation);
                        shotgunAnim.SetBool("ShotReady", false);
                        ammoAmount--;

                    }
                }
            }
        }
    }

    public void ShotReady ()
    {
        Smoke.SetActive(false);
        shotgunAnim.SetBool("ShotReady", true);
        this.transform.eulerAngles = new Vector3(0, 90, 0);
    }
}
