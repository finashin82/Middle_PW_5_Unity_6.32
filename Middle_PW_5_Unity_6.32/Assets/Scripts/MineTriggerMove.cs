using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class MineTriggerMove : MonoBehaviour
{
    [SerializeField] private Transform mineTrigger;

    void Update()
    {
        mineTrigger.position = transform.position;
    }
}
