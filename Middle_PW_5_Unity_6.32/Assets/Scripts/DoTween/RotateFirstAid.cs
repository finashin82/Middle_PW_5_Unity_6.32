using UnityEngine;
using DG.Tweening;

public class RotateFirstAid : MonoBehaviour
{
    private Tweener rotationTween;

    [SerializeField] private float _timeRotate = 6f;

    void Start()
    {
        rotationTween = transform

            // Вращение на 360 за определенное время
            .DORotate(Vector3.up * 360, _timeRotate)

            // Бесконечное вращение
            .SetLoops(-1)

            // Вокруг своей оси
            .SetRelative(true)

            // Без ускорений (линейное вращение)
            .SetEase(Ease.Linear);
    }

    /// <summary>
    /// Убиваем твин при уничтожении предмета
    /// </summary>
    void OnDestroy()
    {
        rotationTween.Kill();
    }
}
