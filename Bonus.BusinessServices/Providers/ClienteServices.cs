using Bonus.BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bonus.BusinessEntities.DTO;

namespace Bonus.BusinessServices.Providers
{
    public class ClienteServices : IClienteServices
    {

        public int AfiliarClientes(int tipDoc, string userId, long idCodEmp, string ptcCod, string pCnjCod, int tipoDatCli, 
            string prsCodIn, string ctaPrsCodIn, int ctaCodIn, string pCtaAsoCodIn, int tipoDocCod, string prsNroDoc, string prsApePat, 
            string prsApeMat, string prsPriNom, string prsSegNom, string prsTerNom, string prsSex, int estCivCod, string oPrsFecNac, string nacPrs, 
            int datTel, int prsPreTlf1, int prsPreTlf2, int prsPreTlf3, int prsFlgMov1, int prsFlgMov2, int prsFlgMov3, int prsNroTlf1, int prsNroTlf2, 
            int prsNroTlf3, string prsRedPrv1, string prsRedPrv2, string prsRedPrv3, int datCor, string prsMai1, string prsMai2, string prsMai3, 
            string direccion, string referencia, string dptoCod, string probCod, string distCod, string dirnCooY, string dirCooX, string ocupacion, 
            string centroLabores, string organismoPublico, string cargoPEP, string flgTieVeh, string flgTIeHij, int prsEdadHijo1, int prsEdadHijo2, int prsEdadHijo3, 
            string prsHijSex1, string prsHijSex2, string prsHijSex3, int tarCod, int modPag, int nroTrns, int codProm, string prsFirma, string prsFirma2, string tarAlias, string tarAnno)
        {
            WsBonusAfilicacionCliente.wsAfiClinSoapPortClient ws = new WsBonusAfilicacionCliente.wsAfiClinSoapPortClient();
            string msgError;
            int respuesta = ws.Execute(Convert.ToSByte(tipDoc), userId, idCodEmp, ptcCod, pCnjCod, Convert.ToSByte(tipoDatCli), prsCodIn, ctaPrsCodIn,
                (short) ctaCodIn, pCtaAsoCodIn, (short) tipoDocCod, prsNroDoc, prsApePat, prsApeMat, prsPriNom, prsSegNom, prsTerNom, prsSex,
                Convert.ToSByte(estCivCod), oPrsFecNac, nacPrs, Convert.ToSByte(datTel), prsPreTlf1, prsPreTlf2, prsPreTlf3, Convert.ToSByte(prsFlgMov1), Convert.ToSByte(prsFlgMov2), Convert.ToSByte(prsFlgMov3),
                prsNroTlf1, prsNroTlf2, prsNroTlf3, prsRedPrv1, prsRedPrv2, prsRedPrv3, Convert.ToSByte(datCor), prsMai1, prsMai2, prsMai3,
                direccion, referencia, dptoCod, null, distCod, dirCooX, dirCooX, ocupacion, centroLabores, organismoPublico,
                cargoPEP, flgTieVeh, flgTIeHij, Convert.ToSByte(prsEdadHijo1), Convert.ToSByte(prsEdadHijo2), Convert.ToSByte(prsEdadHijo3), 
                prsHijSex1, prsHijSex2, prsHijSex3, tarCod, Convert.ToSByte(modPag), nroTrns, codProm, prsFirma, prsFirma2, tarAlias, Convert.ToSByte(tarAnno), out msgError);
            return respuesta;
        }


        public ClienteEntity ExisteCliente(short tipodoccod, string prsnrodoc)
        {
            WsBonusExisteClienteBonus.wsexicliboSoapPortClient ws = new WsBonusExisteClienteBonus.wsexicliboSoapPortClient();

            string msgError = "";
            string prsCod;
            sbyte tipDatCli;
            /*
                0: Éxito
                1: Código de tipo de documento nulo
                2: Número de documento nulo
                3: Tipo y número de documento no encontrado
                4: Código de persona nula
                5: No existe cliente bonus
            */
            int respuesta = ws.Execute(tipodoccod, prsnrodoc, out msgError, out prsCod, out tipDatCli);
            ClienteEntity cliente = new ClienteEntity();
            if (respuesta == 0)
            {
                cliente.PrsCod = prsCod;
                cliente.TipoDatCli = tipDatCli;
            }
            else
            {
                cliente.ResultCode = respuesta;
            }
            return cliente;
        }

        public int ValidarCodigoPromocional(int codProm)
        {
            WsBonusCodigoPromocional.wsvalpromSoapPortClient ws = new WsBonusCodigoPromocional.wsvalpromSoapPortClient();
            string msgError;
            int respuesta = ws.Execute(codProm, out msgError);
            return respuesta;
        }

        public CuentaInfoEntity ObtenerCuentas(string ctaPrsCod)
        {
            WsBonusInfoCuenta.wslisctaptSoapPortClient ws = new WsBonusInfoCuenta.wslisctaptSoapPortClient();
            WsBonusInfoCuenta.LisctaptoLisctaptoItem[] carritoCta;
            
            string msgError, PrsNroDoc, PrsNomApe;
            short PrsTipdCod;
            int respuesta = ws.Execute(ctaPrsCod, out msgError, out carritoCta, out PrsTipdCod, out PrsNroDoc, out PrsNomApe);
            CuentaInfoEntity cuentaInfo = new CuentaInfoEntity();
            List<CuentaEntity> cuentaEntity = new List<CuentaEntity>();
            /*
                0: Éxito
                1: Código de persona nula
                2: Código de cuenta nula
                3: Código de persona no existe
            */
            if (respuesta == 0)
            {

                foreach (var item in carritoCta)
                {
                    CuentaEntity cuenta = new CuentaEntity();
                    cuenta.CtaCod = item.CtaCod;
                    cuenta.CtaAsoNom = item.CtaAsoNom;
                    cuenta.CtaPrsCod = item.CtaPrsCod;
                    cuenta.CtaPrsNom = item.CtaPrsNom;
                    cuenta.CtaSalCon = item.CtaSalCon;
                    cuenta.CtaSalDsp = item.CtaSalDsp;
                    cuenta.CtaSalVig = item.CtaSalVig;
                    cuenta.PCtaAsoCod = item.PCtaAsoCod;
                    cuenta.PCtaAutCnj = item.PCtaAutCnj;
                    cuenta.PCtaTip = item.PCtaTip;
                    cuenta.TipPunCod = item.TipPunCod;
                    cuenta.PCtaTipNom = item.PCtaTipNom;
                    cuentaEntity.Add(cuenta);
                }
                cuentaInfo.CuentaEntities = cuentaEntity;
                cuentaInfo.PrsNomApe = PrsNomApe;
                cuentaInfo.PrsNroDoc = PrsNroDoc;
                cuentaInfo.PrsTipdCod = PrsTipdCod;
            }
            else {
                cuentaInfo.ResultCode = respuesta;
            }
            return cuentaInfo;

        }

        public ClienteEntity ObtenerCliente(string prsCod)
        {
            WsBonusClientesDatos.wsdevdatcoSoapPortClient ws = new WsBonusClientesDatos.wsdevdatcoSoapPortClient();
            
            ClienteEntity cliente = new ClienteEntity();
            WsBonusClientesDatos.ListelListelItem[] carritoTe;
            WsBonusClientesDatos.LismaiLismaiItem[] carritoCo;
            WsBonusClientesDatos.LishijLishijItem[] carritoHij;

            string PrsApePat, PrsApeMat, PrsPriNom, PrsSegNom, PrsTerNom, PrsNroDoc;
            string PrsSex, Texto1, Texto2, Texto3, Texto4, Texto5, Direccion;
            string PrsFecNac, Referencia, DptoCod, ProvCod, DistCod, FlgTieVeh, FlgTieHij, Datcor, Dattel;
            string Ocupacion, Centrolabores, Clientepep, Cargopep, NacPrs, msgError;
            short TipDocCod;
            int respuesta = ws.Execute(prsCod, out msgError, out PrsApePat, out PrsApeMat, out PrsPriNom, out PrsSegNom, out PrsTerNom,
                            out TipDocCod, out PrsNroDoc, out PrsSex, out PrsFecNac, out NacPrs, out Texto1, 
                            out Texto2, out Texto3, out Texto4, out Texto5, out Datcor, out carritoCo, out Dattel,
                            out carritoTe, out Direccion, out Referencia, out DptoCod, out ProvCod, out DistCod,
                            out Ocupacion, out Centrolabores, out Clientepep, out Cargopep, out FlgTieVeh, out FlgTieHij,
                            out carritoHij);   
            /*
                0: Éxito
                1: Código de persona nula
                2: Código de persona no existe
            */
            if (respuesta == 0)
            {
                cliente.PrsCod = prsCod;
                cliente.PrsNroDoc = PrsNroDoc;
                cliente.PrsApePat = PrsApePat;
                cliente.PrsApeMat = PrsApeMat;
                cliente.PrsPriNom = PrsPriNom;
                cliente.PrsSegNom = PrsSegNom;
                cliente.PrsTerNom = PrsTerNom;
                cliente.TipDocCod = TipDocCod;
                cliente.PrsSex = PrsSex;
                cliente.PrsFecNac = PrsFecNac;
                cliente.NacPrs = NacPrs;
                cliente.Texto1 = Texto1;
                cliente.Texto2 = Texto2;
                cliente.Texto3 = Texto3;
                cliente.Texto4 = Texto4;
                cliente.Texto5 = Texto5;
                cliente.DatCor = Convert.ToInt32(Datcor);

                List<CarritoCoEntity> _carritoCo = new List<CarritoCoEntity>();
                foreach (var item in carritoCo)
                {
                    CarritoCoEntity carrito = new CarritoCoEntity();
                    carrito.PrsMaiCod = item.PrsMaiCod.ToString();
                    carrito.PrsMai = item.PrsMai;
                    carrito.PrsFlgMErr = item.PrsFlgMErr;
                    _carritoCo.Add(carrito);
                }
                cliente.DatTel = Convert.ToInt32(Dattel);
                cliente.carritosCo = _carritoCo;

                List<CarritoTeEntity> _carritoTe = new List<CarritoTeEntity>();
                foreach (var item in carritoTe)
                {
                    CarritoTeEntity carrito = new CarritoTeEntity();
                    carrito.PrsAnxTlf = item.PrsAnxTlf;
                    carrito.OtfCod = item.OtfCod;
                    carrito.PrsFlgMov = item.PrsFlgMov.ToString();
                    carrito.PrsFlgTErr = item.PrsFlgTErr;
                    carrito.PrsNroTlf = item.PrsNroTlf.ToString();
                    carrito.PrsPreTlf = item.PrsPreTlf;
                    carrito.PrsRedPrv = item.PrsRedPrv;
                    carrito.PrsTlfCod = item.PrsTlfCod.ToString();
                    carrito.TlfRefCod = item.TlfRefCod;
                    _carritoTe.Add(carrito);
                }

                cliente.carritosTe = _carritoTe;

                cliente.Direccion = Direccion;
                cliente.Referencia = Referencia;
                cliente.DptoCod = DptoCod;
                cliente.ProvCod = ProvCod;
                cliente.DistCod = DistCod;
                cliente.Ocupacion = Ocupacion;
                cliente.CentroLaborales = Centrolabores;
                cliente.OrganismoPublico = "";
                cliente.CargoPEP = Cargopep;
                cliente.FlgTieVeh = FlgTieVeh;
                cliente.FlgTieHij = FlgTieHij;

                List<CarritoHij> _carritoHij = new List<CarritoHij>();
                foreach (var item in carritoHij)
                {
                    CarritoHij carrito = new CarritoHij();
                    carrito.PrsHijSex = item.PrsHijSex;
                    carrito.PrsHijEda = item.PrsHijEda;
                    _carritoHij.Add(carrito);
                }
                cliente.carritosHij = _carritoHij;
            }
            else {
                cliente.ResultCode = respuesta;
            }
            return cliente;
        }

        public MovFideEntity ObtenerMovFidelizacion(string ctaPrsCod, int ctaCod)
        {
            WsBonusMovFidelizacion.wsultmovptSoapPortClient ws = new WsBonusMovFidelizacion.wsultmovptSoapPortClient();
            WsBonusMovFidelizacion.UltMovPtoUltMovPtoItem[] _movFid;
            string msgError;
            int nroTra;
            int respuesta = ws.Execute(ctaPrsCod, Convert.ToInt16(ctaCod), out msgError, out nroTra, out _movFid);
            MovFideEntity movFideEntity = new MovFideEntity();
            /*
            0: Éxito
            1: Código de persona nula
            2: Código de persona no existe

            */
            if (respuesta == 0)
            {
                movFideEntity.NroTrn = nroTra;
                List<Transaccion> _transacciones = new List<Transaccion>();
                foreach (var item in _movFid)
                {
                    Transaccion transaccion = new Transaccion();
                    transaccion.Descrip = item.Descrip;
                    transaccion.EsCanje = item.EsCanje;
                    transaccion.FchAsig = item.FchAsig;
                    transaccion.FchHor = item.FchHor;
                    transaccion.FchProc = item.FchProc;
                    transaccion.HorProc = item.HorProc;
                    transaccion.PtosAsig = item.PtosAsig;
                    transaccion.PtosCanj = item.PtosCanj;
                    _transacciones.Add(transaccion);
                }
                movFideEntity.Transacciones = _transacciones;
            }
            else {
                movFideEntity.ResultCode = respuesta;
            }
            return movFideEntity;
        }

        public int ValidarAfiliacion(string ctaPrsCod, int ctaCod, string pCtaAsoCod)
        {
            WsBonusValidarAfiliacion.wsconctaadSoapPortClient ws = new WsBonusValidarAfiliacion.wsconctaadSoapPortClient();
            string msgError;
            int respuesta = ws.Execute(ctaPrsCod, (short)ctaCod, pCtaAsoCod, out msgError);
            return respuesta;
        }

        public TipoCuentaEntity ObtenerMenuAfiliacion(int cantidadCta, string ctaPrsCod, int ctaCod, 
            string pCtaAsoCod, string pCtatip, string pCtaautcnj)
        {
            WsBonusObtenerMenuAfiliacion.wsmenafiSoapPortClient ws = new WsBonusObtenerMenuAfiliacion.wsmenafiSoapPortClient();
            string msgError;
            sbyte existePrs;
            WsBonusObtenerMenuAfiliacion.LismenafiLismenafiItem[] listCarritoMenu;
            int respuesta = ws.Execute((short)cantidadCta, ctaPrsCod, (short)ctaCod, pCtaAsoCod, pCtatip, pCtaautcnj, 
                out msgError, out listCarritoMenu, out existePrs);

            TipoCuentaEntity tipoCuenta = new TipoCuentaEntity();
            if (respuesta == 0)
            {
                List<CarritoMen> _carritoMenu = new List<CarritoMen>();
                foreach (var item in listCarritoMenu)
                {
                    CarritoMen carrito = new CarritoMen();
                    carrito.MenSec = item.mensec;
                    carrito.MenDes = item.mendes;
                    _carritoMenu.Add(carrito);
                }
                tipoCuenta.CarritoMen = _carritoMenu;
                tipoCuenta.ExistePrs = existePrs;
            }
            return tipoCuenta;
        }
    }
}
