using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/FSMDefinition")]
public class FSMDef : ScriptableObject
{
    public string initialState;
    public List<string> idActions = new List<string>(); //Aquí guardas nombres para los estados (p.ej Wander1, Wander2, Sigue, etc)
    public List<string> actions = new List<string>(); //Aquí metes los nombres de las acciones que se tienen en cuenta en MachineManager
    //(WanderAction, FollowAction o HideAction) de modo que idActions[i] es una accion de tipo actions[i]


    public List<string> decisions = new List<string>(); //Lo mismo que actions pero para transiciones
    public List<string> nextActions = new List<string>(); //id de la accion a la que va idTransicions[i]
    public List<string> previousActions = new List<string>(); //id de la accion desde la que viene Transicions[i]

}
