using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostOfficer : MonoBehaviour
{
    public int totalplayer;
    public static PostOfficer Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
