using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterData : MonoBehaviour
{
    //private SignalBus _signalBus;

    //[Inject]
    //public void Construct(SignalBus signalBus)
    //{
    //    _signalBus = signalBus;
    //}

    public List<GameObject> Targets { get; set; } = new List<GameObject>();

    public GameObject InventoryUIRoot;

    [SerializeField] private List<MonoBehaviour> _levelUpActions;

    [SerializeField] private int _currentLevel = 1;
    [SerializeField] private int _score = 0;
    [SerializeField] private int _scoreToNextLevel = 20;

    [SerializeField] private int scoreAmount = 10;

    private PlayerHealth playerHealth;

    private List<IItem> items;

    private void Start()
    {
        // Подписываемся на сигнал
        //_signalBus.Subscribe<ScoreSignal>(Score);

        playerHealth = GetComponent<PlayerHealth>();
    }

    //private void OnDestroy()
    //{
    //    // Отписываемся при уничтожении объекта
    //    _signalBus.Unsubscribe<ScoreSignal>(Score);
    //}

    public void Score(int score)
    {
        _score += score;

        if (_score >= _scoreToNextLevel) 
        {
            LevelUp();
        }
    }

    private void LevelUp() 
    {
        _currentLevel++;

        _scoreToNextLevel *= 2;

        foreach (var action in _levelUpActions) 
        {
            if (!(action is ILevelUp levelUp)) return;

            levelUp.LevelUp(this, _currentLevel);
        }
    }
}
