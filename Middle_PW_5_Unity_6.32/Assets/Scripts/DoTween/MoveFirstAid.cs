using UnityEngine;
using DG.Tweening;

public class MoveFirstAid : MonoBehaviour
{
    private Tweener moveTween;

    [SerializeField] private Transform _topTarget;

    [SerializeField] private Transform _downTarget;

    [SerializeField] private float _timeMove = 3f;

    private void Awake()
    {
        transform.position = _downTarget.position;
    }

    void Start()
    {
        moveTween = transform
        // Запускаем зацикленное движение вперед-назад
            .DOMove(_topTarget.position, _timeMove)

            // Плавное ускорение и замедление
            .SetEase(Ease.InOutSine)

            // Бесконечный цикл "туда-обратно"
            .SetLoops(-1, LoopType.Yoyo);
    }

    /// <summary>
    /// Убиваем твин при уничтожении предмета
    /// </summary>
    void OnDestroy()
    {
        moveTween.Kill();
    }
}
