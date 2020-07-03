namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatModels.UserApplicationDetailsModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Get Chat user Application Details DLL.
    /// </summary>
    /// <seealso cref="OutputModel.userApplicationDetailsModel"/>
    /// <seealso cref="InputModel.chatRegisterUserModel"/>
    public class GetChatUserApplicationDetailsDL
    {
        /// <summary>
        /// Get Chat user Application Details DLL Method.
        /// </summary>
        /// <param name="inputModel" cref="InputModel.chatRegisterUserModel">Chat Common input Model.</param>
        /// <returns cref="OutputModel.userApplicationDetailsModel">Chat Common Output Model.</returns>
        /// <seealso cref="OutputModel.responseModel"/>
        public OutputModel GetChatUserApplicationDetails(InputModel inputModel)
        {
            OutputModel outputModel;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatUsersApplicationDetails_Get");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.chatRegisterUserModel.UserId.ToString());

            command.AddCommonInputParams();

            using (IDataReader reader = command.ExecuteReader())
            {
                outputModel = new OutputModel();

                if (reader.Read())
                {
                    outputModel.userApplicationDetailsModel = new UserApplicationDetailsModel()
                    {
                        UserName = reader.GetDbValue("UserName", string.Empty)
                    };
                }
            }

            outputModel.responseModel = new ResponseModel();
            command.GetCommonOutputParams(outputModel.responseModel);

            command.ConnectionDispose();

            return outputModel;
        }
    }
}
