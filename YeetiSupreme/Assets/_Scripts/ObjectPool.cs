using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Weapons")]
    public GameObject[] Weapons;
    #region Singleton
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
