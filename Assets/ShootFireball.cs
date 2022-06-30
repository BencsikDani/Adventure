using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootFireball : MonoBehaviour
{
    [SerializeField] private Transform prefabFireball;
    public bool shootIsOn;
    private void Awake()
    {
        GetComponent<CharacterAim_Base>().OnShoot += OnShootFireball;
        shootIsOn = false;
    }

    private void OnShootFireball(object sender, CharacterAim_Base.OnShootEventArgs e)
    {
        if (shootIsOn)
        {
            Transform fireballTransform = Instantiate(prefabFireball, e.gunEndPointPos, Quaternion.identity);
            Vector3 dir = (e.shootPos - e.gunEndPointPos).normalized;
            fireballTransform.GetComponent<Fireball>().Setup(dir);
        }
    }
}
