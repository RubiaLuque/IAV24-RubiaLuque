using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class State
{
    //El modificador sealed hace que esta clase no pueda tener hijos

    //Se tiene una lista de acciones y transiciones
    public List<Action> actions = new List<Action>();
    public List<Transition> transitions = new List<Transition>();

    //Se ejecutan las acciones y transiciones de la maquina de estados base
    public void Execute(BaseStateMachine m)
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
