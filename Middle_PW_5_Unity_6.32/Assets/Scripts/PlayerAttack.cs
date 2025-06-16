using UnityEngine;
using Zenject;
using static Zenject.SpaceFighter.GameSettingsInstaller;

public class PlayerAttack : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    [SerializeField] private int _maxForce = 30;

    private int _currentForce;

    void Start()
    {
        _currentForce = _maxForce;
    }
    private void OnEnable()
    {
        // Подписываемся на сигнал
        _signalBus.Subscribe<SignalPlayerForce>(AddForce);
    }

    private void OnDestroy()
    {
        // Отписываемся при уничтожении объекта
        _signalBus.Unsubscribe<SignalPlayerForce>(AddForce);
    }

    /// <summary>
    /// Увеличиваем силу удара
    /// </summary>
    /// <param name="signalPlayerForce"></param>
    public void AddForce(SignalPlayerForce signalPlayerForce)
    {
        if (signalPlayerForce == null) return;

        _currentForce += signalPlayerForce.AmountForce;

        Debug.Log($"Player Force: {_currentForce}");

        Debug.Log($"+ {signalPlayerForce.AmountForce} к силе удара");
    }
}
