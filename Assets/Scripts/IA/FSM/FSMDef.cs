using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/FSMDefinition")]
public class FSMDef : ScriptableObject
{
    public string initialAction;
    public List<string> actions = new List<string>();
    public List<string> decisions = new List<string>();
    public List<string> nextActions = new List<string>();

}
