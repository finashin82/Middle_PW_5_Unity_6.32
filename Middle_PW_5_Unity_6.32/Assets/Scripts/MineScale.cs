using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class MineScale : MonoBehaviour
{
    [SerializeField] private Transform mine;

    [SerializeField] private Vector3 endScalePosition;

    [SerializeField] private float speedScale = 1;

    private Vector3 startScalePosition;

    private void Start()
    {
        startScalePosition = mine.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        mine.transform.DOScale(endScalePosition, speedScale);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        mine.transform.DOScale(startScalePosition, speedScale);
    }
}
