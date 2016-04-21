using System.Collections.Generic;

namespace Bonus.BusinessEntities.DTO
{
    public class CuentaInfoEntity
    {
        public IEnumerable<CuentaEntity> CuentaEntities { get; set; }
        public short PrsTipdCod { get; set; }
        public string PrsNroDoc { get; set; }
        public string PrsNomApe { get; set; }
        //This field ResultCode exist for manage Errors
        public int? ResultCode { get; set; }
    }
}
