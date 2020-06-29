namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;

    /// <summary>
    /// Get Chat user Application Details Class.
    /// </summary>
    /// <seealso cref="OutputModel.userApplicationDetailsModel"/>
    /// <seealso cref="InputModel.chatRegisterUserModel"/>
    internal class GetChatUserApplicationDetails
    {
        /// <summary>
        /// Get Chat user Application Details Method.
        /// </summary>
        /// <param name="inputModel" cref="InputModel.chatRegisterUserModel">Chat Common input Model.</param>
        /// <returns cref="OutputModel.userApplicationDetailsModel">Chat Common Output Model.</returns>
        /// <seealso cref="OutputModel.responseModel"/>
        internal OutputModel GetChatUserAppDetails(InputModel inputModel)
        {
            OutputModel outputModel;

            var getChatUserApplicationDetailsDL = new GetChatUserApplicationDetailsDL();

            outputModel = getChatUserApplicationDetailsDL.GetChatUserApplicationDetails(inputModel);

            outputModel.ExecutionalStatus = outputModel?.responseModel?.ExecutionStatus == 1 ? 
                ExecutionStatusEnums.ExecutionStatus.Success : ExecutionStatusEnums.ExecutionStatus.Failed;

            return outputModel;
        }
    }
}
