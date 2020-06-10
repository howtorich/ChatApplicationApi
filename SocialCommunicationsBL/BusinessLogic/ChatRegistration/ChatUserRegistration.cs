namespace SocialCommunicationsBL.BusinessLogic.ChatRegistration
{
    using Amazon.DynamoDBv2.DocumentModel;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationModels.CommonUsage;
    using System;
    using System.Threading.Tasks;

    public class ChatUserRegistration
    {
        public async Task<OutputModel> UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel = null;
            Document RegisteredUser;

            Int64 UserGuid = Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            AwsDynamoDbCommon awsDynamoDbCommon = new AwsDynamoDbCommon();

            RegisteredUser = await awsDynamoDbCommon.GetItemOnPrimaryKeyString(inputModel.chatRegisterUserModel.UserName,
                AwsDynamoDbCommon.AwsDynamoDbTables.tbl_ChatRegistration_Users.ToString());

            if (RegisteredUser == null)
            {
                RegisteredUser = new Document();

                RegisteredUser["UserName"] = inputModel.chatRegisterUserModel.UserName;
                RegisteredUser["UserId"] = UserGuid;

                await awsDynamoDbCommon.PutItemInTable(RegisteredUser, AwsDynamoDbCommon.AwsDynamoDbTables.tbl_ChatRegistration_Users.ToString());
            }

            outputModel = new OutputModel()
            {
                ChatRegisterUserOutput = new ChatRegisterUserModel()
                {
                    UserName = RegisteredUser["UserName"],
                    UserId = RegisteredUser["UserId"].AsLong(),
                },

                ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success,
            };


            return outputModel;
        }
    }
}
