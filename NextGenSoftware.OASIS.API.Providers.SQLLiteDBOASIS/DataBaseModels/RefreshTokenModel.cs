using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NextGenSoftware.OASIS.API.Core.Objects;
using NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.Prototypes;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.DataBaseModels{

    [Table("RefreshTokens")]
    public class RefreshTokenModel {

        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        public string AvatarId { get; set; }

        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired {set; get;}
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive {set; get;}

        public RefreshTokenModel(){}
        public RefreshTokenModel(RefreshToken source){

            this.Id=source.Id;
            this.Token=source.Token;
            this.Expires=source.Expires;
            this.IsExpired=source.IsExpired;
            this.Created=source.Created;
            this.CreatedByIp=source.CreatedByIp;
            this.Revoked=source.Revoked;
            this.RevokedByIp=source.RevokedByIp;
            this.ReplacedByToken=source.ReplacedByToken;
            this.IsActive=source.IsActive;
        }

        public RefreshToken GetRefreshToken(){

            RefreshToken item=new RefreshToken();

            item.Id=this.Id;
            item.Token=this.Token;
            item.Expires=this.Expires;
            item.Created=this.Created;
            item.CreatedByIp=this.CreatedByIp;
            item.Revoked=this.Revoked;
            item.RevokedByIp=this.RevokedByIp;
            item.ReplacedByToken=this.ReplacedByToken;

            return(item);
        }
    }
}