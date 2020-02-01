﻿using UnityEngine;

public class AsteroidExplosionController : MonoBehaviour
{
    // TODO: Separate in general component ?
    float timer;

    void OnEnable()
    {
        timer = 1;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
