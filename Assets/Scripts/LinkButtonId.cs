using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkButtonId : MonoBehaviour
{
    [SerializeField]
    private GameObject myAnimal;

    [SerializeField]
    private int buttonId;

    [SerializeField]
    private GameObject GameController;

    [SerializeField]
    private GameObject blockInterface;

    [SerializeField]
    private GameObject pacoca;

    private Animator pacocaAnim;

    public void Start()
    {
        pacocaAnim = pacoca.GetComponent<Animator>();

        buttonId = myAnimal.GetComponent<MyData>().MyId;


    }

    public void Checkanswer()
    {
        if(buttonId == GameController.GetComponent<GameController>().currentAnimal)
        {
                GameController.GetComponent<GameController>().DesappearsAnimals();  
        }
        else
        {
            StartCoroutine(Wronganswer());
        }
    }

    IEnumerator Wronganswer()
    {
        pacocaAnim.SetTrigger("wrong");
        blockInterface.SetActive(true);
        yield return new WaitForSeconds(2.6f);
        blockInterface.SetActive(false);

    }

}
