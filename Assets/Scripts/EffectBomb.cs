using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBomb : MonoBehaviour
{
    public GameObject Bombs;
    //private float Timer = 1.5f;

    void Update()
    {
        Destroy(gameObject);
        Destroy(Bombs);
    }
}
