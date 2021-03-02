using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class Shooting : MonoBehaviour
{
    public static Shooting Instance;
    [SerializeField]private GameObject bullet;
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
    
    void Update()
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
                Debug.Log("BAM!");
                shotsPerSecond++;
                currentFireRate=fireRate;
            }
        }
    }
}
