namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using Amazon.DynamoDBv2.DocumentModel;
    using CommonLibary.CommonAwsDynamoDb;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using SocialCommunicationModels.CommonModels;
    using System;
    using System.Threading.Tasks;
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;

    /// <summary>
    /// Chat User Registration Class.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisterUserOutput"/>
    internal class ChatUserRegistration
    {
        internal async Task<OutputModel> UserRegistrationFromDynamoDb(InputModel inputModel)
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

        /// <summary>
        /// Chat User Registration Action BLL Member. User Registration to Chat.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model --> With Respective child Model of "ChatRegisterUserModel".</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisterUserOutput">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatRegisterModels.ChatRegisterUserModel"/>
        internal OutputModel UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel;

            ExecutionStatusEnums.ExecutionStatus validation;
            validation = UserNameValidation(inputModel?.chatRegisterUserModel?.UserName);


            if (validation != ExecutionStatusEnums.ExecutionStatus.ValidationSuccess)
            {
                return new OutputModel()
                {
                    ExecutionalStatus = validation,
                };
            }

            ChatUserRegistrationDL chatUserRegistrationDL = new ChatUserRegistrationDL();

            outputModel = chatUserRegistrationDL.UserRegistration(inputModel);

            if (outputModel?.responseModel?.ExecutionStatus == 1)
            {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success;
            }
            else
            {
                outputModel.ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed;
            }

            return outputModel;
        }

        private ExecutionStatusEnums.ExecutionStatus UserNameValidation(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return ExecutionStatusEnums.ExecutionStatus.UserDoesnotExist;
            }

            //if (Regex.IsMatch(userName, @"/^\S+$/"))
            //{
            //    return ExecutionStatusEnums.ExecutionStatus.UserNameDoesnotAllowSpaces;
            //}

            //if (Regex.IsMatch(userName, @"\|!#$%&/()=?»«@£§€{}.-;'<>_,"))
            //{
            //    return ExecutionStatusEnums.ExecutionStatus.UserNameDoesnotAllowSpecialSymbols;
            //}
            //
            // not allowd Spaces And symbols
            //if (Regex.IsMatch(userName, @"/^\S+$/|[!@$#%^&*()]"))
            //{
            //    return ExecutionStatusEnums.ExecutionStatus.UserNameDoesnotExist;
            //}

            return ExecutionStatusEnums.ExecutionStatus.ValidationSuccess;
        }
    }
}
