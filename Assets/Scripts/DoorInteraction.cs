using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : InteractableObject
{
    [SerializeField] private Transform teleportPoint;
    
    [SerializeField] private GameObject Player;

    public Animator transition;
    public GameObject transitionImage;

    public bool FinalDoor;

    
    public KeyPick Key1;
    public KeyPick Key2;
    public KeyPick Key3;
    public KeyPick Key4;

    public Animator TextAnimator;

    public GameObject WinMenu;

    public AudioSource DoorAudio;
    public override void OnInteraction()
    {
        base.OnInteraction();

        Debug.Log($"Changed Room");
       
        if (FinalDoor == false)
        {
            StartCoroutine(ChangeRoom());
        }

        if (FinalDoor)
        {
            if (Key1.PickedUpKey && Key2.PickedUpKey && Key3.PickedUpKey && Key4.PickedUpKey)
            {
                DoorAudio.Play();
                WinMenu.SetActive(true);

                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
            else
            {
                TextAnimator.Play("TextPopUp");
            }
        }

    }

    IEnumerator ChangeRoom()
    {
        transitionImage.SetActive(true);
        transition.SetBool("Transition", true);
        DoorAudio.Play();
        yield return new WaitForSeconds(0.6f);
        Player.transform.position = teleportPoint.position;
        yield return new WaitForSeconds(0.8f);
        transitionImage.SetActive(false);
    }

   
}
