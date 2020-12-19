using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//References
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Android : MonoBehaviour
{

    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    private IDataReader reader;
    //LOGIN
    public InputField t_nombre, t_contra;

    // REGISTRAR
    public InputField t_name, t_Address, t_contra1, t_contra2;
    public Text data_staff;

    [SerializeField] public GameObject login;
    [SerializeField] public GameObject registrar;

    string DatabaseName = "TurMap.db";
    // Start is called before the first frame update
    void Start()
    {
        //Application database Path android
        string filepath = Application.persistentDataPath + "/" + DatabaseName;
        if (!File.Exists(filepath))
        {
            Debug.Log("No existe esta BD");
        }
           

        conn = "URI=file:" + filepath;

        Debug.Log("Stablishing connection to: " + conn);
        dbconn = new SqliteConnection(conn);
        dbconn.Open();

        
        //  reader_function();
    }
    //Insert
    public void insert_button()
    {
        insert_function(t_name.text, t_Address.text, t_contra1.text);

    }
    //Search 
    public void Search_button()
    {
        data_staff.text = "";
        Search_function(t_nombre.text);

    }

    //Found to Update 
    public void F_to_update_button()
    {
        data_staff.text = "";
        F_to_update_function(t_name.text);

    }
    //Update
    public void Update_button()
    {
        update_function(t_name.text, t_Address.text, t_contra1.text);

    }

    //Delete
    public void Delete_button()
    {
        data_staff.text = "";
        Delete_function(t_name.text);

    }

    //Insert To Database
    private void insert_function(string name, string Address, string contra)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into usuarios (nombre, correo, contra) values (\"{0}\",\"{1}\",\"{2}\")", name, Address, contra);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
        data_staff.text = "";
        Debug.Log("Insert Hecho  ");
        ver_login();

        //reader_function();
    }
    //Read All Data For To Database
    private void reader_function()
    {
        // int idreaders ;
        string Namereaders, Addressreaders;
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT  Name, Address " + "FROM Usuarios";// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                // idreaders = reader.GetString(1);
                Namereaders = reader.GetString(0);
                Addressreaders = reader.GetString(1);

                data_staff.text += Namereaders + " - " + Addressreaders + "\n";
                Debug.Log(" name =" + Namereaders + "Address=" + Addressreaders);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            //       dbconn = null;

        }
    }
    //Search on Database by ID
    private void Search_function(string nombre)
    {
        if (nombre == "" || t_contra.text == "") Debug.Log("Ingrese todos los datos");
        else {
            using (dbconn = new SqliteConnection(conn))
            {
                string Name_readers_Search = "", Address_readers_Search = "", contra = "";
                dbconn.Open(); //Open connection to the database.
                IDbCommand dbcmd = dbconn.CreateCommand();
                string sqlQuery = "SELECT * FROM usuarios where nombre='" + nombre + "'";// table name
                dbcmd.CommandText = sqlQuery;
                IDataReader reader = dbcmd.ExecuteReader();
                while (reader.Read())
                {
                    //  string id = reader.GetString(0);
                    Name_readers_Search = reader.GetString(0);
                    Address_readers_Search = reader.GetString(1);
                    contra = reader.GetString(2);

                }

                if (Name_readers_Search == "")
                {
                    Debug.Log("No existe este usuario");
                }
                else if (t_nombre.text == Name_readers_Search && t_contra.text == contra)
                {
                    Debug.Log("Usuario encontrado");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa");

                }
                else {
                    Debug.Log("Usuario o contraseña no cohenciden");
                }
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbconn.Close();



            }
        }

    }


    //Search on Database by ID
    private void F_to_update_function(string Search_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            string Name_readers_Search, Address_readers_Search;
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT nombre, correo, contra " + "FROM Usuarios where nombre =" + Search_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {

                Name_readers_Search = reader.GetString(0);
                Address_readers_Search = reader.GetString(1);
                t_name.text = Name_readers_Search;
                t_Address.text = Address_readers_Search;

            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();


        }

    }
    //Update on  Database 
    private void update_function(string nombre, string correo, string contra)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("UPDATE Usuarios set nombre = @name , correo = @address , contra = @contra where nombre = @nm ");

            SqliteParameter P_update_name = new SqliteParameter("@name", nombre);
            SqliteParameter P_update_address = new SqliteParameter("@address", correo);
            SqliteParameter P_update_contra = new SqliteParameter("@contra", contra);
            SqliteParameter P_update_id = new SqliteParameter("@nm", nombre);

            dbcmd.Parameters.Add(P_update_name);
            dbcmd.Parameters.Add(P_update_address);
            dbcmd.Parameters.Add(P_update_contra);
            dbcmd.Parameters.Add(P_update_id);

            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
            //Search_function(t_id.text);
        }

        // SceneManager.LoadScene("home");
    }



    //Delete
    private void Delete_function(string Delete_by_id)
    {
        using (dbconn = new SqliteConnection(conn))
        {

            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "DELETE FROM Staff where id =" + Delete_by_id;// table name
            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();


            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            data_staff.text = Delete_by_id + " Delete  Done ";

        }

    }
    public void ver_login()
    {
        login.SetActive(true);
        registrar.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}