using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 2f;

    [SerializeField] private Transform _targetRotation;

    [SerializeField] private GameObject[] _players;

    [SerializeField] private ChoicePlayerAnimation _playerAnimation;

    private float minDistance = float.MaxValue;

    private float distance;

    private int indexStartSelect = 0;

    private int direction = 1;

    void Start()
    {
        //players = GameObject.FindGameObjectsWithTag("Player");

        //for (int i = 0; i < players.Length; i++)
        //{
        //    if (Vector3.Distance(players[i].transform.position, targetRotation.position) < minDistance)
        //    {
        //        indexStartSelect = i;
        //    }
        //}
    }

    private void Update()
    {
        distance = Vector3.Distance(_players[indexStartSelect].transform.position, _targetRotation.position);

        if (distance <= minDistance)
        {
            minDistance = distance;
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(_players[indexStartSelect].transform.position, _targetRotation.position) <= minDistance)
        {
            Rotation(direction);

            _playerAnimation.ChoicePlayerOn();
        }
    }

    private void Rotation(int direction)
    {
        transform.Rotate(new Vector3(0, direction * _speedRotation * Time.deltaTime, 0));
    }

    public void RotationRigth()
    {
        if (indexStartSelect < _players.Length && indexStartSelect + 1 != _players.Length)
        {
            minDistance = float.MaxValue;

            direction = 1;

            indexStartSelect++;
        }
        else
        {
            indexStartSelect = _players.Length - 1;
        }
    }

    public void RotationLeft()
    {
        if (indexStartSelect > 0)
        {
            minDistance = float.MaxValue;

            direction = -1;

            indexStartSelect--;
        }
    }
}
