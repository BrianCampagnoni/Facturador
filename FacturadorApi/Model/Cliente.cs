using Microsoft.EntityFrameworkCore;

namespace FacturadorApi.Model
{
    
    public class Cliente 
    {
        public int Cli_ID { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public bool Deshabilitado { get; set; }
    }



}

//create table Cliente (
//	Cli_ID int primary key identity(1000,1) not null,
//	RazonSocial nvarchar(255),
//	CUIT nvarchar(50),
//	Direccion nvarchar(255),
//	Deshabilitado bit
//)