namespace SocialCommunicationModels.ChatInputAndOutputModels
{
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;

    public class OutputModel : ExecutionStatusEnums
    {
        public ChatRegisterUserModel ChatRegisterUserOutput;

        public ResponseModel responseModel;
    }
}
