using FluentValidation;


namespace SimpleWinForm
{
    class JsonDataClassValidator : AbstractValidator<JsonDataClass>
    {
        public JsonDataClassValidator()
        {
            RuleFor(jsonDataClass => jsonDataClass.FullName).NotEmpty();
            RuleFor(jsonDataClass => jsonDataClass.CityName).NotEmpty();
            RuleFor(jsonDataClass => jsonDataClass.PhoneNumber).NotEmpty();
            //Use this one if you want to prevent extensions
            //RuleFor(JsonDataClass => JsonDataClass.PhoneNumber).Matches(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");

            //Use this one to allow extensions
            RuleFor(jsonDataClass => jsonDataClass.PhoneNumber).Matches(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}");

            RuleFor(jsonDataClass => jsonDataClass.EmailAddress).NotEmpty();
            RuleFor(jsonDataClass => jsonDataClass.EmailAddress).EmailAddress();

           
        }
    }
}