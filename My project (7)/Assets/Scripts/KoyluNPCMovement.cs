using UnityEngine;
using UnityEngine.AI; // NavMeshAgent için bu namespace'i dahil edin

public class KoyluNPCMovement : MonoBehaviour
{
    public NavMeshAgent agent; // Inspector'dan atanacak NavMeshAgent bileþeni
    public Transform[] patrolPoints; // Karakol noktalarý (kale içinde belirleyeceðiniz objeler)
    private int currentPatrolIndex; // Mevcut karakol noktasýnýn indeksi

    public float npcSpeed = 3.5f; // <<<<<<<<< BURAYA EKLENDÝ! NPC HIZINI BURADAN AYARLAYABÝLÝRSÝNÝZ

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Kendi üzerindeki NavMeshAgent'ý alýr
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent bileþeni bulunamadý! Lütfen GuardAI script'inin olduðu objeye NavMeshAgent ekleyin.");
            enabled = false; // Script'i devre dýþý býrak
            return;
        }

        // <<<<<<<<< BURAYA EKLENDÝ! NavMeshAgent'ýn hýzýný ayarla
        agent.speed = npcSpeed;

        // Patrol noktalarý atanmýþ mý kontrol et
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("Karakol noktasý atanmamýþ! Lütfen patrolPoints dizisine nokta ekleyin.");
            enabled = false; // Script'i devre dýþý býrak
            return;
        }

        // Ýlk patrol noktasýna git
        GoToNextPatrolPoint();
    }

    void Update()
    {
        // Eðer ajanýn hedef noktasýna yakýnsa (kaldýðý mesafe küçükse) yeni bir noktaya git
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {
        // Bir sonraki karakol noktasýna geç
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
}