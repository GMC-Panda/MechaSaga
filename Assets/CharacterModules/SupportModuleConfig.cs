using UnityEngine;

[CreateAssetMenu(fileName = "UnnamedSupportModule", menuName = "ItemSystem/NewSupportModule", order = 0)]
public class SupportModuleConfig : ScriptableObject 
{
    [SerializeField] string supportName;
    [SerializeField] string supportDescription;
    [SerializeField] float armor;
    [SerializeField] float elementalArmor;
    [SerializeField] bool autoRegen;


}