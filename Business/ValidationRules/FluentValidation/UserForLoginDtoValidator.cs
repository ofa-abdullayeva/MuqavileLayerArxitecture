using Entities.DTOs.UserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            // Username boş olmamalı və minimum 4 simvol uzunluqda olmalı
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("İstifadəçi adı boş ola bilməz.")
                .MinimumLength(4).WithMessage("İstifadəçi adı ən az 4 simvol olmalıdır.");

            // Password boş olmamalı və minimum 6 simvol uzunluqda olmalı
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Şifrə boş ola bilməz.")
                .MinimumLength(6).WithMessage("Şifrə ən az 6 simvol olmalıdır.");
        }

        private bool StartWithA(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;

            return userName.StartsWith("A");
        }
    }
}
