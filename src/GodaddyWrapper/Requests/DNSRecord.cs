﻿using GodaddyWrapper.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DNSRecord : DNSRecordCreateType
    {
        [Required]
        [DNSRecordType]
        public string Type { get; set; }
    }
}
