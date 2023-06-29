using FluentValidation;
using MyMvcProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcProject.Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //RuleFor(message => message.ReceiverMail).NotEmpty().WithMessage("Receiver mail cannot be blank!");
            //RuleFor(message => message.SenderMail).NotEmpty().WithMessage("Sender mail cannot be blank!");
            //RuleFor(message => message.Subject).NotEmpty().WithMessage("Subject cannot be blank!")
            //                                   .MinimumLength(3).WithMessage("Min 3 character!")
            //                                   .MaximumLength(50).WithMessage("Max 100 character!");
            //RuleFor(message => message.MessageContent).NotEmpty().WithMessage("Content cannot be blank!");
        }
    }
}
