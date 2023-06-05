using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentAmmo(int currentAmmo)
    {
        GameObject.Find("Current").GetComponent<UnityEngine.UI.Text>().text = currentAmmo.ToString();
    }

    public void setMaxAmmo(int maxAmmo)
    {
        GameObject.Find("Max").GetComponent<UnityEngine.UI.Text>().text = maxAmmo.ToString();
    }
}
