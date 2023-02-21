using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Playerscript : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private TMP_Text Text;
    [SerializeField] private GameObject Directions;
    [SerializeField] private GameObject Arrows;
    [SerializeField] private GameObject Counter;
    [SerializeField] private GameObject Winscreen;

    private int score = 8;

    
    void Start()
    {
        Winscreen.SetActive(false);
    }

    void Update()
    {

        //Sets starting number of eggs collected
        Text.text = "" + score;

        //Raycasting to mouse position
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Draws green line 
            Debug.DrawLine(transform.position, hit.point, Color.green);

            //On click
            if (Input.GetMouseButtonDown(0))
            {
                Cubescript cube = hit.collider.GetComponent<Cubescript>();
                if (cube != null)
                {
                    //Draws red line if cube is clicked on
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    //Destroys cube and decreases score by 1
                    Destroy(hit.collider.gameObject);
                    score--;
                }
            }
        }

        if(score == 0)
        {
            Winscreen.SetActive(true);
            Directions.SetActive(false);
            Arrows.SetActive(false);
            Counter.SetActive(false);
        }
        
    }

    //Rotates player based on a set value. Choose the dynamic float option to link it up to the slider
    public void RotateScreen(float value)
    {
        transform.eulerAngles = new Vector3(0f, value, 0f);
    }
}
