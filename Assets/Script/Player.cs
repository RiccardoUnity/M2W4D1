using UnityEngine;

//Classe con stile fluent
public class Player
{
    private string nome = "NomeVuoto";
    private int punteggio;

    private int vita;
    private int vitaDefult = 100;
    private int livello;
    private int attaccoBase;

    public string GetNome()
    {
        return nome;
    }

    public Player SetNome(string nome)
    {
        this.nome = nome;
        return this;
    }

    public int GetPunteggio()
    {
        return punteggio;
    }

    public Player SetPunteggio(int punteggio)
    {
        if (punteggio < 0)
        {
            this.punteggio = 0;
        }
        else
        {
            this.punteggio = punteggio;
        }
        return this;
    }

    public void IncrementaPunteggio(int delta)
    {
        Mathf.Abs(delta);
        punteggio += delta;
    }

    public void IncrementaPunteggio(int delta, bool flag)
    {
        if (flag)
            Debug.Log($"Punteggio di {nome} prima dell'incremento: {punteggio}");
        Mathf.Abs(delta);
        punteggio += delta;
        if (flag)
            Debug.Log($"Punteggio di {nome} dopo dell'incremento: {punteggio}");
    }

    public bool IsVincitore()
    {
        return punteggio >= 100;
    }

    public void GetDati()
    {
        Debug.Log($"Il Player {nome} ha un punteggio di {punteggio}");
    }

    public int GetVita()
    {
        return vita;
    }

    public Player SetVita(int valore)
    {
        if (valore < 0)
        {
            vita = Mathf.Abs(valore);
        }
        else if (valore == 0)
        {
            vita = vitaDefult;
            Debug.LogWarning($"Vita di {nome} settato di default {vita}");
        }
        else
        {
            vita = valore;
        }
        return this;
    }

    public int GetLivello()
    {
        return livello;
    }

    public Player SetLivello(int valore)
    {
        if (valore < 0)
        {
            livello = Mathf.Abs(valore);
        }
        else if (valore == 0)
        {
            livello = 1;
            Debug.LogWarning($"Livello di {nome} settato di default {livello}");
        }
        else
        {
            livello = valore;
        }
        return this;
    }

    public int GetAttaccoBase()
    {
        return attaccoBase;
    }

    public Player SetAttaccoBase(int attacco)
    {
        if (attacco < 0)
        {
            attaccoBase = Mathf.Abs(attacco);
        }
        else if (attacco == 0)
        {
            attaccoBase = 10;
            Debug.LogWarning($"Attacco di {nome} settato di default {attacco}");
        }
        else
        {
            attaccoBase = attacco;
        }
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
