using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //public AudioSource audioSource;

    public GameObject bulletPrefab;
    public Transform barrelEnd;
    public float bulletSpeed, TimeBetweenShots = 0.1f;
    float Timestamp;

    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        GameObject bulletInstance;
        if (Time.time >= Timestamp && Input.GetMouseButtonDown(0))
        {
            //audioSource.Play();
            bulletInstance = Instantiate(bulletPrefab, barrelEnd.transform.position, bulletPrefab.transform.rotation) as GameObject;

            bulletInstance.GetComponent<Rigidbody>().AddForce(barrelEnd.forward * bulletSpeed);
            Timestamp = Time.time + TimeBetweenShots;
        }
    }
}
