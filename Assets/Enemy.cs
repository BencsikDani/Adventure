using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;
    float currentHP;
    public float shootTime = 2f;
    float currentTime;
    [SerializeField] private Transform prefabEnemyFireball;
    [SerializeField] private Transform prefabDiamond;

    private void Awake()
    {
        currentHP = maxHP;
        currentTime = shootTime;
    }

    public void Damage()
    {
        currentHP = currentHP - 10;
        if (currentHP == 0f)
        {
            Destroy(gameObject);
            Transform diamondTransform = Instantiate(prefabDiamond, gameObject.transform.position, Quaternion.identity);
            diamondTransform.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    public void Shoot()
    {
        Transform fireballTransform1 = Instantiate(prefabEnemyFireball, gameObject.transform.position, Quaternion.identity);
        Transform fireballTransform2 = Instantiate(prefabEnemyFireball, gameObject.transform.position, Quaternion.identity);
        Transform fireballTransform3 = Instantiate(prefabEnemyFireball, gameObject.transform.position, Quaternion.identity);
        Transform fireballTransform4 = Instantiate(prefabEnemyFireball, gameObject.transform.position, Quaternion.identity);
        Transform fireballTransform5 = Instantiate(prefabEnemyFireball, gameObject.transform.position, Quaternion.identity);
        Vector3 dir1 = new Vector2(0.5f, 1).normalized;
        Vector3 dir2 = new Vector2(0.25f, 1).normalized;
        Vector3 dir3 = Vector2.up.normalized;
        Vector3 dir4 = new Vector2(-0.25f, 1).normalized;
        Vector3 dir5 = new Vector2(-0.5f, 1).normalized;
        fireballTransform1.GetComponent<EnemyFireball>().Setup(dir1);
        fireballTransform2.GetComponent<EnemyFireball>().Setup(dir2);
        fireballTransform3.GetComponent<EnemyFireball>().Setup(dir3);
        fireballTransform4.GetComponent<EnemyFireball>().Setup(dir4);
        fireballTransform5.GetComponent<EnemyFireball>().Setup(dir5);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0f)
        {
            Shoot();
            currentTime = shootTime;
        }
    }
}
