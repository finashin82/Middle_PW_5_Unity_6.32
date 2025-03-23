using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    private List<Material> _materialsMesh;

    private const float DissolveRate = 0.0125f;

    private const float RefreshRate = 0.025f;

    private const string AmountKey = "_DissolveAmount";

    void Start()
    {
        if (_materialsMesh is null) 
        {  
            _materialsMesh = new List<Material>(_meshRenderer.materials); 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Dissolve());
        }
    }

    private IEnumerator Dissolve()
    {
        if (_materialsMesh.Count > 0)
        {
            float counter = 0;

            while (_materialsMesh[0].GetFloat(AmountKey) < 1)
            {
                counter += DissolveRate;

                foreach (var material in _materialsMesh) 
                { 
                    material.SetFloat(AmountKey, counter);
                }

                yield return new WaitForSeconds(RefreshRate);
            }
        }
    }
}
