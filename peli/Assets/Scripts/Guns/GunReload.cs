using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReload : MonoBehaviour
{
    private Gun gun;
    void Start()
    {
        gun = GetComponent<Gun>();
    }

    void Update()
    {
        if (Input.GetKeyDown("r") && gun.magazineSize != gun.remainingBullets)
        {
            StartCoroutine(reloadGun());
        }
    }

    IEnumerator reloadGun()
    {
        yield return new WaitForSeconds(1.5f);
        gun.remainingBullets = gun.magazineSize;
        gun.ammoUIManager.setMaxAmmo(gun.magazineSize);
        gun.ammoUIManager.setCurrentAmmo(gun.remainingBullets);
    }
}
