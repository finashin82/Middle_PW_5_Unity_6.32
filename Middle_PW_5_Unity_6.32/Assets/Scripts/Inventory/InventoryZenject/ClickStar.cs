using UnityEngine;
using Zenject;

public class ClickStar : MonoBehaviour
{
    public class Factory : PlaceholderFactory<ClickStar>
    {
    }

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    [SerializeField] private int _amountForce = 5;

    public void SignalForce()
    {
        if (_signalBus != null)
        {
            _signalBus.Fire(new SignalPlayerForce
            {
                AmountForce = _amountForce,
            });

            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Сигнал не отправлен");
        }
    }
}
