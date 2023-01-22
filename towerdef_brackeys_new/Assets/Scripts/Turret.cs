using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Attributes")]

    public float range = 15f;
    public float FireRate = 1f;
    private float FireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float rotationSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);    
    }

    //find target
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject NearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                NearestEnemy = enemy;
                shortestDistance = distanceToEnemy;
            }
        }

        if (NearestEnemy != null && shortestDistance <= range)
        {
            target = NearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    //rotate and initiate shot
  void Update()
    {
        if (target == null) return;

        Vector3 directionToEnemy = target.position - transform.position;
        Quaternion lookRotation =  Quaternion.LookRotation(directionToEnemy);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, rotationSpeed*Time.deltaTime).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y,0f);
        
        if(FireCountDown <= 0)
        {
            Shoot();
            FireCountDown = 1 / FireRate;
        }
        FireCountDown -= Time.deltaTime;
    }

    //Pew-pew
    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}
