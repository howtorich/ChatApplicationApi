namespace SocialCommunicationsBL.BusinessLogic.ChatLogic
{
    using CommonLibary.CommonModels;
    using SocialCommunicationDA.SqlServerLogic.ChatLogic;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using System;
    using System.Linq;

    /// <summary>
    /// Add friend to Chat user.
    /// </summary>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.addFriend"/>
    /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.responseModel"/>
    /// <seealso cref="SocialCommunicationModels.CommonModels.ExecutionStatusEnums.ExecutionalStatusMessage"/>
    internal class AddFriend
    {
        /// <summary>
        /// Adding friend to User.
        /// </summary>
        /// <param name="inputModel" cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel.addFriend">Chat Common Input Model.</param>
        /// <returns cref="SocialCommunicationModels.CommonModels.ExecutionStatusEnums">Chat Common Output Model.</returns>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel.responseModel"/>
        internal OutputModel FriendAdding(InputModel inputModel)
        {
            ResponseModel addfriendResponse;

            Validation(inputModel, out ExecutionStatusEnums.ExecutionStatus status);

            if (status != ExecutionStatusEnums.ExecutionStatus.Success)
            {
                return new OutputModel()
                {
                    ExecutionalStatus = status,
                };
            }

            var userExistsOrNotInFrndsTableDL = new UserExistsOrNotInFrndsTableDL();

            ResponseModel UserExistsOrNotRepsonse = userExistsOrNotInFrndsTableDL.UserExistsOrNotInFrndsTable(inputModel);

            if (UserExistsOrNotRepsonse?.ExecutionStatus != 1)
            {
                return new OutputModel()
                {
                    responseModel = UserExistsOrNotRepsonse,
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.UserDoesnotExist,
                };
            }

            AddFriendDL addFriendDL = new AddFriendDL();

            if (UserExistsOrNotRepsonse?.ResponseData == false)
            {
                inputModel.addFriend.AddingUserIds = inputModel.addFriend.AddingFriendUserId.ToString();
                addfriendResponse = addFriendDL.AddFriend(inputModel, false);
            }
            else
            {
                var getUserFriendsColunmDataDL = new GetUserFriendsColunmDataDL();
                ResponseModel userFriendsColunmData = getUserFriendsColunmDataDL.GetUserFriendsColunmData(inputModel);

                if (userFriendsColunmData.ExecutionStatus != 1)
                {
                    return new OutputModel()
                    {
                        responseModel = userFriendsColunmData,
                        ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed,
                    };
                }

                if (string.IsNullOrWhiteSpace(userFriendsColunmData.ResponseData))
                {
                    inputModel.addFriend.AddingUserIds = inputModel.addFriend.AddingFriendUserId.ToString();

                    addfriendResponse = addFriendDL.AddFriend(inputModel, true);

                    // return
                }
                else
                {
                    if (((string)userFriendsColunmData.ResponseData).Split(",").Contains(inputModel.addFriend.AddingFriendUserId.ToString()))
                    {
                        return new OutputModel()
                        {
                            responseModel = userFriendsColunmData,
                            ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.AddingExistsUser,
                        };
                    }

                    inputModel.addFriend.AddingUserIds = userFriendsColunmData.ResponseData + "," + inputModel.addFriend.AddingFriendUserId;

                    addfriendResponse = addFriendDL.AddFriend(inputModel, true);
                }
            }

            if (addfriendResponse?.ExecutionStatus == 1)
            {
                return new OutputModel()
                {
                    responseModel = addfriendResponse,
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Success,
                };
            }

            return new OutputModel()
            {
                responseModel = addfriendResponse,
                ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.Failed,
            };
        }

        private void Validation(InputModel inputModel, out ExecutionStatusEnums.ExecutionStatus status)
        {
            if (inputModel?.addFriend.UserId == 0)
            {
                status =  ExecutionStatusEnums.ExecutionStatus.ProvideUserId;
            }
            else if (inputModel?.addFriend.AddingFriendUserId == 0)
            {
                status = ExecutionStatusEnums.ExecutionStatus.ProvideFriendUserId;
            }
            else if (inputModel.addFriend.UserId.Equals(inputModel.addFriend.AddingFriendUserId))
            {
                status = ExecutionStatusEnums.ExecutionStatus.UserCannotAddThemSelves;
            }
            else
            {
                status = ExecutionStatusEnums.ExecutionStatus.Success;
            }

        }
    }
}
