
// App: Organization.Client
// Developer: Pouya Faridi
// Version: 1.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Kama.Organization.Core.Model;

namespace Kama.Organization.ApiClient.Interface
{

	public interface IOrganizationClient : Library.ApiClient.IClient
	{
		string Host{get;}
	}

	public interface IOrganizationHostInfo:Library.ApiClient.IHostInfo
	{
	}

	public interface IService
	{
	}

		 public interface IAnnouncementService: IService
		 {
						 				Task<AppCore.Result<model.Announcement>> Add(model.Announcement model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Announcement>> Edit(model.Announcement model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SetOrders(List<model.Announcement> models, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Announcement>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Announcement>>> List(model.AnnouncementListVM announcement, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Announcement>>> ListForBulletin(model.AnnouncementListVM announcement, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.AnnouncementPositionType>>> ListPositionTypes(Guid announcementId, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyAnswerService: IService
		 {
						 				Task<AppCore.Result> Modify(model.InsertSurveyAnswer model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyAnswer>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyAnswer>>> List(model.ApplicationSurveyAnswerListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyParticipantService: IService
		 {
						 				Task<AppCore.Result<model.ApplicationSurveyParticipant>> Add(model.ApplicationSurveyParticipant model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyParticipant>> Edit(model.ApplicationSurveyParticipant model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyParticipant>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyParticipant>>> List(model.ApplicationSurveyParticipantListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyQuestionChoiceService: IService
		 {
						 				Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Add(model.ApplicationSurveyQuestionChoice model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Edit(model.ApplicationSurveyQuestionChoice model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestionChoice>>> List(model.ApplicationSurveyQuestionChoiceListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyQuestionService: IService
		 {
						 				Task<AppCore.Result<model.ApplicationSurveyQuestion>> Add(model.ApplicationSurveyQuestion model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyQuestion>> Edit(model.ApplicationSurveyQuestion model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyQuestion>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> List(model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ListQuestionAndChoice(model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ReportQuestion(model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyGroupService: IService
		 {
						 				Task<AppCore.Result<model.ApplicationSurveyGroup>> Add(model.ApplicationSurveyGroup model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyGroup>> Edit(model.ApplicationSurveyGroup model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurveyGroup>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> List(model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ListGroupAndQuestion(model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ReportGroup(model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IContactDetailService: IService
		 {
						 				Task<AppCore.Result<model.ContactDetail>> Add(model.ContactDetail model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ContactDetail>> Edit(model.ContactDetail model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IContactInfoService: IService
		 {
						 				Task<AppCore.Result<model.ContactInfo>> Add(model.ContactInfo model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ContactInfo>> Edit(model.ContactInfo model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ContactInfo>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ContactInfo>>> List(Guid parentId, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationSurveyService: IService
		 {
						 				Task<AppCore.Result<model.ApplicationSurvey>> Add(model.ApplicationSurvey model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurvey>> Edit(model.ApplicationSurvey model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ApplicationSurvey>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ApplicationSurvey>>> List(model.ApplicationSurveyListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface INotificationConditionService: IService
		 {
						 				Task<AppCore.Result<model.NotificationCondition>> Add(model.NotificationCondition model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.NotificationCondition>> Edit(model.NotificationCondition model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.NotificationCondition>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.NotificationCondition>>> List(model.NotificationConditionsListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface INotificationService: IService
		 {
						 				Task<AppCore.Result<model.Notification>> Add(model.Notification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Notification>> Edit(model.Notification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Archive(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Send(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Notification>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Notification>>> List(model.NotificationsListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Notification>>> ListByPosition(model.NotificationListByPositionVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.NotificationPosition>>> ListPositions(model.NotificationPositionsListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ITicketService: IService
		 {
						 				Task<AppCore.Result<model.Ticket>> Add(model.Ticket model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Ticket>> Edit(model.Ticket model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Ticket>> SetTicketOwner(model.Ticket model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Ticket>> Rating(model.Ticket model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Ticket>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Ticket>>> List(model.TicketListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Ticket>>> Report(model.TicketReportListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ITicketSequenceService: IService
		 {
						 				Task<AppCore.Result<model.TicketSequence>> Add(model.TicketSequence model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSequence>> Edit(model.TicketSequence model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSequence>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.TicketSequence>>> List(model.TicketSequenceListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSequence>> SetReadDate(model.TicketSequence model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ITicketSubjectService: IService
		 {
						 				Task<AppCore.Result<model.TicketSubject>> Add(model.TicketSubject model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSubject>> Edit(model.TicketSubject model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSubject>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.TicketSubject>>> List(model.TicketSubjectListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ITicketSubjectUserService: IService
		 {
						 				Task<AppCore.Result<model.TicketSubjectUser>> Add(model.TicketSubjectUser model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSubjectUser>> Edit(model.TicketSubjectUser model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.TicketSubjectUser>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.TicketSubjectUser>>> List(model.TicketSubjectUserListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IDynamicPermissionService: IService
		 {
						 				Task<AppCore.Result<model.DynamicPermission>> Add(model.DynamicPermission model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.DynamicPermission>> Edit(model.DynamicPermission model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.DynamicPermission model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.DynamicPermission>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.DynamicPermission>>> List(model.DynamicPermissionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Position>>> ListPositionsAsync(model.DynamicPermissionListPositionsVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Model>>> ListObjectsByPositionAsync(Guid positionId, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ILoginService: IService
		 {
						 				Task<AppCore.Result> Logout(Guid RefreshTokenID, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IWebServiceUserService: IService
		 {
						 				Task<AppCore.Result<model.WebServiceUser>> Add(model.WebServiceUser model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.WebServiceUser>> Edit(model.WebServiceUser model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.WebServiceUser>>> List(model.WebServiceUserListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.WebServiceUser>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.WebServiceUser>> Get(model.WebServiceUserGetVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IAttachmentService: IService
		 {
						 				Task<AppCore.Result<model.Attachment>> Add(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Attachment>> Edit(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Attachment>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Attachment>>> List(Guid compalintId, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ICommandService: IService
		 {
						 				Task<AppCore.Result<model.Command>> Add(model.Command model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Command>> Edit(model.Command model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Command>>> List(model.CommandListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Command>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IContactService: IService
		 {
						 				Task<AppCore.Result<model.Contact>> Add(model.Contact contact, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Contact>> SetArchive(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Contact>> SetUnArchive(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Contact>> SetNote(model.Contact contact, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Contact>>> List(model.ContactListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Contact>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IFAQService: IService
		 {
						 				Task<AppCore.Result<model.FAQ>> Add(model.FAQ model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.FAQ>> Edit(model.FAQ model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.FAQ>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.FAQ>>> List(model.FAQListVM faqListVm, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IFAQGroupService: IService
		 {
						 				Task<AppCore.Result<model.FAQGroup>> Add(model.FAQGroup model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.FAQGroup>> Edit(model.FAQGroup model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.FAQGroup>> Get(Guid Id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.FAQGroup>>> List(model.FAQGroupListVM faqGroupListVM, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListWithFAQs(model.FAQGroupListVM faqGroupListVM, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid Id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IMessageService: IService
		 {
						 				Task<AppCore.Result<model.Message>> Add(model.Message model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Message>> Edit(model.Message model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> PermanentDelete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Seen(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Send(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Message>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Message>>> ListInBox(model.InboxMessageListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Message>>> ListOutBox(model.OutboxMessageListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Message>>> ListDraft(model.DraftMessageListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IPositionTypeService: IService
		 {
						 				Task<AppCore.Result<model.PositionTypeModel>> Add(model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.PositionTypeModel>> Edit(model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SetRoles(model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.PositionTypeModel>>> List( IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.PositionTypeModel>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Role>>> GetRoles(model.PositionType positionType, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IApplicationService: IService
		 {
						 				Task<AppCore.Result<model.Application>> Add(model.Application model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Application>> Edit(model.Application model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Application>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Application>>> List(model.ApplicationListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IDepartmentService: IService
		 {
						 				Task<AppCore.Result<model.Department>> Add(model.Department model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Department>> Edit(model.Department model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Department>>> List(model.DepartmentListVM department, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Department>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IPlaceService: IService
		 {
						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

            			 				Task<AppCore.Result<model.Place>> Add(model.Place model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Place>> Edit(model.Place model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Place>>> List(model.PlaceListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Place>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IPositionService: IService
		 {
						 				Task<AppCore.Result<model.Position>> Add(model.Position model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Position>> Edit(model.Position model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SetDefault(Guid positionId, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> RemoveUser(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> List(model.PositionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> ListCurrentUserPositions( IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> ListInAllApplications(model.PositionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Position>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCount( IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<Byte[]>> ListExcel(model.PositionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<Byte[]>> ListExcelWithRole(model.PositionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<Object>>> GetPermissions(Guid positionId, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<Boolean>> CheckPermission(Guid commandId, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IRoleService: IService
		 {
						 				Task<AppCore.Result<model.Role>> Add(model.Role model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Role>> Edit(model.Role model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Role model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Role>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Role>>> List(model.RoleListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IUserService: IService
		 {
						 				Task<AppCore.Result<model.User>> Add(model.User model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> Edit(model.User model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> EditProfile(model.UserProfileVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> VerifyCellPhone(model.VerifyCellPhoneVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> VerifyEmail(model.VerifyEmailVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SendSecurityCodeBySms(model.User model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SendSecurityCodeByEmail(model.User model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> ResetPassword(model.User model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SetPassword(model.SetPasswordVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SetPasswordWithSecuriyStamp(model.SetPasswordWithSecuriyStampVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> SaveSetting(model.UserSetting model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.User>>> List(model.UserListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> Get(Guid id, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> Get(String username, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> GetByNationalCode(String nationalCode, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.User>> GetByEmail(String email, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.UserSetting>> GetSetting( IDictionary<string, string> httpHeaders = null);

					 }

  }