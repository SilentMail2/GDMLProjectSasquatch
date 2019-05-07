using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] string chestType;
    [SerializeField] int explodeGel;
    [SerializeField] int coin;
    [SerializeField] bool disguised;
    [SerializeField] bool key;
    public bool locked;
    public PlayerInventory inventory;
    public void OpenChest()
    {
        anim.SetBool("IsOpened", true);
        Fungus.Flowchart.BroadcastFungusMessage("Chest" + chestType);

    }
    public void addItem()
    {
        if (key)
        {
            inventory.hasKey = true;
        }
        if (disguised)
        {
            inventory.disguise = true;
        }
        inventory.exploGel += explodeGel;
        inventory.coin += coin;
        coin = 0;
        explodeGel = 0;
        disguised = false;
        key = false;
    }
}
