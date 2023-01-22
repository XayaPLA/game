using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float BulletSpeed = 70f;
    public GameObject ImpactEffect;
    public float ExplosionRadious = 0;
    BuildManager buildManager;


    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float DistanceThisFrame = BulletSpeed * Time.deltaTime;

        if (dir.magnitude <= DistanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * DistanceThisFrame, Space.World);

        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject EffectIns = (GameObject)Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(EffectIns, 1f);

        if (ExplosionRadious > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] HitObjects = Physics.OverlapSphere(transform.position, ExplosionRadious);
        foreach(Collider collider in HitObjects)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadious);    
    }
}