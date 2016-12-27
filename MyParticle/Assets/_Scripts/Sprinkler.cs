using UnityEngine;
using System.Collections;

public class Sprinkler : MonoBehaviour {
    private float heightAboveFloor;
    private ParticleSystem[] sprinklers;
    void Awake()
    {
        sprinklers = GetComponentsInChildren<ParticleSystem>();
    }
	// Use this for initialization
	void Start () {
        heightAboveFloor = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);
            foreach (RaycastHit h in hits)
            {
                if (h.collider.name == "ground")
                    transform.position = h.point + new Vector3(0f, heightAboveFloor, 0f);
            }
            if(!sprinklers[0].isPlaying)
            {
                for(int i=0;i<sprinklers.Length;i++)
                {
                    sprinklers[i].Play();
                }

            }
        }
        else
        {
            if(sprinklers[0].isPlaying)
            {
                for(int i=0;i<sprinklers.Length;i++)
                {
                    sprinklers[i].Stop();
                }
            }
        }
	}
}
