﻿using Students.Model.Interfaces;

namespace Students.Model
{
    public class EmailDomainValidator : IEmailDomainValidator
    {
        private const string domainName = "@vbjnet.hu";

        public bool ValidateStudent(Student student)
        {
            return student.EmailAddress.EndsWith(domainName);
        }
    }
}
