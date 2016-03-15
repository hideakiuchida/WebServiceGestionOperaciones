﻿using Bonus.BusinessServices.Interfaces;
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
        public bool ExisteCliente(short tipodoccod, string prsnrodoc)
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
                return true;
            }
            return false;
        }

        public ClienteEntity ObtenerCliente(string PrsCod)
        {
           WsBonusObtenerDatosClientes.wsdevdatcoSoapPortClient ws = new WsBonusObtenerDatosClientes.wsdevdatcoSoapPortClient();

           string msgError = "";
           ClienteEntity cliente = new ClienteEntity();
           WsBonusObtenerDatosClientes.ListelListelItem[] carritoTe;
           WsBonusObtenerDatosClientes.LismaiLismaiItem[] carritoCo;
           WsBonusObtenerDatosClientes.LishijLishijItem[] carritoHij;

           string PrsApePat, PrsApeMat, PrsPriNom, PrsSegNom, PrsTerNom, PrsNroDoc, PrsSex, Texto1, Texto2, Texto3, Texto4, Texto5, Direccion;
           short TipDocCod;
           DateTime PrsFecNac;
           string Referencia, DptoCod, ProvCod, DistCod, FlgTieVeh, FlgTieHij;

           int respuesta = ws.Execute(PrsCod, out msgError, out PrsApePat, out PrsApeMat, out PrsPriNom, out PrsSegNom, out PrsTerNom,
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

                cliente.PrsApePat = PrsApePat;
                cliente.PrsApeMat = PrsApeMat;
                cliente.PrsPriNom = PrsPriNom;
                cliente.PrsSegNom = PrsSegNom;
                cliente.PrsTerNom = PrsTerNom;
                cliente.TipDocCod = TipDocCod;
                cliente.PrsFecNac = PrsNroDoc;
                cliente.PrsSex = PrsSex;
                cliente.PrsFecNac = PrsFecNac.ToString();
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
            return cliente;
        }
    }
}
