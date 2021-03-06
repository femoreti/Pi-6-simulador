﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    [Range(-45,45)]
    public float initialRot;
    public float initialVelocity;
    public Text dataText;
    public Transform earth;

    Rigidbody2D rb;
    float maxVelocity = 0;
    float maxDistance = 0, minDistance = 0;

    Vector2 initialPos;

    bool canStart = false;

    private void Awake()
    {
        initialPos = transform.position;
    }

    // Use this for initialization
    public void Init ()
    {
        gameObject.SetActive(true);
        Vector3 dir = Quaternion.AngleAxis(initialRot, Vector3.forward) * Vector3.left;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (dir*initialVelocity);
        transform.eulerAngles = new Vector3(0, 0, initialRot);
        minDistance = Vector2.Distance(transform.position, earth.transform.position);

        canStart = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (!canStart)
            return;

        if (rb.velocity.magnitude > maxVelocity)
            maxVelocity = rb.velocity.magnitude;

        float dist = Vector2.Distance(transform.position, earth.transform.position);

        if (dist > maxDistance) maxDistance = dist;
        if (dist < minDistance) minDistance = dist;

        if(dataText != null)
            GetData();

        if (dist < 50)
        {
            gameObject.SetActive(false);
            //OnReset();
        }
	}

    public void GetData()
    {
        int angleEntrance = Mathf.RoundToInt((initialRot > 0) ? initialRot : 360 - 45f);

        string strResult = string.Format("" +
            "<color=#000000ff>Stochastic variables</color>\n" +
            "<color=#ff0000ff>Planet Mass = {1}\n" +
            "Asteroid Mass = {2}\n" +
            "Initial Speed = {3}\n" +
            "Initial Entrance Angle = {4}</color>\n" +
            "\n<color=#000000ff>Simulation Status</color>\n" +
            "High Speed = {0}\n" +
            "Max Distance = {5}\n" +
            "Min Distance = {6}\n",
            maxVelocity, earth.GetComponent<Rigidbody2D>().mass, rb.mass, initialVelocity, angleEntrance, maxDistance, minDistance);

        dataText.text = strResult;
    }

    public void OnReset()
    {
        transform.position = initialPos;
        canStart = false;
        rb.velocity = Vector2.zero;

        maxVelocity = 0;
        maxDistance = 0;
        minDistance = 0;
    }
}
