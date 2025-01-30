using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Список с состояниями
    [SerializeField] private List<State> _state;   
   
    void Update()
    {        
        float maxRadius = 0;

        State stateCurrent = null;

        foreach (var state in _state) 
        {
            var radius = state.Evaluate();

            if (maxRadius < radius)
            {
                maxRadius = radius;

                stateCurrent = state;
            }
        }

        if (stateCurrent != null) 
        { 
            stateCurrent.Execute(); 
        }
    }
}

