using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOrGrow : MonoBehaviour {
 
    //Public variables
    //When triggering shrink() GameObject will scale down to [shrunkScale] over [time]
    public Vector3 shrunkScale;
    //When triggering grow() GameObject will scale up to [grownScale] over [time]
    public Vector3 grownScale;
    //Growth/shriuking time (MILLISECONDS)
    public float time;
    //Private variables
    private bool active = false;
    private Vector3 originalScale;
    //private bool shrinking;
    private float timePassed = 0.0f;
    private float progress;
    private enum State { SHRUNKEN, ORIGINAL_SIZE, GROWN }
    private State state = State.ORIGINAL_SIZE;
    private enum Actions { SHRINKING, NORMALIZING, GROWING }
    private Actions action = Actions.NORMALIZING;
 
    // Use this for initialization
    void Start ()
    {
        originalScale = transform.localScale;
    }
 
    private void FixedUpdate()
    {
        Debug.Log(active);
        if (active)
        {
            timePassed += Time.deltaTime * 1000.0f;
            //0 - 1 with time
            progress = (timePassed / time);
        }
        switch (action) {
            case Actions.NORMALIZING:
                switch (state) {
                    case State.SHRUNKEN:
                        transform.localScale = new Vector3(
                            (1 - progress) * shrunkScale.x + progress * originalScale.x,
                            (1 - progress) * shrunkScale.y + progress * originalScale.y,
                            (1 - progress) * shrunkScale.z + progress * originalScale.z
                        );
                        break;
                    case State.GROWN:
                        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * originalScale.x,
                            (1 - progress) * grownScale.y + progress * originalScale.y,
                            (1 - progress) * grownScale.z + progress * originalScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            case Actions.GROWING:
                switch (state)
                {
                    case State.SHRUNKEN:
                        transform.localScale = new Vector3(
                            (1 - progress) * shrunkScale.x + progress * grownScale.x,
                            (1 - progress) * shrunkScale.y + progress * grownScale.y,
                            (1 - progress) * shrunkScale.z + progress * grownScale.z
                        );
                        break;
                    case State.ORIGINAL_SIZE:
                        transform.localScale = new Vector3(
                            (1 - progress) * originalScale.x + progress * grownScale.x,
                            (1 - progress) * originalScale.y + progress * grownScale.y,
                            (1 - progress) * originalScale.z + progress * grownScale.z
                        );
                        break;
                    default:
                        break;
                }
                break;
            case Actions.SHRINKING:
                    Debug.Log("Entrou em shirking");

                switch (state)
                {
                    case State.ORIGINAL_SIZE:
                        transform.localScale = new Vector3(
                            (1 - progress) * originalScale.x + progress * shrunkScale.x,
                            (1 - progress) * originalScale.y + progress * shrunkScale.y,
                            (1 - progress) * originalScale.z + progress * shrunkScale.z
                        );

                                            Debug.Log("from original state");

                        break;
                    case State.GROWN:
                        transform.localScale = new Vector3(
                            (1 - progress) * grownScale.x + progress * shrunkScale.x,
                            (1 - progress) * grownScale.y + progress * shrunkScale.y,
                            (1 - progress) * grownScale.z + progress * shrunkScale.z
                        );

                                                                    Debug.Log("from grown state");

                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        if (progress >= 1)
        {
            active = false;
            switch (action) {
                case Actions.GROWING:
                    state = State.GROWN;
                    break;
                case Actions.NORMALIZING:
                    state = State.ORIGINAL_SIZE;
                    break;
                case Actions.SHRINKING:
                    state = State.SHRUNKEN;
                    break;
            }
        }
    }
 
    public void grow()
    {
        active = true;
        action = Actions.GROWING;
        timePassed = 0.0f;
    }
 
    public void shrink()
    {
        active = true;
        action = Actions.SHRINKING;
        timePassed = 0.0f;
    }
 
    public void originalSize()
    {
        active = true;
        action = Actions.NORMALIZING;
        timePassed = 0.0f;
    }
}