﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animals = new GameObject[5];
    private Animator[] animations = new Animator[5];
    private AudioSource[] audios = new AudioSource[5];
    private int currentAnimal;
    

    private void Awake()
    {
        ShuffleAnimals();
        currentAnimal = 0;
    }


    void Start()
    {
        GetAllComponents();
        AppearsAnimals();

        //audioteste.Play();

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

        /* //PRINT ARRAY
        for (int i = 0; i < animals.Length; i++)
        {
            Debug.Log(animals[i].name);
        }*/
    }

    //PROCURA E PEGA TODOS OS COMPONENTES DOS ANIMAIS ----------- 2
    private void GetAllComponents()
    {
        for (int i = 0; i < animals.Length; i++)
        {
            animations[i] = animals[i].gameObject.GetComponent<Animator>();
            audios[i] = animals[i].gameObject.GetComponent<AudioSource>();
        }

    }


    //APARECE OS 3 PRIMEIROS ANIMAIS A PARTIR DO ANIMAL ATUAL
    private void AppearsAnimals()
    {
        audios[currentAnimal].Play();

        for (int i = currentAnimal; i < (currentAnimal + 3); i++)
        {
            Debug.Log(animals[i].name);

            animations[i].SetTrigger("appears");

            animals[i].GetComponent<DisabledOrEnabledButton>().EnableButton();

            if (i == 4)
                break;
        }
    }

  

}
