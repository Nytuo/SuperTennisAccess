using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsKeep : MonoBehaviour
{
    private  static SoundsKeep instance = null;
    public static SoundsKeep Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
