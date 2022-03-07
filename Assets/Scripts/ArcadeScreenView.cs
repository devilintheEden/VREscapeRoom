using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArcadeScreenView : MonoBehaviour
{
    public void CurrentSeqUpdateView(string[] content)
    {
        Debug.Log("Current Seq Update: " + String.Join(",", content));
    }

    public void SubmitUpdateView(int[] content)
    {
        Debug.Log("Submit Update: " + content[0] + "a" + content[1] + "b");
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
