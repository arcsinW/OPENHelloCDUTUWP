using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCDUT.Core.Model
{
    public class LoginResponse : ResponseBase
    { 
        [JsonProperty(PropertyName = "user_lib_status")]
        public string UserLibStatus { get; set; }


        [JsonProperty(PropertyName = "user_campus_status")]
        public string UserCampusStatus { get; set; }


        [JsonProperty(PropertyName = "user_aao_status")]
        public string UserAaoStatus { get; set; }


        [JsonProperty(PropertyName = "user_stu_id")]
        public string UserStuId { get; set; }


        [JsonProperty(PropertyName = "user_email_status")]
        public string UserEmailStatus { get; set; }


        [JsonProperty(PropertyName = "user_gender")]
        public string UserGender { get; set; }


        [JsonProperty(PropertyName = "user_motto")]
        public string UserMotto { get; set; }


        [JsonProperty(PropertyName = "user_love_status")]
        public string UserLoveStatus { get; set; }


        [JsonProperty(PropertyName = "user_nick_name")]
        public string UserNickName { get; set; }


        [JsonProperty(PropertyName = "user_real_name")]
        public string UserRealName { get; set; }


        [JsonProperty(PropertyName = "user_birthdate")]
        public string UserBirthdate { get; set; }


        [JsonProperty(PropertyName = "user_institute")]
        public string UserInstitute { get; set; }

        [JsonProperty(PropertyName = "user_major")]
        public string UserMajor { get; set; }


        [JsonProperty(PropertyName = "user_class_id")]
        public string UserClassId { get; set; }


        [JsonProperty(PropertyName = "user_entrance_year")]
        public string UserEntranceYear { get; set; }


        [JsonProperty(PropertyName = "user_avatar_url")]
        public string UserAvatarUrl { get; set; }


        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }


        [JsonProperty(PropertyName = "user_love_status_permission")]
        public string UserLoveStatusPermission { get; set; }


        [JsonProperty(PropertyName = "user_sex_orientation_permission")]
        public string UserSexOrientationPermission { get; set; }


        [JsonProperty(PropertyName = "user_real_name_permission")]
        public string UserRealNamePermission { get; set; }


        [JsonProperty(PropertyName = "user_birthdate_permission")]
        public string UserBirthdatePermission { get; set; }


        [JsonProperty(PropertyName = "user_institute_id_permission")]
        public string UserInstituteIdPermission { get; set; }


        [JsonProperty(PropertyName = "user_stu_num_permission")]
        public string UserStuNumPermission { get; set; }


        [JsonProperty(PropertyName = "user_major_permission")]
        public string UserMajorPermission { get; set; }


        [JsonProperty(PropertyName = "user_class_id_permission")]
        public string UserClassIdPermission { get; set; }


        [JsonProperty(PropertyName = "user_entrance_year_permission")]
        public string UserEntranceYearPermission { get; set; }


        [JsonProperty(PropertyName = "user_schedule_permission")]
        public string UserSchedulePermission { get; set; }


        [JsonProperty(PropertyName = "user_group_schedule_permission")]
        public string UserGroupSchedulePermission { get; set; }


        [JsonProperty(PropertyName = "user_password_hash")]
        public string UserPasswordHash { get; set; }


        [JsonProperty(PropertyName = "user_chat_token")]
        public string UserChatToken { get; set; }


        [JsonProperty(PropertyName = "user_login_token")]
        public string UserLoginToken { get; set; }
    }
}
