using System;
using Moneybird.Net.Endpoints.Contacts.Models;
using Moneybird.Net.Extensions;
using Xunit;

namespace Moneybird.Net.Tests.Extensions
{
    public class ContactsExtensionsTest
    {
        [Fact]
        public void GetFilterString_FromContactFilterOptions_CreatedOnly_Returns_CorrectString()
        {
            var createdDate = DateTime.UtcNow;
            
            var options = new ContactFilterOptions
            {
                CreatedAfter = createdDate
            };

            var expectedString = $"filter=created_after:{createdDate:O}";
            var actualString = options.GetFilterString();
            
            Assert.Equal(expectedString, actualString);
        }
        
        [Fact]
        public void GetFilterString_FromContactFilterOptions_UpdatedOnly_Returns_CorrectString()
        {
            var updatedDate = DateTime.UtcNow;
            
            var options = new ContactFilterOptions
            {
                UpdatedAfter = updatedDate
            };

            var expectedString = $"filter=updated_after:{updatedDate:O}";
            var actualString = options.GetFilterString();
            
            Assert.Equal(expectedString, actualString);
        }
        
        [Fact]
        public void GetFilterString_FromContactFilterOptions_FirstnameOnly_Returns_CorrectString()
        {
            const string firstName = "Money";
            
            var options = new ContactFilterOptions
            {
                FirstName = firstName
            };

            var expectedString = $"filter=first_name:{firstName}";
            var actualString = options.GetFilterString();
            
            Assert.Equal(expectedString, actualString);
        }
        
        [Fact]
        public void GetFilterString_FromContactFilterOptions_LastnameOnly_Returns_CorrectString()
        {
            const string lastName = "Bird";
            
            var options = new ContactFilterOptions
            {
                LastName = lastName
            };

            var expectedString = $"filter=last_name:{lastName}";
            var actualString = options.GetFilterString();
            
            Assert.Equal(expectedString, actualString);
        }
        
        [Fact]
        public void GetFilterString_FromContactFilterOptions_All_Returns_CorrectString()
        {
            var createdDate = DateTime.UtcNow - TimeSpan.FromDays(1);
            var updatedDate = DateTime.UtcNow;
            const string firstName = "Money";
            const string lastName = "Bird";
            
            var options = new ContactFilterOptions
            {
                CreatedAfter = createdDate,
                UpdatedAfter = updatedDate,
                FirstName = firstName,
                LastName = lastName
            };

            var expectedString = $"filter=created_after:{createdDate:O}," +
                                 $"updated_after:{updatedDate:O}," +
                                 $"first_name:{firstName}," +
                                 $"last_name:{lastName}";
            
            var actualString = options.GetFilterString();
            
            Assert.Equal(expectedString, actualString);
        }
    }
}