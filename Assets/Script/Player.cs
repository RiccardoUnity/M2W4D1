using UnityEngine;

//Classe con stile fluent
public class Player
{
    private string nome = "PlayerDefault";
    private int punteggio;

    private int vita = 100;
    private int livello = 1;
    private int attaccoBase = 5;

    public string GetNome() => nome;

    public Player SetNome(string nome)
    {
        this.nome = nome;
        return this;
    }

    public int GetPunteggio() => punteggio;

    public Player SetPunteggio(int punteggio)
    {
        this.punteggio = Mathf.Max(0, punteggio);
        return this;
    }

    public void IncrementaPunteggio(int delta) => punteggio += Mathf.Abs(delta);

    public void IncrementaPunteggio(int delta, bool debug)
    {
        if (debug)
            Debug.Log($"Punteggio di {nome} prima dell'incremento: {punteggio}");
        IncrementaPunteggio(delta);
        if (debug)
            Debug.Log($"Punteggio di {nome} dopo dell'incremento: {punteggio}");
    }

    public bool IsVincitore() => punteggio >= 100;

    public void GetDati() => Debug.Log($"Il Player {nome} ha un punteggio di {punteggio}");

    public int GetVita() => vita;

    public Player SetVita(int vita)
    {
        if (vita > 0)
        {
            this.vita = vita;
        }
        return this;
    }

    public int GetLivello() => livello;

    public Player SetLivello(int livello)
    {
        this.livello = Mathf.Max(1, livello);
        return this;
    }

    public int GetAttaccoBase() => attaccoBase;

    public Player SetAttaccoBase(int attacco)
    {
        this.attaccoBase = Mathf.Max(10, attacco);
        return this;
    }

    public void SubisciDanno(int danno)
    {
        int difesa = Random.Range(0, livello * 2);
        Debug.Log($"La difesa di <color=cyan>{nome}</color> ha ridotto il danno di {difesa}");
        if (danno < difesa)
        {
            DecrementoVita(0);
        }
        else
        {
            DecrementoVita(danno - difesa);
        }
    }

    public void DecrementoVita(int danno)
    {
        if ((vita - danno) <= 0)
        {
            vita = 0;
            Debug.Log("!!! Sei stato sconfitto!!!");
        }
        else
        {
            vita -= danno;
            Debug.Log($"Il danno ha ridotto la vita di <color=cyan>{nome}</color> a {vita}");
        }
    }

    public int InfliggiAttaccoBase()
    {
        int attacco = Random.Range(0, attaccoBase * livello);
        Debug.Log($"<color=cyan>{nome}</color> ha attaccato, attacco di {attacco}");
        return attacco;
    }
}
