using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEnemyVisual : MonoBehaviour
{
    private void Awake()
    {
        GameObject go = Instantiate(CombatManager.enemyVisual);
        go.transform.position = new Vector3(0, 0, -3);
        go.transform.Rotate(new Vector3(0, 180, 0));
        go.transform.parent = this.transform;
    }
}
