using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleController : Singleton<ReticleController>
{
    private GameObject reticle;

    private void Start()
    {
        reticle = GameObject.Find("Reticle");
    }

    public void MoveReticle(int direction)
    {
        switch (direction)
        {
            case 1: //UP
                reticle.transform.position += new Vector3(0, 1, 0);
                break;
            case 2: //DOWN
                reticle.transform.position += new Vector3(0, -1, 0);
                break;
            case 3: //LEFT
                reticle.transform.position += new Vector3(-1, 0, 0);
                break;
            case 4: //RIGHT
                reticle.transform.position += new Vector3(1, 0, 0);
                break;
        }
    }
}
