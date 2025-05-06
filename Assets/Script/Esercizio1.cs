using UnityEngine;

public class Esercizio1 : MonoBehaviour
{
    void Start()
    {
        Player player1 = new Player()
            .SetNome("Massimo")
            .SetPunteggio(5);
        Player player2 = new Player()
            .SetNome("Alberto")
            .SetPunteggio(8);

        player1.GetDati();
        player2.GetDati();
    }
}
