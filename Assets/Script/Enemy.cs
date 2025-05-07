using UnityEngine;

public class Enemy
{
    private string nome = "EnemyDefault";
    private int vita = 100;
    private int livello = 1;
    private int attaccoBase = 5;

    public Enemy Inizializza(string nome, int vita, int livello)
    {
        //Setto nome
        this.nome = nome;

        //Setto vita
        if (vita > 0)
        {
            this.vita = vita;
        }

        //Setto livello
        this.livello = Mathf.Max(1, livello);

        //Setto attaccoBase
        attaccoBase = Random.Range(5, 10);
        
        Debug.Log(@$"Enemy:
                  - Nome {this.nome}
                  - Vita {this.vita}
                  - Livello {this.livello}
                  - Attacco Base {this.attaccoBase}");
        return this;
    }

    public string GetNome() => nome;

    public int GetVita() => vita;

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
