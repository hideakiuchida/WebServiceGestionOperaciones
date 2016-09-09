using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus.BusinessEntities.DTO
{
    public class ClienteEntity
    {
        //Codigo de persona
        public string PrsCod { get; set; }
        //Tipo de Cliente
        public int TipoDatCli { get; set; }
        //Apellido paterno
        public string PrsApePat { get; set; }
        //Apellido materno
        public string PrsApeMat { get; set; }
        //Primer Nombre
        public string PrsPriNom { get; set; }
        //Segundo Nombre
        public string PrsSegNom { get; set; }
        //Tercer Nombre
        public string PrsTerNom { get; set; }
        //Nro de Documento
        public string PrsNroDoc { get; set; }
        //Tipo Documento
        public int TipDocCod { get; set; }
        //Sexo
        public string PrsSex { get; set; }
        //Fecha nacimciento
        public string PrsFecNac { get; set; }
        //Nacionalidad
        public string NacPrs { get; set; }
        //Motivo de No ingreso --> 0 = Ingreso Correo, 1 = No quiere, 2 = No tiene
        public int DatCor { get; set; }
        //Motivo de No ingreso del correo
        public int DatTel { get; set; }
        //Ocupacion
        public string Ocupacion { get; set; }
        //Centro Laborales
        public string CentroLaborales { get; set; }
        //Organismo
        public string OrganismoPublico { get; set; }
        //Cargo 
        public string CargoPEP { get; set; }
        public string Texto1 { get; set; }
        public string Texto2 { get; set; }
        public string Texto3 { get; set; }
        public string Texto4 { get; set; }
        public string Texto5 { get; set; }
        public List<CarritoCoEntity> carritosCo { get; set; }
        public List<CarritoTeEntity> carritosTe { get; set; }

        //Direccion Concatenada
        public string Direccion { get; set; }
        //Referencia
        public string Referencia { get; set; }
        //Departamento
        public string DptoCod { get; set; }
        //Provincia
        public string ProvCod { get; set; }
        //Distrito
        public string DistCod { get; set; }
        //Tiene Vehiculo
        public string FlgTieVeh { get; set; }
        //Tiene Hijos
        public string FlgTieHij { get; set; }

        public List<CarritoHij> carritosHij { get; set; }

        //This field ResultCode exist for manage Errors
        public int? ResultCode { get; set; }

        public string MsgError { get; set; }

        public string Text1 { get; set; }

        public string PrsDept { get; set; }

        public string PrsProv { get; set; }

        public string PaisCod { get; set; }

        public string TipPrsDept { get; set; }
        public sbyte EstCivCod { get; set; }
        public string Cargo { get; set; }
        public string SituacionLaboral { get; set; }
    }
}
