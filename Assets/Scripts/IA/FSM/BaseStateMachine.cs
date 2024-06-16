using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public BaseState _initialState;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentState = _initialState;
    }

    //Getter y setter que devuelve una referencia a BaseState
    public BaseState CurrentState { get; set; }

    // Update is called once per frame
    void Update()
    {
        //Se ejecuta el estado actual
        CurrentState.Execute(this);
    }
}
