using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Enemy
{
    public bool debug;

    private string nome;
    private int vita;
    private int vitaDefault = 100;
    private int livello;
    private int attaccoBase;

    public Enemy Inizializza(string nome, int vita, int livello)
    {
        if (debug)
            Debug.Log("Inizio Enemy - Inizializza");

        //Setto nome
        this.nome = nome;
        if (debug)
            Debug.Log($"Nome nemico assegnato - {nome}");

        //Setto vita
        if (vita < 0)
        {
            this.vita = Mathf.Abs(vita);
            Debug.LogWarning("La vita non può essere negativa, verrà tolto il segno meno");
        }
        else if (vita == 0)
        {
            this.vita = vitaDefault;
            Debug.LogWarning($"Vita di {nome} settato di default {this.vita}");
        }
        else
        {
            this.vita = vita;
        }
        if (debug)
            Debug.Log($"Vita del nemico {nome} è di {this.vita}");

        //Setto livello
        if (livello < 0)
        {
            this.livello = Mathf.Abs(livello);
            Debug.LogWarning("Il livello non può essere negativo, verrà tolto il segno meno");
        }
        else if (livello == 0)
        {
            livello = 1;
            Debug.LogWarning($"Vita di {nome} settato di default {livello}");
        }
        else
        {
            this.livello = livello;
        }
        if (debug)
            Debug.Log($"Il livello del nemico {nome} è di {livello}");

        //Setto attaccoBase
        attaccoBase = Random.Range(5, 10);
        if (debug)
            Debug.Log($"L'attacco del nemico {nome} è di {attaccoBase}");

        if (debug)
            Debug.Log("Fine Enemy - Inizializza");

        return this;
    }

    public int GetVita()
    {
        return vita;
    }

    public string GetNome()
    {
        return nome;
    }

    public void SubisciDanno(int danno)
    {
        if ((vita - danno) <= 0)
        {
            vita = 0;
            Debug.Log($"<color=red>{nome}</color> è stato sconfitto!");
        }
        else
        {
            vita -= danno;
            Debug.Log($"<color=red>{nome}</color> ha subito un attacco, la sua vita è di {vita}");
        }
    }

    public int InfliggiAttaccoBase()
    {
        int attacco = Random.Range(0, attaccoBase * livello);
        Debug.Log($"<color=red>{nome}</color> ha attaccato, attacco di {attacco}");
        return attacco;
    }
}
