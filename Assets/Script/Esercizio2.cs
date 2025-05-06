using UnityEngine;

public class Esercizio2 : MonoBehaviour
{
    void Start()
    {
        Player player3 = new Player()
            .SetNome("Francesco")
            .SetPunteggio(7);

        //Debug.Log("Punteggio prima dell'incremento: " + player3.GetPunteggio());
        //player3.IncrementaPunteggio(2);
        //Debug.Log("Punteggio dopo dell'incremento: " + player3.GetPunteggio());

        player3.IncrementaPunteggio(2, true);
    }
}