using FluentValidation.Results;

namespace AutoRepairShop.Api.Validators.Base
{
    public class VisualizationError
    {
        public VisualizationError()
        {

        }

        public VisualizationError(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorsMessage = new List<string>
            {
                errorMessage
            };
        }

        public string PropertyName { get; set; }
        public List<string> ErrorsMessage { get; set; }

        public static IEnumerable<VisualizationError> ToList(IEnumerable<ValidationFailure> validationFailures)
        {
            List<VisualizationError> formatedErrors = new List<VisualizationError>();
            foreach (var validationFailure in validationFailures)
            {
                var error = formatedErrors.FirstOrDefault(a => a.PropertyName == validationFailure.PropertyName);
                if (error != null)
                    error.ErrorsMessage.Add(validationFailure.ErrorMessage);
                else
                    formatedErrors.Add(new VisualizationError(validationFailure.PropertyName, validationFailure.ErrorMessage));
            }

            return formatedErrors;
        }

    }
}
