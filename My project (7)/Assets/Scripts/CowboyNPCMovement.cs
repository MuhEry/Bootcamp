using UnityEngine;
using UnityEngine.AI; // NavMeshAgent için bu namespace'i dahil edin

public class CowboyNPCMovement : MonoBehaviour
{
    public NavMeshAgent agent; // Inspector'dan atanacak NavMeshAgent bileþeni
    public Transform[] cowboyPatrolPoints; // Cowboy'a özel karakol noktalarý
    private int currentCowboyPatrolIndex; // Cowboy'un mevcut karakol noktasýnýn indeksi

    public float cowboySpeed = 4.0f; // Cowboy'un hýzý

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Kendi üzerindeki NavMeshAgent'ý alýr
        if (agent == null)
        {
            Debug.LogError("Cowboy'un üzerinde NavMeshAgent bileþeni bulunamadý! Lütfen objeye NavMeshAgent ekleyin.");
            enabled = false; // Script'i devre dýþý býrak
            return;
        }

        agent.speed = cowboySpeed; // Cowboy'un hýzýný ayarla

        // Patrol noktalarý atanmýþ mý kontrol et
        if (cowboyPatrolPoints.Length == 0)
        {
            Debug.LogWarning("Cowboy için karakol noktasý atanmamýþ! Lütfen cowboyPatrolPoints dizisine nokta ekleyin.");
            enabled = false; // Script'i devre dýþý býrak
            return;
        }

        // Ýlk patrol noktasýna git
        GoToNextCowboyPatrolPoint();
    }

    void Update()
    {
        // Eðer ajanýn hedef noktasýna yakýnsa (kaldýðý mesafe küçükse) yeni bir noktaya git
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextCowboyPatrolPoint();
        }
    }

    void GoToNextCowboyPatrolPoint()
    {
        // Bir sonraki karakol noktasýna geç
        currentCowboyPatrolIndex = (currentCowboyPatrolIndex + 1) % cowboyPatrolPoints.Length;
        agent.SetDestination(cowboyPatrolPoints[currentCowboyPatrolIndex].position);
    }
}