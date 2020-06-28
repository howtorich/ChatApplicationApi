namespace SocialCommunicationDA.SqlServerLogic.ChatLogic
{
    using CommonLibary.CommonDb;
    using CommonLibary.CommonModels;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using System.Data;
    using System.Data.SqlClient;

    public class GetUserFriendsColunmDataDL
    {
        public ResponseModel GetUserFriendsColunmData(InputModel inputModel)
        {
            ResponseModel response;

            SqlCommand command = SqlServerCommon.GetSpCommandByConnectToDb(SqlServerCommon.SqlServerDBs.DbAdmin, "usp_GetUserFriendsColunmData");

            command.AddParameter("@UserID", SqlDbType.Int, inputModel.addFriend.UserId.ToString());

            command.AddParameter("@UserFrinedsColData", SqlDbType.VarChar, null,2048, ParameterDirection.Output);

            command.AddCommonInputParams();

            command.ExecuteNonQuery();

            response = new ResponseModel();
            response.ResponseData = command.GetOutputParam("@UserFrinedsColData", string.Empty);

            command.GetCommonOutputParams(response);

            command.Connection.Close();

            return response;
        }
    }
}
