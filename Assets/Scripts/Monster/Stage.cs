using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public float timeSinceStart = 0f;
    void Start()
    {
        timeSinceStart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart = Time.realtimeSinceStartup;
    }
    private void Awae()
    {
    }
}
