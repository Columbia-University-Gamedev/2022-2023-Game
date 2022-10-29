using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class GameEntity
{
    [NonSerialized]
    public Vector2Int position;
    
    [NonSerialized]
    public int health;
    
    public int maxHealth;

    public void Initialize(Vector2Int position_)
    {
        position = position_;
        health = maxHealth;
    }

    public abstract void PickGoal();
}
