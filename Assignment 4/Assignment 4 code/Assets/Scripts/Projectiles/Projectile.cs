using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Projectile", menuName = "Tower/Projectile")]
public class Projectile : ScriptableObject {

    public new string name;
    public Sprite icon = null;
    public int damage;
    public int damageOverTime;
    public string type;
}
