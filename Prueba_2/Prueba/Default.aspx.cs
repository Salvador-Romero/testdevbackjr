using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Text;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    GestionDatos srv = new GestionDatos();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblsueldo.Text = "Sueldo";
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Listado.Visible = false;
        btnAgregar2.Visible = true;
        RegistroUsuario.Visible = true;
        btnAgregar.Visible = false;
        btnBack.Visible = true;
        Listado.Visible = false;
        btnCambiar.Visible = false;
        btnCambiar2.Visible = false;
        lblTexto.Text = "Registre el usuario";
    }
    protected void btnAgregar2_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "Registre un usuario";
        Persona usuario = new Persona();
        usuario.login = txtLogin.Text;
        usuario.Nombre = txtNombre.Text;
        usuario.Apellidomaterno = txtApellidoMaterno.Text;
        usuario.Apellidopaterno = txtApellidoPaterno.Text;
        usuario.Sueldo = Double.Parse("0" + txtSueldo.Text);
        usuario.FechaIngreso = DateTime.Today.Date;

        if (srv.agregarPersona(usuario))
            Console.Write("Se agregó correctamente al usuario");
        else
            Console.Write("Fallo");

    }
    protected void btnCambiar_Click(object sender, EventArgs e)
    {
        btnAgregar2.Visible = false;
        RegistroUsuario.Visible = true;
        btnAgregar.Visible = false;
        btnCambiar.Visible = false;
        btnCambiar2.Visible = true;
        Listado.Visible = false;
        btnBack.Visible = true;
        lblTexto.Text = "Ingrese el nombre, apellidos y/o Login para encontrar el usuario";

    }
    protected void btnCambiar2_Click(object sender, EventArgs e)
    {

        lblsueldo.Text = "Nuevo Sueldo";
        Persona usuario = new Persona();
        usuario.Nombre = txtNombre.Text;
        usuario.Apellidopaterno = txtApellidoPaterno.Text;
        usuario.Apellidomaterno = txtApellidoMaterno.Text;
        usuario.login = txtLogin.Text;
        usuario.Sueldo = Double.Parse("0" + txtSueldo.Text);
        if (!string.IsNullOrEmpty(usuario.login))
            if (srv.CambiarSueldo(usuario))
                Console.Write("El usuario ha sido actualizado");
            else if (!string.IsNullOrEmpty(usuario.Nombre) && !string.IsNullOrEmpty(usuario.Apellidomaterno) && !string.IsNullOrEmpty(usuario.Apellidopaterno))
                if (srv.CambiarSueldo(usuario))
                    Console.Write("El usuario ha sido actualizado");
                else
                    Console.Write("Si no conece el Login del usuario favor de ingresar el nombre completo del usuario");

    }
    protected void btnListar_Click(object sender, EventArgs e)
    {
        List<Persona> listaDePersonas = srv.ListadoUsuarios(true);
        Listado.Visible = true;
        if (listaDePersonas.Count == 0)
        {
            lblMensaje.Text = "No hay personas agregadas en la base de datos";
        }
        else
        {
            TOpPersonas.DataSource = listaDePersonas;
            TOpPersonas.DataBind();
        }
    }

    protected void btnDescargar_Click(object sender, EventArgs e)
    {
        List<Persona> listaDePersonas = srv.ListadoUsuarios(false);
        string ruta = @"C:\Temp\usuarios.csv";
        StringBuilder salida;


        foreach (Persona usuario in listaDePersonas)
        {
            salida = new StringBuilder();
            salida.AppendLine(Formato(usuario));
            File.AppendAllText(ruta, salida.ToString());


        }

    }

    public string Formato(Persona usuario)
    {
        return usuario.Userid.ToString() + "," + usuario.Nombre.ToString() + "," + usuario.Apellidopaterno.ToString() + "," + usuario.Apellidomaterno.ToString() + "," + usuario.login.ToString() + "," + usuario.Sueldo.ToString() + "," + usuario.FechaIngreso.ToString();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        btnAgregar.Visible = true;
        btnAgregar2.Visible = false;
        btnBack.Visible = false;
        btnCambiar.Visible = true;
        btnCambiar2.Visible = false;
        RegistroUsuario.Visible = false;
        Listado.Visible = false;
    }

}