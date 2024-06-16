using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase contiene 2 estados y una decision, ya que se trata de hacer la transicion a uno u otro estado
// tomando una decision
[CreateAssetMenu(menuName = "FSM/Transition")]
public class Transition : ScriptableObject
{
    public Decision decision;
    public BaseState state1;
    public BaseState state2;

    public void Execute(BaseStateMachine m)
    {
        //El operador is not comrpueba en tiempo de ejecucion si un objeto es o no equiparable a otro
        if(decision.Decide(m) && (state1 is not RemainInState)) m.CurrentState = state1;
        else if(state2 is not RemainInState) m.CurrentState = state2;
    }
}
