namespace FacturadorApi.Model
{
    public class Factura_Cabecera
    {
        public string FC_ID { get; set; }
        public string Estado { get; set; }
        public DateOnly FechaAlta { get; set; }
        public int Cli_ID { get; set; }
    }
}

//create table Factura_Cabecera(
//	FC_ID int Primary Key identity(2000,1) not null,
//	FechaAlta date,
//	Estado nvarchar(50),
//	Cli_ID int Foreign Key References Cliente(Cli_ID) not null
//)