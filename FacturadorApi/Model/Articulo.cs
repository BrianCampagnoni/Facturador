namespace FacturadorApi.Model
{
    public class Articulo
    {
        public int Art_id { get; set; }
        public string NombreArticulo { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
    }
}

//create table Articulo(
//	ART_ID int Primary Key Identity(10,10) not null,
//	NombreArticulo nvarchar(100),
//	Marca nvarchar(100),
//	Descripcion nvarchar(255)
//)