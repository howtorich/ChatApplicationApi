namespace SocialCommunicationModels.CommonModels
{
    public class ExecutionStatusEnums
    {
        public enum ExecutionStatus
        {
            NoContent = 1001,

            ExecutionError = 1002,

            Success = 1003,

            Failed = 1004,

            ValidationSuccess = 1005,

            ValidationFailed = 1006,



            UserNameDoesnotExist = 101,

            UserNameDoesnotAllowSpaces = 102,

            UserNameDoesnotAllowSpecialSymbols = 103,

            

        }

        public ExecutionStatus ExecutionalStatus { private get; set; }

        public string ExecutionalStatusMessage
        {
            get
            {
                return ExecutionStatusMessage(ExecutionalStatus);
            }
        }

        public string ErrorMessage;

        public string InnerException;

        public string StackTrace;

        private string ExecutionStatusMessage(ExecutionStatus ExecutionEnum)
        {
            string ExecutionalMessage;
            switch (ExecutionEnum)
            {
                case ExecutionStatus.NoContent:
                    ExecutionalMessage = "No Content";
                    break;
                case ExecutionStatus.ExecutionError:
                    ExecutionalMessage = "Executional Error";
                    break;
                case ExecutionStatus.Success:
                    ExecutionalMessage = "Success";
                    break;
                case ExecutionStatus.Failed:
                    ExecutionalMessage = "Failed";
                    break;
                case ExecutionStatus.ValidationSuccess:
                    ExecutionalMessage = "Validation Success";
                    break;
                case ExecutionStatus.ValidationFailed:
                    ExecutionalMessage = "Validation Failed";
                    break;


                case ExecutionStatus.UserNameDoesnotExist:
                    ExecutionalMessage = "Username does not exist.";
                    break;
                case ExecutionStatus.UserNameDoesnotAllowSpaces:
                    ExecutionalMessage = "Username does not allow Spaces.";
                    break;
                case ExecutionStatus.UserNameDoesnotAllowSpecialSymbols:
                    ExecutionalMessage = "Username does not allow Special Symbols.";
                    break;
                default:
                    ExecutionalMessage = "--- Somting went worng! ---";
                    break;
            }

            return ExecutionalMessage;
        }
    }
}
