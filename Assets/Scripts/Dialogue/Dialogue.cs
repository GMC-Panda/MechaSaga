using System.Collections;
using UnityEngine;

namespace RPG.Dialogue
{
    [CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogues/NewDialogue", order = 0)]
    public class Dialogue : ScriptableObject 
    {
    [SerializeField] DialogueNode[] nodes;    
    }
}


