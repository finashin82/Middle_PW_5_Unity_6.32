using UnityEngine;

public class ForceFromImpact : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Animator>(out var anim))
        {
            // �������� ������ � ����������
            Animator enemyAnim = other.gameObject.GetComponent<Animator>();

            enemyAnim.SetBool("isHit", true);
        }
    }
}
