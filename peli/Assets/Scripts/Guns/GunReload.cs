using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReload : MonoBehaviour
{
    private Gun gun;
    public AudioClip reloadSfx;
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
        doReloadSound(0.45);
        yield return new WaitForSeconds(1.5f);
        gun.remainingBullets = gun.magazineSize;
        gun.ammoUIManager.setMaxAmmo(gun.magazineSize);
        gun.ammoUIManager.setCurrentAmmo(gun.remainingBullets);
    }

    void doReloadSound(double volume)
    {
        AudioSource.PlayClipAtPoint(reloadSfx, transform.position, (float)volume);
    }
}
