using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterAim_Base : MonoBehaviour
{   
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector2 gunEndPointPos;
        public Vector2 shootPos;
    }

    Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        OnShootEventArgs se = new OnShootEventArgs();
        se.gunEndPointPos = tr.position;
        se.shootPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            OnShoot?.Invoke(this, se); 
    }
}
