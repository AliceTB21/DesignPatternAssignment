using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    private Player player;

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
    public Player GetPlayer { get { return player; } private set { player = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        player = GameObject.FindObjectOfType<Player>();
    }
}
