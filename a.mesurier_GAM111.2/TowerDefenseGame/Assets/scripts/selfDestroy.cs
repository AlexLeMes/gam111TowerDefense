using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour {

    public float destoryTime = 2f;

    void Awake()
    {
        Destroy(this.gameObject, destoryTime);
    }
}
