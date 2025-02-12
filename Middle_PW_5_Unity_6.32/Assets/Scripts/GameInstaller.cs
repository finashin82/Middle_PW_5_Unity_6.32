using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private int _maxHealthPlayer;

    public override void InstallBindings()
    {
        Container.BindInstance(new MaxHealthPlayer(_maxHealthPlayer)).AsSingle().NonLazy();
    }
}

public class MaxHealthPlayer
{
    public int Health;

    public MaxHealthPlayer(int health)
    {
        Health = health;
    }
}