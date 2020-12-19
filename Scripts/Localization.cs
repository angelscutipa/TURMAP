using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public GameObject Panel;
    public GameObject canv;
    public GameObject[] lugares;

    public GameObject[] videos;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.gameObject.name == "Puente")
                    {
                        canv.SetActive(true);
                        lugares[0].SetActive(true);
                    }
                    else if (hit.transform.gameObject.name == "Momia")
                    {
                        canv.SetActive(true);
                        lugares[1].SetActive(true);
                    }
                    else if (hit.transform.gameObject.name == "Paraqra")
                    {
                        canv.SetActive(true);
                        lugares[2].SetActive(true);
                    }
                    else if (hit.transform.gameObject.name == "Chullpas")
                    {
                        canv.SetActive(true);
                        lugares[3].SetActive(true);
                    }
                    else if (hit.transform.gameObject.name == "Pumpu")
                    {
                        canv.SetActive(true);
                        lugares[4].SetActive(true);
                    }
                    else if (hit.transform.gameObject.name == "Ccocha")
                    {
                        canv.SetActive(true);
                        lugares[5].SetActive(true);
                    }
                }
            }
        }
        /*        if (Input.GetMouseButtonDown(0)) {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out hit, 10000.0f)) {
                        if (hit.transform != null)
                        {
                            if (hit.transform.gameObject.name == "Puente")
                            {
                                canv.SetActive(true);
                                lugares[0].SetActive(true);
                            }
                            else if (hit.transform.gameObject.name=="Momia") {
                                canv.SetActive(true);
                                lugares[1].SetActive(true);
                            }
                            else if (hit.transform.gameObject.name == "Paraqra")
                            {
                                canv.SetActive(true);
                                lugares[2].SetActive(true);
                            }
                            else if (hit.transform.gameObject.name == "Chullpas")
                            {
                                canv.SetActive(true);
                                lugares[3].SetActive(true);
                            }
                            else if (hit.transform.gameObject.name == "Pumpu")
                            {
                                canv.SetActive(true);
                                lugares[4].SetActive(true);
                            }
                            else if (hit.transform.gameObject.name == "Ccocha")
                            {
                                canv.SetActive(true);
                                lugares[5].SetActive(true);
                            }
                        }
                    }
                }*/
    }

    public void play_video() {
        if (lugares[3].active) {
            lugares[3].SetActive(false);
            videos[0].SetActive(true);
        }
        else if (lugares[4].active) {
            lugares[4].SetActive(false);
            videos[1].SetActive(true);
        }
    }

    public void volver_Mapa() {
        for (int i = 0; i < videos.Length; i++) {
            videos[i].SetActive(false);
            canv.SetActive(false);
        }
        for (int i = 0; i < lugares.Length; i++)
        {
            lugares[i].SetActive(false);
        }
    }

}
