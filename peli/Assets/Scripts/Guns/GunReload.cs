using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunReload : MonoBehaviour
{
    private Gun gun;
    public float reloadDelayInSeconds = 2.2f;
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
        doReloadSound(0.6);
        yield return new WaitForSeconds(reloadDelayInSeconds);
        gun.remainingBullets = gun.magazineSize;
        gun.ammoUIManager.setMaxAmmo(gun.magazineSize);
        gun.ammoUIManager.setCurrentAmmo(gun.remainingBullets);
    }

    void doReloadSound(double volume)
    {
        AudioSource.PlayClipAtPoint(reloadSfx, transform.position, (float)volume);
    }
}
