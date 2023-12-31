﻿using FluentValidation;
using PhoneNumbers;

namespace Domain.Commands.Validations
{
    public class CustomerValidation<T> : AbstractValidator<T> where T : BaseCustomerCommand
    {
        protected void ValidateId()
        {
            RuleFor(s => s.Id).NotEmpty();
        }

        protected void ValidateFirstname()
        {
            RuleFor(c => c.Firstname)
                .NotEmpty().WithMessage("Please ensure you have entered the Firstname")
                .Length(4, 150).WithMessage("The Firstname must have between 4 and 150 characters");
        }

        protected void ValidateLastname()
        {
            RuleFor(c => c.Lastname)
                .NotEmpty().WithMessage("Please ensure you have entered the Lastname")
                .Length(4, 150).WithMessage("The Lastname must have between 4 and 150 characters");
        }

        public void ValidatePhoneNumber()
        {
            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Please ensure you have entered a phone number")
                .Must(BeValidMobileNumber).WithMessage("Invalid mobile number");
        }

        public bool BeValidMobileNumber(string phoneNumber)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber parsedPhoneNumber = phoneNumberUtil.Parse(phoneNumber, null);

            string countryCode = phoneNumberUtil.GetRegionCodeForNumber(parsedPhoneNumber);
            return phoneNumberUtil.IsValidNumberForRegion(parsedPhoneNumber, countryCode) &&
                   phoneNumberUtil.GetNumberType(parsedPhoneNumber) == PhoneNumberType.MOBILE;
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress().WithMessage("Invalid email address.");
        }

    }
}
