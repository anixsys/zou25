﻿using CoreAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Models
{
    public class AdmissionDocument: Auditable, IAuditable
        {
            public int id { get; set; }

            public int ApplicantTypeId { get; set; }

            public int ProgrammetypeId { get; set; }

            public int DocumentId { get; set; }

            public string? Status { get; set; }

            public Document document { get; set; }

            public ProgrammeType programmeType { get; set; }

            public Applicanttype applicanttype { get; set; }

           public List<ApplicantDocument> applicantdocuments{ get; set; }
        }
    }
