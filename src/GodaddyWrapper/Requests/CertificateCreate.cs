﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CertificateCreate
    {
        public string Csr { get; set; }
        public string ProductType { get; set; }
        public int Period { get; set; }
        public CertificateContact Contact { get; set; }
        public string CommonName { get; set; }
        public List<string> SubjectAlternativeNames { get; set; }
        public string SlotSize { get; set; }
        public string CallbackUrl { get; set; }
        public string RootType { get; set; }
        public bool IntelVPro { get; set; }
        public CertificateOrganizationCreate Organization { get; set; }


    }
}
