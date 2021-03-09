using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    private Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        rigidbody.AddForce (transform.forward * bulletData.BulletSpeed,ForceMode.Impulse);
    }
}
