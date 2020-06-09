namespace SocialCommunicationsBL.BusinessLogic.ChatRegistration
{
    using Amazon.DynamoDBv2.DocumentModel;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationModels.CommonUsage;
    using System.Threading.Tasks;

    public class ChatUserRegistration
    {
        public async Task<OutputModel> UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel;
            Document RegisteredUser;

            AwsDynamoDbCommon awsDynamoDbCommon = new AwsDynamoDbCommon();

            RegisteredUser = await awsDynamoDbCommon.GetItemOnPrimaryKeyString(inputModel.chatRegisterUserModel.UserName,
                AwsDynamoDbCommon.AwsDynamoDbTables.tbl_ChatRegistration_Users.ToString());

            if (RegisteredUser == null)
            {
                outputModel = new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed,
                };
            }
            else
            {
                outputModel = new OutputModel()
                {
                    ChatRegisterUserOutput = new ChatRegisterUserModel()
                    {
                        UserName = RegisteredUser["UserName"],
                        UserId = RegisteredUser["UserId"].AsInt(),
                    },

                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success,
                };
            }

            return outputModel;
        }
    }
}
