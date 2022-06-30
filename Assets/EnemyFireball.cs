using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    Vector3 dir;
    Collider2D enemyCd;
    public float moveSpeed = 3f;
    private void Awake()
    {
        enemyCd = GameObject.Find("Enemy").GetComponent<BoxCollider2D>();
    }

    public void Setup(Vector3 dir)
    {
        this.dir = dir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
        Destroy(gameObject, 2f);
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
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.Damage();
        }
        if (collision.GetComponent<Collider2D>() != (Collider2D)enemyCd
            && collision.gameObject.name != "EnemyFireball(Clone)")
            Destroy(gameObject);
    }
}
