﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    GameManager.Instance.PlayerPosition(this.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
