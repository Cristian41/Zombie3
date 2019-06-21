using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zombie = NPC.enemy;
using ciudadano = NPC.Ally;
using UnityEngine.UI;

public class Ciudad : MonoBehaviour
{
    GameObject cube;
    GameObject hero;
    int contadorZombie;
    int contadorCiudadanos;
    public Text num_Z;
    public Text num_C;
    public readonly int minimo_Cubos = Datos.mini_Cubos;
    const int maximoCubos = Datos.maxi_Cubos;

    
    // Start is called before the first frame update
    void Start()
    {
       
        hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hero.AddComponent<Heroe>();
        
        for(int i = minimo_Cubos* Random.Range(5, 15);  i < maximoCubos; i++)
        {
            int aleatorio = Random.Range(0, 2);
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            if (aleatorio == 0)
            {
                cube.AddComponent<zombie.Zombie>();
            }
            if (aleatorio == 1)
            {
                cube.AddComponent<ciudadano.Ciudadano>();
            }
           
        }
        StartCoroutine(CountNPC());
      
    }

    void Update()
    {
        
    }

    public void Stop()
    {
        StopCoroutine(CountNPC());
    }

    IEnumerator CountNPC()
    {
      
        zombie.Zombie[] zombies = FindObjectsOfType<zombie.Zombie>();
        foreach (zombie.Zombie z in zombies)
        {
           contadorZombie++;
        }
        num_Z.text = "# de Zombies :" + contadorZombie.ToString();
        ciudadano.Ciudadano[] citizen = FindObjectsOfType<ciudadano.Ciudadano>();
        foreach(ciudadano.Ciudadano c in citizen)
        {
            contadorCiudadanos++;
        }
        num_C.text = "# de Ciudadanos : " + contadorCiudadanos.ToString();
        yield return new WaitForSeconds(0.3f);
        
    }
}
