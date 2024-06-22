using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase contiene 2 estados y una decision, ya que se trata de hacer la transicion a uno u otro estado
// tomando una decision
public sealed class Transition
{
    public Decision decision;
    public State state1;
    public State state2;

    public void Execute(BaseStateMachine m)
    {
        if(decision.Decide(m)) m.currentState = state1;
        else m.currentState = state2;
    }
}
