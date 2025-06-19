using UnityEngine;
using Zenject;

public class ClickFirstAid : MonoBehaviour
{
    public class Factory : PlaceholderFactory<ClickFirstAid>
    {
    }

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    [SerializeField] private int _amountHealth = 10;

    public void SignalHealth()
    {
        if (_signalBus != null)
        {
            _signalBus.Fire(new SignalPlayerHealth
            {
                AmountHealth = _amountHealth,
            });

            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Сигнал не отправлен");
        }
    }
}
