namespace FacturadorApi.Model
{
    public class Factura_Cabecera
    {
        public int FC_ID { get; set; }
        public string? Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Cli_ID { get; set; }
    }
}

//create table Factura_Cabecera(
//	FC_ID int Primary Key identity(2000,1) not null,
//	FechaAlta date,
//	Estado nvarchar(50),
//	Cli_ID int Foreign Key References Factura_Cabecera(Cli_ID) not null
//)