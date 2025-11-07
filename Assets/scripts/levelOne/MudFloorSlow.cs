using UnityEngine;

public class MudFloorSlow : MonoBehaviour
{
    [Header("Velocidades")]
    public float slowSpeed = 3f;    // velocidade reduzida do jogador
    public float normalSpeed = 8f;  // velocidade padrão do jogador

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se quem entrou é o jogador
        if (other.CompareTag("Player"))
        {
            Movement player = other.GetComponent<Movement>();
            if (player != null)
            {
                player.SetSpeed(slowSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Movement player = other.GetComponent<Movement>();
            if (player != null)
            {
                player.SetSpeed(normalSpeed);
            }
        }
    }
}
