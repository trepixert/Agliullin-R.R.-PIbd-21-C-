﻿using System;
using System.Runtime.Serialization;

namespace ConfectioneryShopModelServiceDAL.BindingModel {
    [DataContract]
    public class ReportBindingModel {
        [DataMember] public string FileName { get; set; }
        [DataMember] public DateTime? DateFrom { get; set; }
        [DataMember] public DateTime? DateTo { get; set; }
    }
}