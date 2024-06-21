using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public State _initialState;
    private Dictionary<Type, Component> components;

    // Start is called before the first frame update
    void Awake()
    {
        currentState = _initialState;
        components = new Dictionary<Type, Component>();
    }

    public string StateToString()
    {
        return currentState.ToString();
    }

    public State currentState { get; set; }

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
        if(components.ContainsKey(typeof(T))) { return components[typeof(T)] as T; }

        //Si no:

        //Se usa el metodo de Unity de GetComponent para obtener el componente
        var component = base.GetComponent<T>();
        //Si no es nulo, se añade al diccionario
        if(component != null) {
            components.Add(typeof(T), component);
        }
        //Finalmente se devuelve
        return component;
    }
}
