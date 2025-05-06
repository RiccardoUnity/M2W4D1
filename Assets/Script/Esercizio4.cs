using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Esercizio4 : MonoBehaviour
{
    Player player = new Player();
    Enemy enemy = new Enemy();

    private int turno;

    void Start()
    {
        player
            .SetNome("Goku")
            .SetPunteggio(10)
            .SetVita(200)
            .SetLivello(2)
            .SetAttaccoBase(10);

        enemy.debug = false;
        enemy.Inizializza("Saiban", 50, 1);

        Time.fixedDeltaTime = 0.5f;
    }

    void FixedUpdate()
    {
        Debug.Log("═════════════════════════════════════════════════════");
        Debug.Log($"<b>{player.GetNome()}</b> vita: {player.GetVita()}");
        Debug.Log($"<b>{enemy.GetNome()}</b> vita: {enemy.GetVita()}");
        Debug.Log("═════════════════════════════════════════════════════");

        while (player.GetVita() != 0 && enemy.GetVita() != 0)
        {
            if (player.GetVita() > 0)
                enemy.SubisciDanno(player.InfliggiAttaccoBase());
            if (enemy.GetVita() > 0)
                player.SubisciDanno(enemy.InfliggiAttaccoBase());
            Debug.Log($"<b>Turno di combattimento {turno++} terminato</b>");
            Debug.Log("═════════════════════════════════════════════════════");
        }

        Debug.Log("Duello terminato");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
