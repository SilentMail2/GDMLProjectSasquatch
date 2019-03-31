using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Control : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] public bool inDialogue;
    float yRot;
    float mouseX;
    float mouseY;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private Vector3 camPos;
    [SerializeField] private CharacterController cc;
    [Space(10)]
    [Header("Weapon")]
    [SerializeField] private GameObject ObjectPool;
    [SerializeField] private GameObject weaponSpawn;
    [SerializeField] private GameObject[] weaponList;
    [SerializeField] private float rotSp;
    public bool hasGun;
    [SerializeField] private int ammo;
    [SerializeField] private int maxAmmo;
    [SerializeField] private float health;
    [SerializeField] private PickUp pickUpScript;
    [SerializeField] private GameObject equppedWeapon;
    [SerializeField] GameObject unarmedObject;
    public bool unarmedReady;


    [SerializeField] GameObject targetCursor;


   
    private enum WeaponType
    {
        Unarmed, Shotgun, Handgun, autoMat
    }
    [SerializeField] private WeaponType weapon;

    [Space(10)]
    [Header("Health")]
    [SerializeField] private float hp;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        ObjectPool = GameObject.FindGameObjectWithTag("ObjectPool");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        EquipGun(weapon);
        targetCursor = GameObject.Find("CrossHair");
    }
    

    // Update is called once per frame
    void Update()
    {
        if (!inDialogue)
        {
           /* if (weapon == WeaponType.Unarmed)
            {
                if (Input.GetButtonDown("Fire1") && unarmedReady)
                {
                    Instantiate(unarmedObject, weaponSpawn.transform.position, weaponSpawn.transform.rotation,weaponSpawn.transform);
                    unarmedReady = false;

                }
            }*/

            Cursor.lockState = CursorLockMode.Confined;
            Moving();
            Dash();
            cameraMovement();
            Rotation();
            Cursor.visible = false;
            targetCursor.SetActive(true);
        }
        if (inDialogue)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            targetCursor.SetActive(false);
        }
    }

    private void Moving()
    {
        cc.transform.Translate(new Vector3((Input.GetAxis("Horizontal") * speed * Time.deltaTime), 0, (Input.GetAxis("Vertical") * speed * Time.deltaTime)));
    }
    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
        {
            //Dashleft
            cc.transform.Translate (-dashSpeed*Time.deltaTime,0,0);
                }
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            //Dashright
            cc.transform.Translate(dashSpeed * Time.deltaTime, 0, 0);
        }
    }
    private void cameraMovement()
    {
        playerCamera.transform.position = this.transform.position + camPos;
    }
    float AnglebetweenTwopoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    private void Rotation()
    {
        /* Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

         Plane ground = new Plane(Vector3.up, new Vector3(0,this.transform.position.y,0));
         float rayLength;
         if (ground.Raycast(cameraRay, out rayLength))
         {
             Vector3 pointToLook = cameraRay.GetPoint(rayLength);

             transform.LookAt(new Vector3(pointToLook.x,pointToLook.y,pointToLook.z));
         }
         */
        Vector3 pointLook = targetCursor.transform.position;
        transform.LookAt(new Vector3(pointLook.x, this.transform.position.y, pointLook.z));


      //  yRot += (Input.GetAxis("Rotate") * rotSp * Time.deltaTime);
        //transform.eulerAngles = new Vector3(0, yRot, 0);
    }
    private void EquipGun(WeaponType weaponSelected)
    {
        Debug.Log("Pickup Gun");
        weapon = weaponSelected;
        if (weapon == WeaponType.Shotgun)
        {
            Instantiate(weaponList[0], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
        if (weapon == WeaponType.Handgun)
        {
            Instantiate(weaponList[1], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
        if (weapon == WeaponType.autoMat)
        {
            Instantiate(weaponList[2], weaponSpawn.transform.position, Quaternion.identity, weaponSpawn.transform);
            equppedWeapon = GameObject.FindGameObjectWithTag("PlayersGun");
            equppedWeapon.transform.localEulerAngles = weaponSpawn.transform.localEulerAngles;
            hasGun = true;
            unarmedObject.SetActive(false);
        }
       /* if (weapon == WeaponType.Unarmed)
        {
            unarmedObject.SetActive(true);
            hasGun = false;

        }*/


    }

    /*void TakeDamage(float dam)
    {
        hp -= dam;
        if (hp<=0)
        {
            Debug.Log("I diagnose you as dead");
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
       /* if (other.tag == "Bullet")
        {
            TakeDamage(5);
        }*/
        if (other.tag == "pickup")
        {
            pickUpScript = other.gameObject.GetComponent<PickUp>();
            if (pickUpScript.type == PickUp.pickUpType.weapon)
            {
                if (pickUpScript.Weapon == PickUp.weaponType.handgun)
                {
                    if (!hasGun)
                    {
                        EquipGun(WeaponType.Handgun);
                        other.gameObject.SetActive(false);
                        pickUpScript = null;
                    }
                    if (hasGun) { return; }
                }
                if (pickUpScript.Weapon == PickUp.weaponType.shotgun)
                {
                    if (!hasGun)
                    {
                        EquipGun(WeaponType.Shotgun);
                        other.gameObject.SetActive(false);
                        pickUpScript = null;
                    }
                    if (hasGun) { return; }
                }
                if (pickUpScript.Weapon == PickUp.weaponType.autoMat)
                {
                    if (!hasGun)
                    {
                        EquipGun(WeaponType.autoMat);
                        other.gameObject.SetActive(false);
                        pickUpScript = null;
                    }
                    if (hasGun) { return; }
                }


            }
            if (pickUpScript.type == PickUp.pickUpType.health)
            {
                this.GetComponent<HealthScript>().TakeHealth(pickUpScript.health);
                other.gameObject.SetActive(false);
                pickUpScript = null;
            }
        }
    }
    public void UnArm()
    {
        weapon = WeaponType.Unarmed;
    }
    public void DialogueExit()
    {
        inDialogue = false;
    }
}
