using Bonus.BusinessEntities.DTO;
using Bonus.BusinessServices.Interfaces;
using Bonus.WebApi.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bonus.WebApi.Controllers
{
    //[AuthorizationRequired]
    public class ClienteController : ApiController
    {
        #region Private variable.

        private readonly IClienteServices _services;

        #endregion

        #region Public Constructor

        public ClienteController(IClienteServices services)
        {
            _services = services;
        }
        #endregion

        [Route("Cliente")]
        [HttpGet]
        public ClienteEntity Cliente(string prsCod)
        {
            return _services.ObtenerCliente(prsCod);
        }

        [Route("ExisteCliente")]
        [HttpGet]
        public ClienteEntity ExisteCliente(int tipoDocCod, string prsNroDoc)
        {
            return _services.ExisteCliente(Convert.ToInt16(tipoDocCod), prsNroDoc);
        }
    
        [Route("ObtenerMovFidelizacion")]
        [HttpGet]
        public MovFideEntity ObtenerMovFidelizacion(string ctaPrsCod, int ctaCod)
        {
            return _services.ObtenerMovFidelizacion(ctaPrsCod, ctaCod);
        }

        [Route("ObtenerCuentas")]
        [HttpGet]
        public CuentaInfoEntity ObtenerCuentas(string ctaPrsCod)
        {
            return _services.ObtenerCuentas(ctaPrsCod);
        }


        [Route("AfiliarClientes")]
        [HttpPost]
        public int AfiliarClientes(int tipDoc, string userId, long idCodEmp, string ptcCod, string pCnjCod, int tipoDatCli, string prsCodIn,
              string ctaPrsCodIn, int ctaCodIn, string pCtaAsoCodIn, int tipoDocCod, string prsNroDoc, string prsApePat,
              string prsApeMat, string prsPriNom, string prsSegNom, string prsTerNom, string prsSex, int estCivCod,
              string oPrsFecNac, string nacPrs, int datTel, int prsPreTlf1, int prsPreTlf2, int prsPreTlf3,
              int prsFlgMov1, int prsFlgMov2, int prsFlgMov3, int prsNroTlf1, int prsNroTlf2, int prsNroTlf3,
              string prsRedPrv1, string prsRedPrv2, string prsRedPrv3, int datCor, string prsMai1, string prsMai2, string prsMai3,
              string direccion, string referencia, string dptoCod, string probCod, string distCod, string dirnCooY, string dirCooX,
              string ocupacion, string centroLabores, string organismoPublico, string cargoPEP, string flgTieVeh, string flgTIeHij,
              int prsEdadHijo1, int prsEdadHijo2, int prsEdadHijo3, string prsHijSex1, string prsHijSex2, string prsHijSex3, int tarCod, int modPag, int nroTrns, int codProm,
              string prsFirma, string prsFirma2, string tarAlias, string tarAnno)
        {
            return _services.AfiliarClientes(tipDoc, userId, idCodEmp, ptcCod, pCnjCod, tipoDatCli, prsCodIn, ctaPrsCodIn,
                (short)ctaCodIn, pCtaAsoCodIn, (short)tipoDocCod, prsNroDoc, prsApePat, prsApeMat, prsPriNom, prsSegNom, prsTerNom, prsSex,
                estCivCod, oPrsFecNac, nacPrs, datTel, prsPreTlf1, prsPreTlf2, prsPreTlf3, prsFlgMov1, prsFlgMov2, prsFlgMov3,
                prsNroTlf1, prsNroTlf2, prsNroTlf3, prsRedPrv1, prsRedPrv2, prsRedPrv3, datCor, prsMai1, prsMai2, prsMai3,
                direccion, referencia, dptoCod, null, distCod, dirCooX, dirCooX, ocupacion, centroLabores, organismoPublico,
                cargoPEP, flgTieVeh, flgTIeHij, prsEdadHijo1, prsEdadHijo2, prsEdadHijo3,
                prsHijSex1, prsHijSex2, prsHijSex3, tarCod, modPag, nroTrns, codProm, prsFirma, prsFirma2, tarAlias, tarAnno);
        }

        [Route("ValidarAfiliacion")]
        [HttpGet]
        public int ValidarAfiliacion(string ctaPrsCod, int ctaCod, string pCtaAsoCod)
        {
            return _services.ValidarAfiliacion(ctaPrsCod, ctaCod, pCtaAsoCod);
        }

        [Route("ValidarCodigoPromocional")]
        [HttpGet]
        public int ValidarCodigoPromocional(int codProm)
        {
            return _services.ValidarCodigoPromocional(codProm);
        }

        [Route("ObtenerMenuAfiliacion")]
        [HttpGet]
        public TipoCuentaEntity ObtenerMenuAfiliacion(int cantidadCta, string ctaPrsCod, int ctaCod, string pCtaAsoCod, string pCtatip, string pCtaautcnj)
        {
            return _services.ObtenerMenuAfiliacion(cantidadCta, ctaPrsCod, ctaCod, pCtaAsoCod, pCtatip, pCtaautcnj);
        }
    }
}
