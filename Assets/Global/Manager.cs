using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    private Player player;
    private BulletPool pool;

    public static Manager Instance {
        get
        {
            if (instance == null)
            { 
                instance = GameObject.FindObjectOfType<Manager>();
            }
            return instance;
        }
    }

    public BulletPool GetPool { get { return pool; } private set { pool = value; } }
    public Player GetPlayer { get { return player; } private set { player = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        Initialize();

    }

    private void Initialize()
    {
        if(!player)
        GetPlayer = GameObject.FindObjectOfType<Player>();
        if(!pool)
        GetPool = GetComponent<BulletPool>();
    }
}
