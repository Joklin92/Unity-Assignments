using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower/Tower")]
public class Tower : ScriptableObject {

    public new string name;
    public Sprite icon = null;
    public int health;
    public int damage;
    public int damageOverTime;
    public string type;
    public int price;
    public int sellValue;
    public float fireRate;
    public float range;
    public int level;
    public Projectile projectile;
}
