using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col)
        {
            col.gameObject.SetActive(false);
        }
    }
}
