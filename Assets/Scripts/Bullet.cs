using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData bulletData;
    [SerializeField] bool cleanDecals;
    [SerializeField] private float timeToDestroy=5f;
    private Rigidbody rigidbody;
    private Collider collider;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rigidbody.mass = bulletData.BulletMass;
    }
    
    
    // Update is called once per frame
    void Start()
    {
        ShootBullet();
        StartCoroutine("TimeToDestroy",timeToDestroy);
    }

    void ShootBullet()
    {
        rigidbody.AddForce (transform.forward * bulletData.BulletSpeed,ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision bullet)
    {
        if(bullet.gameObject.layer!=8)
        {
            if(!cleanDecals)
            {
                Destroy(transform.parent.gameObject);
            }
            collider.isTrigger=true;
            rigidbody.isKinematic=true;

            //transform.parent.gameObject.transform.SetParent(bullet.transform); 
            timeToDestroy-=Time.deltaTime; 
        }
    }
    
    public IEnumerator TimeToDestroy(float time)
    {
        if(cleanDecals)
        {
            yield return new WaitForSecondsRealtime(time);
            Destroy(transform.parent.gameObject);
        }
        else
        {
            yield return null;
        }
    }
}
