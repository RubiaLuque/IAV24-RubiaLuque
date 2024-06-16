using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{
    //Obtiene una referencia a BaseStateMachine y se la pasa a las acciones y decisiones
    public virtual void Execute(BaseStateMachine m) { }
}
