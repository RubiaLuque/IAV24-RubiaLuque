using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FSM/State")]
public sealed class State : BaseState
{
    //El modificador sealed hace que esta clase no pueda tener hijos, la convierte asi en una clase abstracta

    //Se tiene una lista de acciones y transiciones
    public List<Action> actions = new List<Action>();
    public List<Transition> transitions = new List<Transition>();

    //Se ejecutan las acciones y transiciones de la maquina de estados base
    public override void Execute(BaseStateMachine m)
    {
        //El equivalente a auto en C++ es var en C#
        foreach (var action in actions)
        {
            action.Execute(m);
        }

        foreach (var transition in transitions)
        {
            transition.Execute(m);
        }
        
    }
}
