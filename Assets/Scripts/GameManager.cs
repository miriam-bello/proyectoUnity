using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DateTime time = new DateTime(1993, 1, 2, 7, 0,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time.AddMilliseconds(Time.deltaTime * 120 * 1000);
    }
}
