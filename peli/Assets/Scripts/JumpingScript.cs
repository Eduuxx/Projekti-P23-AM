using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    public GameObject jumping;

    // Start is called before the first frame update
    void Start()
    {
        jumping.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Jumpings();
        }


        if (Input.GetKeyUp("space"))
        {
            StopJumpings();
        }

    }

    void Jumpings()
    {
        jumping.SetActive(true);
    }

    void StopJumpings()
    {
        jumping.SetActive(false);
    }
}