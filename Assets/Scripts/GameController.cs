using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animals = new GameObject[5];
    private Animator[] animations = new Animator[5];
    private AudioSource[] audios = new AudioSource[5];

    public int QuantPlays;

    public int currentAnimal;

    [SerializeField]
    private GameObject EndScreen;

    private void Awake()
    {
        ShuffleAnimals();
        currentAnimal = 0;
        GetAllComponents();
    }


    void Start()
    {
        StartCoroutine(WaitForFirstRound());
    }

    IEnumerator WaitForFirstRound()
    {
        yield return new WaitForSeconds(1); //TEMPO PARA INICIAR O TURNO
        AppearsAnimals();

    }


    // EMBARALHA OS ANIMAIS -------- 1
    private void ShuffleAnimals()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            GameObject obj = animals[i];
            int randomizeArray = Random.Range(0, i);
            animals[i] = animals[randomizeArray];
            animals[randomizeArray] = obj;
        }

    }

    //PROCURA E PEGA TODOS OS COMPONENTES DOS ANIMAIS ----------- 2
    private void GetAllComponents()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animations[i] = animals[i].gameObject.GetComponent<Animator>();
            audios[i] = animals[i].gameObject.GetComponent<AudioSource>();
            animals[i].GetComponent<MyData>().MyId = i;
        }

    }




    public void DesappearsAnimals()
    {

        //NOVO LOOP
        for (int i = 0; i < animals.Length; i++)
        {
            animations[i].SetTrigger("disappears");

            animals[i].GetComponent<DisabledOrEnabledButton>().DisableButton();

            if (i == 4)
                break;
        }
        /*
        for (int i = currentAnimal; i < (currentAnimal + 3); i++)
        {
            animations[i].SetTrigger("disappears");

            animals[i].GetComponent<DisabledOrEnabledButton>().DisableButton();

            if (i == 4)
                break;
        }*/


        if (currentAnimal < 4)
        {
            currentAnimal++;
            StartCoroutine(StartNewRound());
        }
        else
        {
            EndScreen.SetActive(true); //GANHOU
            Debug.Log(QuantPlays);
        }

    }


    IEnumerator StartNewRound()
    {
        yield return new WaitForSeconds(3); //TEMPO PARA INICIAR NOVO TURNO
        AppearsAnimals();

    }

    //APARECE OS 3 PRIMEIROS ANIMAIS A PARTIR DO ANIMAL ATUAL
    public void AppearsAnimals()
    {
        audios[currentAnimal].Play();

        //NOVO LOOP
        for (int i = 0; i < animals.Length; i++)
        {
            Debug.Log(animals[i].name);

            animations[i].SetTrigger("appears");

            animals[i].GetComponent<DisabledOrEnabledButton>().EnableButton();

        }

        /*
        for (int i = currentAnimal; i < (currentAnimal + 3); i++)
        {
            Debug.Log(animals[i].name);

            animations[i].SetTrigger("appears");

            animals[i].GetComponent<DisabledOrEnabledButton>().EnableButton();

            if (i == 4)
                break;
        }*/
    }


    public void RepeatAudio()
    {
        audios[currentAnimal].Play();
    }

}
