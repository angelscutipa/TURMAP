using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
//LOGIN
    [SerializeField] private InputField Unombre;
    [SerializeField] private InputField Ucontra;

//REGISTRO
    [SerializeField] private InputField nombre;
    [SerializeField] private InputField correo;
    [SerializeField] private InputField contra;
    [SerializeField] private InputField contra2;


    [SerializeField] public GameObject login;
    [SerializeField] public GameObject registrar;

    private NetworkManager nm;

    private void Awake()
    {
        nm = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitLogin() {
        if (Unombre.text == "" || Ucontra.text == "")
        {
            Debug.Log("Ingrese todos los campos");
        }
        else {
            Debug.Log("Ingreso correctamente");
        }
    }
    public void SubmitRegistrar() {
        if (nombre.text=="" || correo.text=="" || contra.text=="") {
            Debug.Log("Ingrese todos los campos");
        }
        if (contra.text == contra2.text)
        {
            nm.crear_usuario(nombre.text, correo.text, contra.text, delegate(Response r) {
                Debug.Log(r.mensaje);
            });
        }
        else {
            Debug.Log("Verificar contraseñas");
        }
        
    }
    public void ver_login() {
        login.SetActive(true);
        registrar.SetActive(false);
    }

    public void ver_registrar() {
        registrar.SetActive(true);
        login.SetActive(false);
    }

}
