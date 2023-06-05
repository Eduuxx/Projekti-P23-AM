using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    
    private Transform playerCamera;

    [SerializeField]
    private TrailRenderer BulletTrail;
    [SerializeField]
    private Transform BulletSpawnPoint;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);

        // Checks if there was something which our bullet hit
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hitInfo));

            // Check if bullet hit an Entity
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                // Don't take damage if not alive and if is a player
                if (enemy.alive && enemy.name != "Player") 
                {
                    enemy.takeDamage((int)damage);
                }
            }
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }

        Trail.transform.position = Hit.point;
        Instantiate(ImpactParticleSystem, Hit.point, Quaternion.LookRotation(Hit.normal));
        Destroy(Trail.gameObject, Trail.time);
    }
}
