using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class MineMove : MonoBehaviour
{
    [SerializeField] private float moveDistance = 8f;

    [SerializeField] private float speedMove = 3f;

    void Start()
    {
        // «апускаем зацикленное движение вперед-назад
        transform.DOMoveX(transform.position.x - moveDistance, speedMove)

            // ѕлавное ускорение и замедление
            .SetEase(Ease.InOutSine)

            // Ѕесконечный цикл "туда-обратно"
            .SetLoops(-1, LoopType.Yoyo); 
    }
}
