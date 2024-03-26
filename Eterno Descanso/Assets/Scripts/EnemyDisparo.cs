using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDisparo : MonoBehaviour
{
    private Transform target;
    public float rotateSpeed = 0.003f;
    private Rigidbody2D rb;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    public Transform firePoint;
    [SerializeField] private float bulletForce;
    public float fireRate;
    private float timeToFire;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        timeToFire = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateToTarget();
        }
        if (Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if(timeToFire <= 0f)
        {
            GameObject bullet = gameObject.GetComponentInChildren<Pooling>().GetPooledObject();
            if (bullet != null)
            {

                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;

                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                Debug.Log(bulletRb.velocity);
                bullet.SetActive(true);
                bullet.gameObject.tag = "BalaEnemiga";
                bullet.GetComponent<BalaEnemiga>().BalaRebotada = false;
                bullet.GetComponent<BalaEnemiga>().desactivarAccion();
                bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

                timeToFire = fireRate;
            }
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void RotateToTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Jugador"))
        {
            target = GameObject.FindGameObjectWithTag("Jugador").transform;
        }
    }
}
