using UnityEngine;

[CreateAssetMenu(fileName = "UnnamedWeaponModule", menuName = "ItemSystem/NewWeaponModule", order = 0)]
public class WeaponModuleConfig : ScriptableObject 
{
    [SerializeField] string weaponName;
    [SerializeField] string weaponDescription;
    [SerializeField] float baseDamage;
    [SerializeField] float rechargeTime;
    [SerializeField] bool burnStatus;
    [SerializeField] bool acidStatus;
    [SerializeField] bool kinetic;
    [SerializeField] bool energetic;
}
