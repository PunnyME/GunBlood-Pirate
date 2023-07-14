using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform bulletSpawnPosition;

    [SerializeField]
    private GameObject BulletPrefab;

    [SerializeField]
    private float bulletSpeed = 10f;

    public void FireBullet()
    {
        var bullet = Instantiate(BulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPosition.up * bulletSpeed;
    }
}
