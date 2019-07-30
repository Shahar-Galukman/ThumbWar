using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDown;
    private Vector2 fingerUp;
    private GameObject[] controls;

    public Spawner spawner;
    public bool detectSwipeOnlyAfterRelease = true;
    public float SWIPE_THRESHOLD = 20f;

    private void Start()
    {
        controls = GameObject.FindGameObjectsWithTag("UIControl");
    }

    void Update()
    {
        // TODO: Debug use to emulate swipes
        if (Input.GetMouseButtonDown(0))
        {
            fingerUp = Input.mousePosition;
            fingerDown = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fingerDown = Input.mousePosition;
            CheckSwipe();
        }
        // TODO: Remove the emulation once done

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    CheckSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        //Check if Vertical swipe
        if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (HorizontalValMove() > SWIPE_THRESHOLD && HorizontalValMove() > VerticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float VerticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float HorizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }


    void OnSwipeUp()
    {
        spawner.SpawnUnit("support");
    }

    void OnSwipeDown()
    {
        spawner.SpawnUnit("magic");
    }

    void OnSwipeLeft()
    {
        spawner.SpawnUnit("range");
    }

    void OnSwipeRight()
    {
        spawner.SpawnUnit("melee");
    }

    // Get ref to matching UI element
    private GameObject GetControl(string name)
    {
        foreach (GameObject go in controls)
        {
            if (go.name == name)
            {
                return go;
            }
        }

        return null;
    }
}