using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public float damage;
    public float bulletRange;
    
    private Transform playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    public void Shoot()
    {
        Ray gunRay = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                // No point firing if already dead
                if (enemy.alive) 
                {
                    enemy.HP -= damage;
                }
            }
        }
        
    }
}