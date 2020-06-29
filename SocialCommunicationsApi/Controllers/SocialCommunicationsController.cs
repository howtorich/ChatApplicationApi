namespace SocialCommunicationsApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SocialCommunicationModels.ChatInputAndOutputModels;
    using SocialCommunicationModels.CommonModels;
    using SocialCommunicationsApi.Validation;
    using SocialCommunicationsBL.BusinessLogic;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Chat Application Api Controller, This is an only one end point for this (Chat Application Api) --> Action Differed on Api Action Enums, Application Controller Name "SocialCommunication".
    /// Has an Api Auth Key Validation.
    /// </summary>
    [ApiController]
    [Route("SocialCommunication")]
    [ApiKeyAuth]
    public class SocialCommunicationsController : ControllerBase
    {
        /// <summary>
        /// This is the end Point of the "SocialCommunication" Controller.
        /// </summary>
        /// <param name="InputModel">Chat Common Input Model.</param>
        /// <returns>Chat Common Output Model.</returns>
        /// <permission cref="SocialCommunicationsApi.Validation.ApiKeyAuth">Auth Key Validation Required.</permission>
        /// <remarks>Input Cannot be null and any Exception can return the Common output Model with Error, StackTrace, InnerException details.</remarks>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.InputModel"/>
        /// <seealso cref="SocialCommunicationModels.ChatInputAndOutputModels.OutputModel"/>
        /// <seealso cref="CommonLibary.CommonModels.ResponseModel"/>
        [Route("ChatUserRegistration")]
        [HttpPost]
        public async Task<IActionResult> ChatUserRegistration_Main(InputModel InputModel)
        {
            OutputModel outputModel = null;
            try
            {
                if (InputModel == null)
                {
                    outputModel = new OutputModel()
                    {
                        ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.NoContent,
                    };

                    return BadRequest(outputModel);
                }

                ChatActionFlowBl chatActionFlowBl = new ChatActionFlowBl();

                outputModel = await chatActionFlowBl.ChatApiActionFlow(InputModel);
            }
            catch (Exception ex)
            {
                outputModel = new OutputModel()
                {
                    ExecutionalStatus = ExecutionStatusEnums.ExecutionStatus.ExecutionError,
                    ErrorMessage = ex?.Message,
                    InnerException = ex?.InnerException?.Message,
                    StackTrace = ex?.StackTrace,
                };
            }

            return Ok(outputModel);
        }
    }
}