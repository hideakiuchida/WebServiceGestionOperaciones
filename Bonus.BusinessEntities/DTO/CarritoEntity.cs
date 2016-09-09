using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus.BusinessEntities.DTO
{
    public class CarritoCoEntity
    {
        //Codigo de correo 
        public string PrsMaiCod { get; set; }
        //correo 
        public string PrsMai { get; set; }
        //Codigo error 
        public string PrsFlgMErr { get; set; }
    }

    public class CarritoTeEntity
    {
        //Codigo de Telefono
        public string PrsTlfCod { get; set; }
        //Prefijo telefono
        public int PrsPreTlf { get; set; }
        //Numero  Telefono
        public string PrsNroTlf { get; set; }
        public int PrsAnxTlf { get; set; }
        public string PrsFlgMov { get; set; }
        //Red privada
        public string PrsRedPrv { get; set; }
        //Tipo Telefono
        public int TlfRefCod { get; set; }
        public int OtfCod { get; set; }
        public string PrsFlgTErr { get; set; }
    }

    public class CarritoHij
    {
        //Edad Hijo
        public int PrsHijEda { get; set; }
        //Sexo Hijo
        public string PrsHijSex { get; set; }
    }

    public class CarritoMen
    {
        public int MenSec { get; set; }
        public string MenDes { get; set; }
        public string BtnNomTar { get; set; }
    }

    public class TipoCuentaEntity
    {
        public IEnumerable<CarritoMen> CarritoMen { get; set;}
        public int ExistePrs { get; set; }
        public int? ResultCode { get; set; }
    }

}
