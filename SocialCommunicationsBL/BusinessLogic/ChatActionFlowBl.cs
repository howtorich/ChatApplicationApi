namespace SocialCommunicationsBL.BusinessLogic
{
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationsBL.BusinessLogic.ChatRegistration;
    using System.Threading.Tasks;

    public class ChatActionFlowBl
    {
        public async Task<OutputModel> ChatApiActionFlow(InputModel inputModel)
        {
            OutputModel outputModel = null;

            if (inputModel?.ApiAction == null)
            {
                outputModel = new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.NoContent,
                };
            }

            switch (inputModel.ApiAction)
            {
                case ChatApiActionEnums.ChatApiActions.Registration:
                    ChatUserRegistration chatUserRegistration = new ChatUserRegistration();

                    outputModel = await chatUserRegistration.UserRegistration(inputModel);
                    break;
                case ChatApiActionEnums.ChatApiActions.GetUsersList:
                    break;
                default:
                    break;
            }

            return outputModel;
        }
    }
}
