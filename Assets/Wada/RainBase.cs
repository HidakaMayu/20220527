using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RainBase : MonoBehaviour
{
    protected int damage;
    protected float speed;
    protected GameObject spawnEnemy;

    public abstract void RainType();
}
