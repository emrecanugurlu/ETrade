using ETradeAPI.Application.ViewModel;
using ETradeAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<ProductCreateViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(100)
                .MinimumLength(3)
                    .WithMessage("Lütfen ürün adını 3-100 karakter arasında giriniz.");
            RuleFor(product => product.Description)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen açıklama alanını boş geçmeyiniz.")
                .MaximumLength(500)
                .MinimumLength(6)
                    .WithMessage("Lütfen açıklama alanını 6-500 karakter arasında giriniz.");
            RuleFor(product => product.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stok bilgisi boş olamaz")
                .Must(s => s >= 0)
                    .WithMessage("Stok bilgisi negatif olamaz");
            RuleFor(product => product.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Fiyat bilgisi boş olamaz")
                .Must(s => s >= 0)
                    .WithMessage("Fiyat bilgisi negatif olamaz");
        }
    }
}
