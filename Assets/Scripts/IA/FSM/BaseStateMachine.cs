using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public BaseState _initialState;
    private Dictionary<Type, Component> components;

    // Start is called before the first frame update
    void Awake()
    {
        currentState = _initialState;
    }

    
    public BaseState currentState { get; set; }

    // Update is called once per frame
    void Update()
    {
        //Se ejecuta el estado actual
        currentState.Execute(this);
    }

    //Nuevo metodo de obtener componentes
    public new T GetComponent<T>() where T : Component
    {
        //Si el component que se busca ya estaba registrado, se devuelve
        if(components.ContainsKey(typeof(T))) { return (T)components[typeof(T)]; }

        //Si no:

        //Se usa el metodo de Unity de GetComponent para obtener el componente
        var component = base.GetComponent<T>();
        //Si no es nulo, se a�ade al diccionario
        if(component != null) {
            components.Add(typeof(T), component);
        }
        //Finalmente se devuelve
        return component;
    }
}
