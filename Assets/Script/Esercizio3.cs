using UnityEngine;

public class Esercizio3 : MonoBehaviour
{
    void Start()
    {
        Player player4 = new Player()
            .SetNome("Mirko")
            .SetPunteggio(90);

        Debug.Log($"Il punteggio di {player4.GetNome()} � di {player4.GetPunteggio()}. � maggiore di 100? {player4.IsVincitore()}");
    }
}
