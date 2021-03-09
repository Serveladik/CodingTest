using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Bullet Data", menuName = "Bullet Data", order = 51)]
public class BulletData : ScriptableObject
{
    [SerializeField]private string bulletName;
    [SerializeField]private string bulletDescription;
    [SerializeField]private float bulletMass;
    [SerializeField]private float bulletDamage;
    [SerializeField]private float bulletSpeed;

    public string BulletName
    {
        get
        {
            return bulletName;
        }
    }

    public string BulletDescription
    {
        get
        {
            return bulletDescription;
        }
    }

    public float BulletMass
    {
        get
        {
            return bulletMass;
        }
    }

    public float BulletDamage
    {
        get
        {
            return bulletDamage;
        }
    }

    public float BulletSpeed
    {
        get
        {
            return bulletSpeed;
        }
    }

}
