namespace FacturadorApi.Model
{
    public class Factura_Detalle
    {
        public int FC_DTL_ID { get; set; }
        public DateOnly FechaAlta { get; set; }
        public decimal Cant { get; set; }
        public decimal Precio { get; set; }
        public decimal Monto { get; set; }
        public int Fact_ID { get; set; }
        public int Art_ID { get; set; }


    }
}


//create table Factura_Detalle(
//	FC_DTL_ID int Primary Key Identity(1,1) not null,
//	FechaAlta date,
//	Cant decimal,
//	Precio decimal,
//	Monto decimal,
//	Fact_ID int Foreign Key References Factura_Cabecera(FC_ID) not null,
//	Art_ID int Foreign Key References Articulo(ART_ID) not null,
//)