using UnityEngine;
using Zenject;

public class Player
{
    private readonly SignalBus _signalBus;

    public Player(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Attack()
    {
        // Логика атаки
        Debug.Log("Player attacks!");

        // Отправляем сигнал
        _signalBus.Fire<PlayerAttackSignal>();
    }
}