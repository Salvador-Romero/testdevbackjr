using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Persona
/// </summary>
public class Persona
{
    private int userid;
    private string Login;
    private string nombre;
    private string apellidopaterno;
    private string apellidomaterno;
    private double sueldo;
    private DateTime fechaingreso;


    public Persona()
    {

    }

    public Persona(string Login, string nombre, string apellidopaterno, string apellidomaterno, double sueldo, string correo, DateTime fechaingreso)
    {
        this.Login = Login;
        this.nombre = nombre;
        this.apellidopaterno = apellidopaterno;
        this.apellidomaterno = apellidomaterno;
        this.sueldo = sueldo;
        this.fechaingreso = fechaingreso;
    }

    public int Userid
    {
        get { return userid; }
        set { userid = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellidopaterno
    {
        get { return apellidopaterno; }
        set { apellidopaterno = value; }
    }

    public string Apellidomaterno
    {
        get { return apellidomaterno; }
        set { apellidomaterno = value; }
    }

    public string login
    {
        get { return Login; }
        set { Login = value; }
    }

    public DateTime FechaIngreso
    {
        get { return fechaingreso; }
        set { fechaingreso = value; }
    }


    public double Sueldo
    {
        get { return sueldo; }
        set { sueldo = value; }
    }

   
}