using Bonus.BusinessEntities.DTO;
using System;
using System.Collections.Generic;

namespace Bonus.BusinessServices.Interfaces
{
    public interface IClienteServices
    {
        string ExisteCliente(short tipodoccod, string prsnrodoc);
        ClienteEntity ObtenerCliente(string prsCod);
        MovFideEntity ObtenerMovFidelizacion(string ctaPrsCod, int ctaCod);
        CuentaInfoEntity ObtenerCuentas(string ctaPrsCod);
        CuentaInfoEntity ObtenerClienteCuentas(string ctaPrsCod);
        TipoCuentaEntity ObtenerTipoCuenta(int cantidadCta, string ctaPrsCod, int ctaCod, string pCtaAsoCod, string pCtaTip, string pCtaAutCnj);
    }
}
