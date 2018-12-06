﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    public Asteroid3D asteroid;
    public GameObject UI;

    [Header("UI - Asteroid")]
    public Slider _asteroidsCount;
    public Text _txtAsteroidsCount;
    [Header("UI - Speed")]
    public Slider _asteroidsSpeed;
    public Text _txtAsteroidsSpeed;
    [Header("UI - Mass")]
    public Slider _asteroidsMass;
    public Text _txtAsteroidsMass;
    [Header("UI - Distance")]
    public Slider _asteroidsDistance;
    public Text _txtAsteroidsDistance;

    // Use this for initialization
    void Start () {
        OnResetUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickInit()
    {
        for (int i = 0; i < _asteroidsCount.value; i++)
        {
            Asteroid3D ast = Instantiate(asteroid.gameObject).GetComponent<Asteroid3D>();

            float rMass = Random.Range(1, _asteroidsMass.value);
            float rDist = Random.Range(10f, _asteroidsDistance.value);
            float rSpeed = Random.Range(100f, _asteroidsSpeed.value);

            ast.init(rMass, rDist, rSpeed);
        }

        UI.SetActive(false);
    }

    public void OnResetUI()
    {
        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("00");
        _txtAsteroidsDistance.text = _asteroidsDistance.value.ToString("00");
    }

    public void OnChangeSliderAsteroidsCount()
    {
        _txtAsteroidsCount.text = _asteroidsCount.value.ToString("00");
    }
    
    public void OnChangeSliderAsteroidsSpeed()
    {
        _txtAsteroidsSpeed.text = _asteroidsSpeed.value.ToString("00");
    }

    public void OnChangeSliderAsteroidsMass()
    {
        _txtAsteroidsMass.text = _asteroidsMass.value.ToString("000");
    }

    public void OnChangeSliderAsteroidsDistance()
    {
        _txtAsteroidsDistance.text = _asteroidsDistance.value.ToString("00");
    }
}
