using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
   namespace enemy
   {
        public class Zombie:MonoBehaviour
        {
            GameObject zom;
            Vector3 destino;
            Vector3 rotacion;
         

            public enum Colores
            {
                cyan,magenta,verde
            }
            Colores colores;

            public enum Comportamiento
            {
                idle,Moving,Rotating
            }
            Comportamiento comportamiento;
             
            public enum Partes
            {
                sesos,corazon,intestinos,estomago,cuello
            }
            public Partes gustos;

              public struct DatosZombie
            {
               public  Colores color;
                public Partes gustos;
                public Comportamiento estados;

            }
            

             void Start()
            {
                int aleatorio = Random.Range(0, 3);
                zom = gameObject;
                zom.name = "Zombie";
                zom.transform.position = new Vector3(Random.Range(-20, 20), 0f, Random.Range(-20, 15));
                zom.AddComponent<Rigidbody>();
                zom.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                zom.GetComponent<Rigidbody>().useGravity = false;
                 colores = (Colores)Random.Range(0, 3);
                if (colores== Colores.cyan)
                {

                    zom.GetComponent<Renderer>().material.color = Color.cyan;

                }
                if (colores==Colores.magenta)
                {
                    zom.GetComponent<Renderer>().material.color = Color.magenta;
                }

                if (colores == Colores.verde)
                {
                    zom.GetComponent<Renderer>().material.color = Color.green;
                }
               
                    StartCoroutine(EstadosZombie());
                
               
                
                
            }

             void Update()
            {
                if (comportamiento == Comportamiento.idle)
                {
                    Debug.Log("Estoy quieto");
                }

                if (comportamiento == Comportamiento.Moving)
                {
                    transform.Translate(destino * Time.deltaTime*0.3f);
                }
                if (comportamiento == Comportamiento.Rotating)
                {
                    transform.Rotate(rotacion);
                }
                
            }

            public DatosZombie ObtenerZombieInfo()
            {
                gustos = (Partes)Random.Range(0, 4); 
                DatosZombie datos = new DatosZombie();
                if (gustos == Partes.sesos)
                {
                    datos.gustos = Partes.sesos;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tus" + datos.gustos);
                }
                if (gustos == Partes.corazon)
                {
                    datos.gustos = Partes.corazon;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tu" + datos.gustos);
                }
                if (gustos == Partes.intestinos)
                {
                    datos.gustos = Partes.intestinos;
                    Debug.Log("warrrrr soy un Zombie y quiero comerme tus " + datos.gustos);
                }

                if (gustos == Partes.estomago)
                {
                    datos.gustos = Partes.estomago;
                    Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.gustos);

                }
                if (gustos == Partes.cuello)
                {
                    datos.gustos = Partes.cuello;
                    Debug.Log("warrrrr soy un Zombie y quiero comerte tu" + datos.gustos);
                }
                return datos;

               
            }

             public IEnumerator EstadosZombie()
            {
               
                comportamiento = (Comportamiento)Random.Range(0, 3);

                if (comportamiento == Comportamiento.idle)
                {
                    
                }

                if (comportamiento == Comportamiento.Moving)
                {
                    destino = new Vector3(Random.Range(-22, 20), 0f, Random.Range(-20, 20));
                    yield return null;
                }

                if (comportamiento == Comportamiento.Rotating)
                {
                    rotacion = new Vector3(0f, 1f, 0f);
                    yield return null;
                }

                yield return new WaitForSeconds(3f);
                yield return EstadosZombie();
            }


        }
    }

    namespace Ally
    {
        public class Ciudadano:MonoBehaviour
        {
            GameObject ciud;
            public enum Nombres
            {
                Trinity, Morfeo, Neo, Hank, Nabucodonosor, Smith, Xiu, Marduk, Leviatan, Belzebu, Astarot, Behemont, Legion, Nerdal, Hawck,
                Edard, Robert, Aria, Jhon, Jamie, Rob, Catalyn
            }
          

            public struct DatosCiudadano
            {
                public int edad;
                public string nombre;

            }
           // DatosCiudadano date;

            void  Start()
            {
                ciud = gameObject;
                ciud.GetComponent<Renderer>().material.color = Color.yellow;
                ciud.name = "Ciudadano";
                ciud.transform.position = new Vector3(Random.Range(-25, 20), 0f, Random.Range(-20, 25));
                ciud.AddComponent<Rigidbody>();
                ciud.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ciud.GetComponent<Rigidbody>().useGravity = false;
               
                
            }

            public DatosCiudadano Datos()
            {
                DatosCiudadano date = new DatosCiudadano();
                date.nombre = ((Nombres)Random.Range(0, 21)).ToString();
                date.edad = Random.Range(15, 101);

                return date;
            }

        }
    }


}
