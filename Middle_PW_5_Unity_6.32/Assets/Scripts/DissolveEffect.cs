using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private Renderer _meshRenderer;

    [SerializeField] private float speedDissolve = 0.3f;

    private const string DissolveAmount = "_DissolveAmount";

    private float counter = 0;

    private bool isDissolve = false;

    void FixedUpdate()
    {
        if (isDissolve)
        {
            if (counter > 1) counter = 1;

            counter += speedDissolve * Time.deltaTime;
            _meshRenderer.material.SetFloat(DissolveAmount, counter);
        }
        else
        {
            if (counter < 0) counter = 0;

            counter -= speedDissolve * Time.deltaTime;
            _meshRenderer.material.SetFloat(DissolveAmount, counter);
        }
    }

    public void OnOffDissolve()
    {
        isDissolve = !isDissolve;
    }
}
