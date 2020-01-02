using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Simplerjiang.AspnetCoreEmailSender
{
    [DataContract]
    public class EmailSettings
    {
        [DataMember]
        public string MailServer { get; set; }
        [DataMember]
        public int MailPort { get; set; }
        [DataMember]
        public bool UseSSH { get; set; }
        [DataMember]
        public string SenderName { get; set; }
        [DataMember]
        public string Sender { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string ToNickName { get; set; }
    }
}
