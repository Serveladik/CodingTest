using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;
    GameObject bulletsParent;

    [SerializeField]private BulletData bulletDataPrefab;
    [SerializeField]private Transform muzzlePosition;
    [SerializeField]private int maxBullets;
    [SerializeField]private int clipBullets;
    [SerializeField] [Range (0.01f,1f)] private float fireRate;
    public float shotsPerSecond=0f;
    private float timer=0f;
    private float currentFireRate;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        
        currentFireRate = fireRate;
        bulletsParent = new GameObject("BulletsParent");

    }
   


    void CalculateShotsPerSecond()
    {
        if(timer>=1f)
        {
            Debug.LogError("Shots Per Second: "+ shotsPerSecond);
            timer=0f;
            shotsPerSecond=0f;
        }
    }
    
    void FixedUpdate()
    {
        CalculateShotsPerSecond();
        Shoot();
    }
    void Shoot()
    {
        currentFireRate-=Time.deltaTime;
        if(Input.GetMouseButton(0))
        {
            timer+=Time.deltaTime;
            if(currentFireRate <=0)
            {
                GameObject bullets = (GameObject)Instantiate(bulletDataPrefab.BulletPrefab,muzzlePosition.position,muzzlePosition.rotation);
                //new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.80f)
                //bullets.transform.parent = muzzlePosition;
                //bullets.transform.localRotation = Quaternion.Euler(90,0,0);
                

                
                
                //Debug.Log(muzzlePosition.position);
                shotsPerSecond++;
                currentFireRate=fireRate;
            }
        }
    }
}
