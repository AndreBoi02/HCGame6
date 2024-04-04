using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ObjectPooling objectPooling;

    [Header("Attributes")]
    [SerializeField] private float speed = 2f;

    private Transform target;
    private int pathIdx = 0;

    private void Start()
    {
        objectPooling = GameObject.Find("EnemiesPool").GetComponent<ObjectPooling>();
        target = LevelManager.main.path[pathIdx];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= .1f)
        {
            pathIdx++;
            

            if (pathIdx == LevelManager.main.path.Length)
            {
                DestroyObject();
            }
            else
            {
                target = LevelManager.main.path[pathIdx];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * speed;
    }

    public void DestroyObject()
    {
        EnemySpawner.onEnemyDestroy.Invoke();
        pathIdx = 0;
        target = LevelManager.main.path[pathIdx];
        objectPooling.DespawnObject(gameObject);
        return;
    }
}
