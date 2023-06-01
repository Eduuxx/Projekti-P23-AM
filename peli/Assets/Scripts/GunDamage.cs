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

        // Checks if there was something which our bullet hit
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, bulletRange))
        {
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
}
