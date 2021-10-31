using ContactHub.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactHub.WebAPI.Mappers
{
    public class ContactMapper
    {        
        public static Contact MapForCreate(Contact contact)
        {
            return new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PrimaryContactNumber = contact.PrimaryContactNumber,
                MobileNumber = contact.MobileNumber,
                HomeNumber = contact.HomeNumber,
                WorkNumber = contact.WorkNumber,
                emailAddress = contact.emailAddress,
                Address = contact.Address,
                Website = contact.Website,
                LastViewed = DateTime.Now,
                CreatedAt = DateTime.Now
            };
        }
    }
}
