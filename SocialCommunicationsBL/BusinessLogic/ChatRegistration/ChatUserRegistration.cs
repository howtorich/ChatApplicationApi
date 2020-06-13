namespace SocialCommunicationsBL.BusinessLogic.ChatRegistration
{
    using Amazon.DynamoDBv2.DocumentModel;
    using CommonLibary.CommonAwsDynamoDb;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System;
    using System.Threading.Tasks;
    using SocialCommunicationDA.SqlServerLogic.ChatDataLayer;

    public class ChatUserRegistration
    {
        public ChatUserRegistration()
        {

        }
        public async Task<OutputModel> UserRegistrationFromDynamoDb(InputModel inputModel)
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

        public OutputModel UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel;

            ChatUserRegistrationDL chatUserRegistrationDL = new ChatUserRegistrationDL();

            outputModel = chatUserRegistrationDL.UserRegistration(inputModel);

            if (outputModel?.responseModel?.ExecutionStatus == 1) {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success;
            }

            return outputModel;
        }
    }
}
