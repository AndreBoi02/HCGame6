using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] ObjectPooling bulletPool;
    [SerializeField] float speed;
    private Vector2 direction;

    private void Start()
    {
       bulletPool = GameObject.Find("BulletsPool").GetComponent<ObjectPooling>();
    }

    private void FixedUpdate()
    {
        Move2();
    }

    void Move2()
    {
        rb.velocity = direction * speed;
    }
    public void getDir(Transform target)
    {
        direction = (target.position - transform.position).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            print("HIT");
            other.GetComponent<EnemyMov>().DestroyObject();
            bulletPool.DespawnObject(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            print("HIT");
            bulletPool.DespawnObject(gameObject);
        }
    }
}
