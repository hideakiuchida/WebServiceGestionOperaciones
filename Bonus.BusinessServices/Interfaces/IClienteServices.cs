using Bonus.BusinessEntities.DTO;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IClienteServices
    {
        ClienteEntity ExisteCliente(short tipodoccod, string prsnrodoc);
        ClienteEntity ObtenerCliente(string prsCod);
        MovFideEntity ObtenerMovFidelizacion(string ctaPrsCod, int ctaCod);
        CuentaInfoEntity ObtenerCuentas(string ctaPrsCod);
        int AfiliarClientes(int tipDoc, string userId, long idCodEmp, string ptcCod, string pCnjCod, int tipoDatCli, string prsCodIn, 
                string ctaPrsCodIn, int ctaCodIn, string pCtaAsoCodIn, int tipoDocCod, string prsNroDoc, string prsApePat,
                string prsApeMat, string prsPriNom, string prsSegNom, string prsTerNom, string prsSex, int estCivCod, 
                string oPrsFecNac, string nacPrs, int datTel, int prsPreTlf1, int prsPreTlf2, int prsPreTlf3, 
                int prsFlgMov1, int prsFlgMov2, int prsFlgMov3, int prsNroTlf1, int prsNroTlf2, int prsNroTlf3,
                string prsRedPrv1, string prsRedPrv2, string prsRedPrv3, int datCor, string prsMai1, string prsMai2, string prsMai3,
                string direccion, string referencia, string dptoCod, string probCod, string distCod, string dirnCooY, string dirCooX,
                string ocupacion, string centroLabores, string organismoPublico, string cargoPEP, string flgTieVeh, string flgTIeHij,
                int prsEdadHijo1, int prsEdadHijo2, int prsEdadHijo3, string prsHijSex1, string prsHijSex2, string prsHijSex3, int tarCod, int modPag, int nroTrns, int codProm, 
                string prsFirma, string prsFirma2, string tarAlias, string tarAnno);
        int ValidarAfiliacion(string ctaPrsCod, int ctaCod, string pCtaAsoCod);
        int ValidarCodigoPromocional(int codProm);
    }
}
