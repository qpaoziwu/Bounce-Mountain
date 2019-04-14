using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string animalSoundEvent;
    FMOD.Studio.EventInstance animalState;

    [FMODUnity.EventRef]
    public string impactSoundEvent;
    FMOD.Studio.EventInstance impactState;

    [FMODUnity.EventRef]
    public string motionEvent;
    FMOD.Studio.EventInstance motionState;


    int animalType = 0;

    float impactVolume;
    int surfaceMaterial;

    public float motionVolume;

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "Player")
        {
            motionState = FMODUnity.RuntimeManager.CreateInstance(motionEvent);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(motionState, transform, rb2D);
            motionState.start();

            animalState = FMODUnity.RuntimeManager.CreateInstance(animalSoundEvent);
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(animalState, transform, rb2D);
            animalState.setParameterValue("Animal", animalType);
        }

        impactState = FMODUnity.RuntimeManager.CreateInstance(impactSoundEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(impactState, transform, rb2D);
    }

    // Update is called once per frame
    void Update()
    {
        impactVolume = Mathf.Clamp(Mathf.Abs(rb2D.velocity.magnitude) / 5, 0f,1f);
        impactState.setParameterValue("Volume", impactVolume);

        if(gameObject.tag == "Player")
        {
            motionVolume = Mathf.Clamp(Mathf.Abs(rb2D.velocity.magnitude) / 10, 0f, 1f);
            motionState.setParameterValue("Speed", motionVolume);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Wood" || other.gameObject.tag == "Metal")
        {
            if (gameObject.tag == "Head")
            {
                animalState.start();
            }


            if (other.gameObject.tag == "Ground")
            {
                impactState.setParameterValue("Surface", 0);
                impactState.start();
            } else if (other.gameObject.tag == "Wood")
            {
                impactState.setParameterValue("Surface", 1);
                impactState.start();
            }
        }
    }
}
