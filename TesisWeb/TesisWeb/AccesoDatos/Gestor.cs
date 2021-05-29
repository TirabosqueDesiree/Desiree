using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TesisWeb.Models;
using TesisWeb.Models.clasesProducto;
using TesisWeb.Models.clasesUsuarios;

namespace TesisWeb.AccesoDatos
{
    public class Gestor
    {
        public string cadenaCon = "Data Source=desiree;Initial Catalog=J&ACarnes;Integrated Security=True";

        public void InsertarProductos(VMProducto prod)
        {
            var sql = "INSERT INTO Productos (idTipoProducto, idMarca, descripcion, precio, idOferta, imagen) VALUES (@idTipoProducto, @idMarca, @descripcion, @precio, @idOferta, @imagen)";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@idTipoProducto", prod.ProductoModel.IdTipoProducto);
            cmd.Parameters.AddWithValue("@idMarca", prod.ProductoModel.IdMarca);
            cmd.Parameters.AddWithValue("@descripcion", prod.ProductoModel.Descripcion);
            cmd.Parameters.AddWithValue("@precio", prod.ProductoModel.Precio);
            cmd.Parameters.AddWithValue("@idOferta", prod.ProductoModel.idOferta);
            cmd.Parameters.AddWithValue("@imagen", prod.ProductoModel.imagenProducto);



            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void InsertarMarcas(Marca marca)
        {
            var sql = "INSERT INTO Marcas (descripcion) VALUES (@descripcion)";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@descripcion", marca.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void InsertarTipoProd(TipoProducto tp)
        {
            var sql = "INSERT INTO TiposProductos (descripcion) VALUES (@descripcion)";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@descripcion", tp.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void InsertarOferta(Oferta oferta)
        {
            var sql = "INSERT INTO Ofertas (descripcion) VALUES (@descripcion)";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@descripcion", oferta.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public Producto BuscarProductos(int Id)
        {
            var sql = "SELECT * FROM Productos WHERE idProducto = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Producto prod = new Producto();
            prod.IdProducto = (int)dr["idProducto"];
            prod.IdTipoProducto = int.Parse(dr["idTIpoProducto"].ToString());
            prod.IdMarca = int.Parse(dr["idMarca"].ToString());
            prod.Descripcion = dr["descripcion"].ToString();
            prod.Precio = double.Parse(dr["precio"].ToString());
            prod.idOferta = int.Parse(dr["idOferta"].ToString());
            
            dr.Close();
            conex.Close();

            return prod;

        }
        public TipoProducto BuscarTipoProductos(int Id)
        {
            var sql = "SELECT * FROM TiposProductos WHERE idTipoProducto = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            TipoProducto tipoProd = new TipoProducto();
            tipoProd.IdTipoProducto = (int)dr["idTipoProducto"];
            tipoProd.Descripcion = dr["descripcion"].ToString();

            dr.Close();
            conex.Close();

            return tipoProd;

        }
        public Marca BuscarMarcas(int Id)
        {
            var sql = "SELECT * FROM Marcas WHERE idMarca = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Marca marca = new Marca();
            marca.IdMarca = (int)dr["idMarca"];
            marca.Descripcion = dr["descripcion"].ToString();

            dr.Close();
            conex.Close();

            return marca;

        }
        public Oferta BuscarOfertas(int Id)
        {
            var sql = "SELECT * FROM Ofertas WHERE idOferta = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", Id);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            Oferta o = new Oferta();
            o.IdOferta = (int)dr["idOferta"];
            o.Descripcion = dr["descripcion"].ToString();

            dr.Close();
            conex.Close();

            return o;

        }






        public void EditarProductos(Producto prod)
        {
            var sql = "UPDATE Productos SET idTipoProducto=@idTipoProducto, idMarca=@idMarca, descripcion=@descripcion, precio=@precio, idOferta=@idOferta, imagen=@imagen WHERE idProducto= @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", prod.IdProducto);
            cmd.Parameters.AddWithValue("@idTipoProducto", prod.IdTipoProducto);
            cmd.Parameters.AddWithValue("@idMarca", prod.IdMarca);
            cmd.Parameters.AddWithValue("@descripcion", prod.Descripcion);
            cmd.Parameters.AddWithValue("@precio", prod.Precio);
            cmd.Parameters.AddWithValue("@idOferta", prod.idOferta);
            cmd.Parameters.AddWithValue("@imagen", prod.imagenProducto);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EditarTipoProductos(TipoProducto tipoProd)
        {
            var sql = "UPDATE TiposProductos SET  descripcion=@descripcion WHERE idTipoProducto= @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", tipoProd.IdTipoProducto);
            cmd.Parameters.AddWithValue("@descripcion", tipoProd.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EditarMarca(Marca marca)
        {
            var sql = "UPDATE Marcas SET  descripcion=@descripcion WHERE idMarca= @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", marca.IdMarca);
            cmd.Parameters.AddWithValue("@descripcion", marca.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EditarOferta(Oferta o)
        {
            var sql = "UPDATE Ofertas SET  descripcion=@descripcion WHERE idOferta= @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", o.IdOferta);
            cmd.Parameters.AddWithValue("@descripcion", o.Descripcion);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EliminarProducto(Producto prod)
        {
            var sql = "delete  from Productos where idProducto = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", prod.IdProducto);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EliminarTipoProducto(TipoProducto tipo)
        {
            var sql = "delete  from TiposProductos where idTipoProducto = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", tipo.IdTipoProducto);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EliminarMarca(Marca m)
        {
            var sql = "delete  from Marcas where idMarca = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", m.IdMarca);
            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public void EliminarOferta(Oferta o)
        {
            var sql = "delete  from Ofertas where idOferta = @id";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@id", o.IdOferta);
            cmd.ExecuteNonQuery();
            conex.Close();

        }


        public List<DTOProducto> ListadoProductos()
        {
            var lista = new List<DTOProducto>();
            var sql = @"SELECT p.idProducto Id,  t.descripcion TipoProducto,  m.descripcion Marca , p.descripcion Producto, p.precio Precio, o.descripcion Oferta
                        FROM Productos p, Marcas m, TiposProductos t, Ofertas o
                        WHERE p.idMarca=m.idMarca and p.idTipoProducto=t.idTipoProducto and p.idOferta=o.idOferta
                        order by 3";

            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    DTOProducto prod = new DTOProducto();
                    prod.IdProducto = (int)dr["Id"];
                    prod.TipoProducto = dr["TipoProducto"].ToString();
                    prod.Marca = dr["Marca"].ToString();
                    prod.Descripcion = dr["Producto"].ToString();
                    prod.Precio = double.Parse(dr["Precio"].ToString());
                    prod.Oferta = (dr["Oferta"].ToString());

                    lista.Add(prod);
                }
            }
            dr.Close();
            conex.Close();
            return lista;
        }







        public List<Marca> ListadoMarcas()
        {
            var lista = new List<Marca>();
            var sql = "SELECT * from Marcas";

            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {
                    Marca marca = new Marca();
                    marca.IdMarca = (int)dr["idMarca"];
                    marca.Descripcion = dr["descripcion"].ToString();

                    lista.Add(marca);
                }
            }
            dr.Close();
            conex.Close();
            return lista;
        }
        public List<TipoProducto> ListadoTiposProd()
        {
            var lista = new List<TipoProducto>();
            var sql = "SELECT * from TiposProductos";

            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {

                    TipoProducto t = new TipoProducto();
                    t.IdTipoProducto = (int)dr["idTipoProducto"];
                    t.Descripcion = dr["descripcion"].ToString();

                    lista.Add(t);
                }
            }
            dr.Close();
            conex.Close();
            return lista;
        }
        public List<Oferta> ListadoOfertas()
        {
            var lista = new List<Oferta>();
            var sql = "SELECT * from Ofertas";

            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {

                    Oferta oferta = new Oferta();
                    oferta.IdOferta = (int)dr["idOferta"];
                    oferta.Descripcion = dr["descripcion"].ToString();


                    lista.Add(oferta);
                }
            }
            dr.Close();
            conex.Close();
            return lista;
        }

        public void Insertarusuarios(VMUsuario usuario)
        {
            var sql = "INSERT INTO Usuarios (email, contraseña, idRol) VALUES (@email, @contraseña, @idRol)";
            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            cmd.Parameters.AddWithValue("@email", usuario.UsuarioModel.email);
            cmd.Parameters.AddWithValue("@contraseña", usuario.UsuarioModel.contraseña);
            cmd.Parameters.AddWithValue("@idRol", usuario.UsuarioModel.idRol);
            


            cmd.ExecuteNonQuery();
            conex.Close();

        }
        public List<RolesUsuarios> ListadoRoles()
        {
            var lista = new List<RolesUsuarios>();
            var sql = "SELECT * from RolesUsuarios";

            SqlConnection conex = new SqlConnection(cadenaCon);
            conex.Open();
            SqlCommand cmd = new SqlCommand(sql, conex);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                while (dr.Read())
                {

                    RolesUsuarios rol = new RolesUsuarios();
                    rol.idRol= (int)dr["idRol"];
                    rol.descripcion = dr["descripcion"].ToString();


                    lista.Add(rol);
                }
            }
            dr.Close();
            conex.Close();
            return lista;
        }
    }
}