using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    public Transform firePoint;


    public float bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = gameObject.GetComponent<Pooling>().GetPooledObject();
        if (bullet != null)
        {

            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;

            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            Debug.Log(bulletRb.velocity);
            bullet.SetActive(true);
            bullet.GetComponent<Bala>().desactivarAccion();
            Debug.Log(bulletRb.velocity);
            bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        }
    }
}
