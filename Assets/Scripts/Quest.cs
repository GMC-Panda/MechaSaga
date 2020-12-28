using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Questsystem/NewQuest", order = 0)]
public class Quest : ScriptableObject 
{
    [SerializeField] string[] tasks;    
}
