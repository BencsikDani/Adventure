using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    Vector3 dir;
    Collider2D playerCd;
    public float moveSpeed = 4f;
    private void Awake()
    {
        playerCd = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
    }

    public void Setup(Vector3 dir)
    {
        this.dir = dir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
        Destroy(gameObject, 5f);
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
            n += 360;
        return n;
    }

    private void Update()
    {
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage();
        }
        if (collision.GetComponent<Collider2D>() != (Collider2D)playerCd
            && collision.gameObject.name != "Fireball(Clone)")
            Destroy(gameObject);
    }
}
