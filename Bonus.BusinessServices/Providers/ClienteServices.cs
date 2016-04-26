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
        public string ExisteCliente(short tipodoccod, string prsnrodoc)
        {
            WsBonusExisteClienteBonus.wsexicliboSoapPortClient ws = new WsBonusExisteClienteBonus.wsexicliboSoapPortClient();

            string msgError = "";
            string prsCod;

            /*
                0: Éxito
                1: Código de tipo de documento nulo
                2: Número de documento nulo
                3: Tipo y número de documento no encontrado
                4: Código de persona nula
                5: No existe cliente bonus
            */
            int respuesta = ws.Execute(tipodoccod, prsnrodoc, out msgError, out prsCod);
            if (respuesta == 0)
            {
                return prsCod;
            }
            return respuesta.ToString();
        }

        public ClienteEntity ObtenerCliente(string prsCod)
        {
           WsBonusObtenerDatosClientes.wsdevdatcoSoapPortClient ws = new WsBonusObtenerDatosClientes.wsdevdatcoSoapPortClient();

           string msgError = "";
           ClienteEntity cliente = new ClienteEntity();
           WsBonusObtenerDatosClientes.ListelListelItem[] carritoTe;
           WsBonusObtenerDatosClientes.LismaiLismaiItem[] carritoCo;
           WsBonusObtenerDatosClientes.LishijLishijItem[] carritoHij;

           string PrsApePat, PrsApeMat, PrsPriNom, PrsSegNom, PrsTerNom, PrsNroDoc, PrsSex, Texto1, Texto2, Texto3, Texto4, Texto5, Direccion;
           short TipDocCod;
           string PrsFecNac, Referencia, DptoCod, ProvCod, DistCod, FlgTieVeh, FlgTieHij;

           int respuesta = ws.Execute(prsCod, out msgError, out PrsApePat, out PrsApeMat, out PrsPriNom, out PrsSegNom, out PrsTerNom,
               out TipDocCod, out PrsNroDoc, out PrsSex, out PrsFecNac, out Texto1, out Texto2, out Texto3, out Texto4,
               out Texto5, out carritoCo, out carritoTe, out Direccion, out Referencia, out DptoCod, out ProvCod, out DistCod, out FlgTieVeh,
               out FlgTieHij, out carritoHij);

            /*
                0: Éxito
                1: Código de persona nula
                2: Código de persona no existe
            */
            if (respuesta == 0)
            {
                cliente.PrsApePat = PrsApePat;
                cliente.PrsNroDoc = PrsNroDoc;
                cliente.PrsApePat = PrsApePat;
                cliente.PrsApeMat = PrsApeMat;
                cliente.PrsPriNom = PrsPriNom;
                cliente.PrsSegNom = PrsSegNom;
                cliente.PrsTerNom = PrsTerNom;
                cliente.TipDocCod = TipDocCod;
                cliente.PrsSex = PrsSex;
                cliente.PrsFecNac = PrsFecNac;
                cliente.Texto1 = Texto1;
                cliente.Texto2 = Texto2;
                cliente.Texto3 = Texto3;
                cliente.Texto4 = Texto4;
                cliente.Texto5 = Texto5;

                List<CarritoCoEntity> _carritoCo = new List<CarritoCoEntity>();
                foreach (var item in carritoCo)
                {
                    CarritoCoEntity carrito = new CarritoCoEntity();
                    carrito.PrsMaiCod = item.PrsMaiCod.ToString();
                    carrito.PrsMai = item.PrsMai;
                    carrito.PrsFlgMErr = item.PrsFlgMErr;
                    _carritoCo.Add(carrito);
                }

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

        public CuentaInfoEntity ObtenerClienteCuentas(string ctaPrsCod)
        {
            WsBonusConsultaClientesCuentas.wsselctaSoapPortClient ws = new WsBonusConsultaClientesCuentas.wsselctaSoapPortClient();
            WsBonusConsultaClientesCuentas.LisctaLisctaItem[] carritoCta;

            string msgError, PrsNomApe;
            short cantidadCta;

            int respuesta = ws.Execute(ctaPrsCod, out msgError, out cantidadCta, out carritoCta, out PrsNomApe);


            CuentaInfoEntity cuentaInfo = new CuentaInfoEntity();
            List<CuentaEntity> cuentaEntity = new List<CuentaEntity>();
            /*
               0: Éxito
               1: Código de persona nula
               2: Código de persona no existe
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
                    cuenta.PCtaAsoCod = item.PCtaAsoCod;
                    cuenta.PCtaAutCnj = item.PCtaAutCnj;
                    cuenta.PCtaTip = item.PCtaTip;
                    cuenta.PCtaTipNom = item.PCtaTipNom;
                    cuentaEntity.Add(cuenta);
                }
                cuentaInfo.CuentaEntities = cuentaEntity;
                cuentaInfo.PrsNomApe = PrsNomApe;
                cuentaInfo.CantidadCta = cantidadCta;
            }
            else
            {
                cuentaInfo.ResultCode = respuesta;
            }
            return cuentaInfo;
        }

        public TipoCuentaEntity ObtenerTipoCuenta(int cantidadCta, string ctaPrsCod, int ctaCod, string pCtaAsoCod, string pCtaTip, string pCtaAutCnj)
        {
            WsBonusTipoCuenta.wsmenafiSoapPortClient ws = new WsBonusTipoCuenta.wsmenafiSoapPortClient();
            WsBonusTipoCuenta.LismenafiLismenafiItem[] carritoMen;
            TipoCuentaEntity tipoCuenta = new TipoCuentaEntity();
            sbyte existePrs;
            string msgError;

            int respuesta = ws.Execute(Convert.ToInt16(cantidadCta), ctaPrsCod, Convert.ToInt16(ctaCod), pCtaAsoCod, pCtaTip, pCtaAutCnj,
                                        out msgError, out carritoMen, out existePrs);

            /*
                0: Éxito
                1: Código de titular nula
                2: Código de cuenta nula
                3: Código de asociado nula
                4: Tipo de cuenta nulo
                5: Flag de autorizacion nula
            */
            if (respuesta == 0)
            {
                
                List<CarritoMen> carritos = new List<CarritoMen>();
                 foreach (var item in carritoMen)
                {
                    CarritoMen _carritoMen = new CarritoMen();
                    _carritoMen.MenDes = item.mendes;
                    _carritoMen.MenSec = item.mensec;
                    carritos.Add(_carritoMen);
                }
                tipoCuenta.CarritoMen = carritos;
                tipoCuenta.ExistePrs = Convert.ToInt32(existePrs);
            }
            else
            {
                tipoCuenta.ResultCode = respuesta;
            }

            return tipoCuenta;
        }
    }
}
