using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public void crear_usuario(string usuario, string correo, string contra, Action<Response> response) {
        StartCoroutine(CO_CreateUser(usuario, correo, contra, response));
    }

    private IEnumerator CO_CreateUser(string usuario, string correo, string contra, Action<Response> response) {
        WWWForm form = new WWWForm();

        form.AddField("nombre", usuario);
        form.AddField("correo", correo);
        form.AddField("contra", contra);

        WWW w = new WWW("http://localhost/maptur/createUser.php", form);

        yield return w;
        response(JsonUtility.FromJson<Response>(w.text));
    }

}

[Serializable]
public class Response {
    public bool done = false;
    public string mensaje="";
}