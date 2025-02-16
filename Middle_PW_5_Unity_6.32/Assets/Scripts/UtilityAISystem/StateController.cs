using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // ������ � �����������
    [SerializeField] private List<State> _state;

    private State stateCurrent = null;
   
    void Update()
    {        
        float maxRadius = 0;

        //State stateCurrent = null;

        foreach (var state in _state) 
        {
            var radius = state.Evaluate();

            if (maxRadius < radius)
            {
                // ��� ����� ��������� �����, �������, ��������� ��� � ������� ��������� (�������� ��������)
                if (stateCurrent != null) stateCurrent.Exit();

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

