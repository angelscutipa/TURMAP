using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaManager : MonoBehaviour
{
    public GameObject panelDesc;
    public GameObject[] lugares;
    public GameObject[] localizaciones;

    public void Update()
    {
        for (int i=0; i<localizaciones.Length; i++) {
            localizaciones[i].transform.RotateAround(localizaciones[i].transform.position, new Vector3(0,15,0), 50*Time.deltaTime);
        }
    }
    public void volver_mapa() {
        panelDesc.SetActive(false);
        for (int i=0; i<lugares.Length; i++) {
            lugares[i].SetActive(false);
        }
    }
}
