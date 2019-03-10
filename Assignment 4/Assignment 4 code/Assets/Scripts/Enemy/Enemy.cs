
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Enemy")]
public class Enemy : ScriptableObject {

    public new string name;
    public Sprite icon;
    public int health;
    public int movementSpeed;
    public int damage;
    public int atkRate;
    public int scoreValue;
    public int currencyValue;
}
