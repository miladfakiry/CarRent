using CarRent.Car.Api.v1;
using CarRent.Car.Domain;
using CarRent.Customer.Api.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.Tests.Customer
{
    public class CustomerDomainUnitTests
    {
        [Fact]
        public void CustomerConstructor_CreateCustomerBasedOnDto()
        {
            //Arrange
            var id = new Guid();
            var street = "Hauptstrasse 5";
            var city = "9000 St. Gallen";
            var firstName = "Hans";
            var lastName = "Muster";

            var expectedCustomer = new CarRent.Customer.Domain.Customer(id)
            {
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            var customerDto = new CustomerResponseDto()
            {
                Id = id,
                Street = street,
                City = city,
                FirstName = firstName,
                LastName = lastName
            };

            //Act
            var createdCustomer = new CarRent.Customer.Domain.Customer(customerDto);

            //Assert
            Assert.Equal(expectedCustomer, createdCustomer);
            Assert.Equal(expectedCustomer.Street, createdCustomer.Street);
            Assert.Equal(expectedCustomer.FirstName, createdCustomer.FirstName);
            Assert.Equal(expectedCustomer.LastName, createdCustomer.LastName);
            Assert.Equal(expectedCustomer.City, createdCustomer.City);
        }
    }
}
