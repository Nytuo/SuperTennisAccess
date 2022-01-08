using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Version : MonoBehaviour
{
    public static string version;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        version = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Version: " + version;
    }
}
