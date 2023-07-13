using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackData : ScriptableObject
{
    public float windUp;
    public float attackDuration;
    public float lastCancellable;
    public float endLag;
    public bool enemy;
}
