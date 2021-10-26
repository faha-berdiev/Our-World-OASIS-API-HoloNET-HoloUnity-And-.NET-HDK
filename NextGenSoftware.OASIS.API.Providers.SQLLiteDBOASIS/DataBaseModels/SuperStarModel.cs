using System;
using System.ComponentModel.DataAnnotations.Schema;
using NextGenSoftware.OASIS.API.Core.Interfaces.STAR;
using NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.Prototypes;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.DataBaseModels{

    [Table("SuperStar")]
    public class SuperStarModel : StarModelBase{

        public SuperStarModel():base(){}
        public SuperStarModel(ISuperStar source):base(){
            if(source.Id == Guid.Empty){
                source.Id = Guid.NewGuid();
            }

            this.StarId = source.Id.ToString();
            this.HolonId = source.ParentHolonId.ToString();

            this.Luminosity = source.Luminosity;
            this.StarType = source.StarType;
            this.StarClassification = source.StarClassification;
            this.StarBinaryType = source.StarBinaryType;
        }

        public ISuperStar GetSuperStar(){

            SuperStar item=new SuperStar();

            item.Id = Guid.Parse(this.StarId);
            item.ParentHolonId = Guid.Parse(this.HolonId);
            
            item.Luminosity = this.Luminosity;
            item.StarType = this.StarType;
            item.StarClassification = this.StarClassification;
            item.StarBinaryType = this.StarBinaryType;

            return(item);
        }
    }
}