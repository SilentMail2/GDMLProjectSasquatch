using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    public bool hasKey;
    [SerializeField] Text key;
    public int exploGel;
    [SerializeField] Text gel;
    public bool disguise;
   // [SerializeField] Text disguised;
    public int coin;
    [SerializeField] Text coins;
    public int expl;
    [SerializeField] Text explosives;

    private void Start()
    {
        if (hasKey)
        {
            key.text = "1";
        }
        if (!hasKey)
        {
            key.text = "0";
        }
        gel.text = exploGel.ToString();
        coins.text = coin.ToString();
        explosives.text = expl.ToString();
    }
    private void Update()
    {
        if (hasKey)
        {
            key.text = "1";
        }
        if (!hasKey)
        {
            key.text = "0";
        }
        gel.text = exploGel.ToString();
        coins.text = coin.ToString();
        explosives.text = expl.ToString();
        if (expl<0)
        { expl = 0; }
        if (coin < 0)
        {
            coin = 0;
        }
        if (exploGel < 0)
        {
            exploGel = 0;
        }
    }


}
