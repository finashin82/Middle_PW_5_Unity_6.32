using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private Renderer _meshRenderer;

    //[SerializeField] private Material _material;

    //[SerializeField] private GameObject _material;

    private float speed = 0.3f;

    private const string AmountKey = "_DissolveAmount";

    private float counter = 0;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        counter += speed * Time.deltaTime;
        _meshRenderer.material.SetFloat(AmountKey, counter);
    }
}
