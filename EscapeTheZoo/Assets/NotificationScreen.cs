using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScreen : MonoBehaviour {

    string notifyText;
    float startTime;
    float duration;
    public Text textBox;
    static NotificationScreen instance;
    // Use this for initialization
    public static NotificationScreen getInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {

        notifyText = "This is your time to escape!!!" +
            " 1. Find keys and free your friends" +
            " 2. Avoid the securityguards" +
            " 3. Escape the Zoo";
        startTime = Time.time;
        duration = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime & (startTime + duration) > Time.time)
        {
            textBox.text = notifyText;
        }
        else
            textBox.text = "";
    }

    public void displayNotification(string msg, float sTime, float length)
    {
        notifyText = msg;
        duration = length;
        startTime = sTime;
    }
}
