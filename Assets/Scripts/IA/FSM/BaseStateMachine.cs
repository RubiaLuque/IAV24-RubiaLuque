using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public FSMDef definition;
    private MachineManager machineManager;
    //public State _initialState;
    private Dictionary<Type, Component> components;
    private Dictionary<string, State> states;
    public State currentState;


    // Start is called before the first frame update
    void Awake()
    {
        components = new Dictionary<Type, Component>();
        states = new Dictionary<string, State>();
        machineManager = GameObject.Find("MachineManager").GetComponent<MachineManager>();

        for (int i = 0; i < definition.idActions.Count; ++i) //Se crean los estados y se guardan con su id
        {
            State s = new State();
            s.actions.Add(MachineManager.CreateAction(definition.actions[i]));
            states[definition.idActions[i]] = s;
        }

        for (int i = 0; i < definition.decisions.Count; ++i)
        {
            Transition t = new Transition();
            t.decision = MachineManager.CreateDecision(definition.decisions[i]);
            t.state2 = states[definition.previousActions[i]];
            t.state1 = states[definition.nextActions[i]];
            t.state2.transitions.Add(t);
        }

        currentState = states[definition.initialState];
    }

    public string StateToString()
    {
        return currentState.ToString();
    }


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
        if (components.ContainsKey(typeof(T))) { return components[typeof(T)] as T; }

        //Si no:

        //Se usa el metodo de Unity de GetComponent para obtener el componente
        var component = base.GetComponent<T>();
        //Si no es nulo, se añade al diccionario
        if (component != null)
        {
            components.Add(typeof(T), component);
        }
        //Finalmente se devuelve
        return component;
    }
}
