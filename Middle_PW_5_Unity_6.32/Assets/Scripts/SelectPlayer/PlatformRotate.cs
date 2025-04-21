using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float speedRotation = 2f;

    [SerializeField] private Transform targetRotation;

    [SerializeField] private GameObject[] players;

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
        distance = Vector3.Distance(players[indexStartSelect].transform.position, targetRotation.position);

        if (distance <= minDistance)
        {
            minDistance = distance;
        }
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(players[indexStartSelect].transform.position, targetRotation.position) <= minDistance)
        {
            Rotation(direction);
        }
    }

    private void Rotation(int direction)
    {
        transform.Rotate(new Vector3(0, direction * speedRotation * Time.deltaTime, 0));
    }

    public void RotationRigth()
    {
        if (indexStartSelect < players.Length && indexStartSelect + 1 != players.Length)
        {
            minDistance = float.MaxValue;

            direction = 1;

            indexStartSelect++;
        }
        else
        {
            indexStartSelect = players.Length - 1;
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
