using System.Security.Cryptography;
using UnityEngine;

public class StateChase : State
{
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private GameObject _player;

    [SerializeField] float _radius;

    public override void Execute()
    {
        Debug.Log("Преследую");

        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();

        Vector3 newPosition = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
        transform.LookAt(newPosition);
    }

    public override float Evaluate()
    {
        var distFloat = Vector3.Distance(this.transform.position, _player.transform.position);

        var clamp = Mathf.Clamp(distFloat, 0, _radius);

        var dist = (_radius - clamp) / _radius;

        return dist;

        //var distFloat = Vector3.Distance(transform.position, _player.transform.position);

        //var clamp = Mathf.Clamp(distFloat, 0, _radius);

        //var dist = _curve.Evaluate((_radius - clamp) / _radius);

        //return Mathf.Clamp01(dist);

        //return (1 / (this.transform.position - _player.transform.position).magnitude);
    }
}
