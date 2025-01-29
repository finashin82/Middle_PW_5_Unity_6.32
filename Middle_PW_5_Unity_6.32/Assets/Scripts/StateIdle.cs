using UnityEngine;

public class StateIdle : State
{
    [SerializeField] private AnimationCurve _curve;

    [SerializeField] private GameObject _player;

    [SerializeField] private float _radius;

    public override void Execute()
    {
        Debug.Log("־עהûץ");
    }

    public override float Evaluate()
    {
        var distFloat = Vector3.Distance(transform.position, _player.transform.position);

        var clamp = Mathf.Clamp(distFloat, 0, _radius);

        var dist = _curve.Evaluate((_radius - clamp) / _radius);

        return Mathf.Clamp01(dist);
    }
}
