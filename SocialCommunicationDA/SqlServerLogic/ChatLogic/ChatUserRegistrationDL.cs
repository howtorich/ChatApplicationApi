﻿namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.ChatRegisterModels;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Chat User Registration DLL.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisterUserOutput"/>
    public class ChatUserRegistrationDL
    {

        /// <summary>
        /// Chat User Registration Member with Db(Data Base) Call.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel">Chat Common Input Model</param>
        /// <returns cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisterUserOutput">Chat Common Output Model. With User Id and User Name.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.chatRegisterUserModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.ChatRegisterUserOutput"/>
        public OutputModel UserRegistration(InputModel inputModel)
        {
            OutputModel outputModel = null;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_ChatUserRegister_insert_Get");

            command.AddParameter("@UserName", SqlDbType.VarChar, inputModel.chatRegisterUserModel.UserName, 50);

            command.AddParameter("@UserID", SqlDbType.Int, null, ParameterDirection.Output);

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            outputModel = new OutputModel();
            outputModel.ChatRegisterUserOutput = new ChatRegisterUserModel()
            {
                UserId = command.GetOutputParam("@UserID", 0),
                UserName = command.GetOutputParam("@UserName", string.Empty)
            };

            outputModel.responseModel = new ResponseModel();
            command.GetCommonOutputParams(outputModel.responseModel);

            command.Connection.Close();

            return outputModel;
        }
    }
}
