using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de GestionDatos
/// </summary>
public class GestionDatos
{
    public SqlConnection conexion;
    public SqlTransaction transaccion;
    public string error;
    SqlConnection conexio1 = new SqlConnection("Data Source=DE-BSTQMC2; Initial Catalog=Prueba;User ID=;Password=;Application Name=QM2");

    public bool agregarPersona(Persona usuario)
    {

        conexio1.Open();
        bool agrega = false;
        SqlCommand comando = new SqlCommand();

        comando.Connection = conexio1;
        comando.CommandText = "Insert into [Prueba].[dbo].[usuarios] (Login,Nombre,Paterno,Materno) Values(@Login,@Nombre,@Paterno,@Materno)";
        comando.Parameters.AddWithValue("@Login", usuario.login);
        comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
        comando.Parameters.AddWithValue("@Paterno", usuario.Apellidopaterno);
        comando.Parameters.AddWithValue("@Materno", usuario.Apellidomaterno);
        try
        {
            comando.ExecuteNonQuery();
            agrega = true;
            conexio1.Close();
            agrega = Agregarempleado(usuario, obtenerid());
        }
        catch (SqlException ex)
        {
            this.error = ex.Message;
        }
        return agrega;
    }

    public int obtenerid()
    {
        conexio1.Open();

        SqlCommand comando = new SqlCommand();

        comando.Connection = conexio1;
        comando.CommandText = "SELECT Top(1) * FROM [dbo].[usuarios] order by userid desc";
        SqlDataReader valor = comando.ExecuteReader();

        int id = 0;
        if (valor.Read())
            id = Int32.Parse("0" + valor[0]);
        conexio1.Close();
        return id;
    }

    public int obtenerid(Persona usuario)
    {
        conexio1.Open();

        SqlCommand comando = new SqlCommand();
        string consulta = "SELECT Top(1) * FROM [dbo].[usuarios] where ";

        if (!string.IsNullOrEmpty(usuario.Nombre))
            consulta = consulta + " Nombre like " + "'%" + usuario.Nombre + "%'";
        if (!string.IsNullOrEmpty(usuario.Apellidopaterno))
        {
            consulta = (!string.IsNullOrEmpty(usuario.Nombre)) ? consulta + " AND Paterno like " + "'%" + usuario.Apellidopaterno + "%'" : consulta + " Paterno like " + "'%" + usuario.Apellidopaterno + "%'";

        }
        if (!string.IsNullOrEmpty(usuario.Apellidomaterno))
            consulta = (!string.IsNullOrEmpty(usuario.Nombre) || !string.IsNullOrEmpty(usuario.Apellidopaterno)) ? consulta + " AND Materno like " + "'%" + usuario.Apellidomaterno + "%'" : consulta + " Materno like " + "'%" + usuario.Apellidomaterno + "%'";
        if (!string.IsNullOrEmpty(usuario.login))
            consulta = (!string.IsNullOrEmpty(usuario.Nombre) || !string.IsNullOrEmpty(usuario.Apellidopaterno) || !string.IsNullOrEmpty(usuario.Apellidomaterno)) ? consulta + " AND Login like " + "'%" + usuario.login + "%'" : consulta + " Login like " + "'%" + usuario.login + "%'";

        consulta = consulta + " order by userid desc";
        comando.Connection = conexio1;
        comando.CommandText = consulta;
        SqlDataReader valor = comando.ExecuteReader();

        int id = 0;
        if (valor.Read())
            id = Int32.Parse("0" + valor[0]);
        conexio1.Close();
        return id;
    }

    public bool Agregarempleado(Persona usuario, int userid)
    {
        conexio1.Open();
        bool agrega = false;
        SqlCommand comando = new SqlCommand();
        string texto = "Insert into [Prueba].[dbo].[empleados](userid,Sueldo,FechaIngreso) Values( '" + userid + "','" + usuario.Sueldo + "','" + usuario.FechaIngreso.ToString("d") + "')";
        comando.Connection = conexio1;
        comando.CommandText = texto;
        try
        {
            comando.ExecuteNonQuery();
            agrega = true;
            conexio1.Close();

        }
        catch (SqlException ex)
        {
            this.error = ex.Message;
        }
        return agrega;
    }

    public bool CambiarSueldo(Persona usuario)
    {
        usuario.Userid = obtenerid(usuario);

        string consulta = "UPDATE [Prueba].[dbo].[empleados] set Sueldo = " + usuario.Sueldo + " where userid = " + usuario.Userid;

        conexio1.Open();
        bool agrega = false;
        SqlCommand comando = new SqlCommand();

        comando.Connection = conexio1;
        comando.CommandText = consulta;
        try
        {
            comando.ExecuteNonQuery();
            agrega = true;
            conexio1.Close();

        }
        catch (SqlException ex)
        {
            this.error = ex.Message;
        }
        return agrega;
    }


    public List<Persona> ListadoUsuarios(bool verificar)
    {
        List<Persona> usuarios = new List<Persona>();
        conexio1.Open();

        SqlCommand comando = new SqlCommand();
        string consulta = "select ";
        if (verificar)
            consulta = consulta + " Top(10) ";
        consulta = consulta + "US.userid, US.Login, US.Nombre, US.Paterno, US.Materno, Emp.Sueldo, Emp.FechaIngreso from [Prueba].[dbo].[usuarios] AS US INNER JOIN [Prueba].[dbo].[empleados] AS Emp ON US.userid = Emp.userid ";


        comando.Connection = conexio1;
        comando.CommandText = consulta;
        SqlDataReader valor = comando.ExecuteReader();
        while (valor.Read())
        {
            Persona usuario = new Persona();
            usuario.Userid = Int32.Parse("0" + valor[0]);
            usuario.login = valor[1].ToString();
            usuario.Nombre = valor[2].ToString();
            usuario.Apellidopaterno = valor[3].ToString();
            usuario.Apellidomaterno = valor[4].ToString();
            usuario.Sueldo = Double.Parse("0" + valor[5]);
            usuario.FechaIngreso = Convert.ToDateTime(valor[6]);
            usuarios.Add(usuario);

        }
        conexio1.Close();
        return usuarios;
    }
}