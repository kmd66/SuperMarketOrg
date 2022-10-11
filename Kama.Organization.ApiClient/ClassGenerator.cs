using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Organization.ApiClient.Interface;
using model = Kama.Organization.Core.Model;

namespace Kama.Organization.ApiClient
{
	abstract class Service
    {
    }

		 partial class AnnouncementService: Service, IAnnouncementService
		 {
			public AnnouncementService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Announcement>> Add( model.Announcement model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Announcement/Add";
							return _client.SendAsync<model.Announcement>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Announcement>> Edit( model.Announcement model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Announcement/Edit";
							return _client.SendAsync<model.Announcement>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Announcement/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> SetOrders( List<model.Announcement> models, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"models", models == null ? null : models.ToString()}};
			const string url = "api/v1/Announcement/SetOrders";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, models);
						}

                        public virtual Task<AppCore.Result<model.Announcement>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/Announcement/Get/{Id:guid}";
							return _client.SendAsync<model.Announcement>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Announcement>>> List( model.AnnouncementListVM announcement, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"announcement", announcement == null ? null : announcement.ToString()}};
			const string url = "api/v1/Announcement/List";
							return _client.SendAsync<IEnumerable<model.Announcement>>(true, url, routeParamValues, httpHeaders, announcement);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Announcement>>> ListForBulletin( model.AnnouncementListVM announcement, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"announcement", announcement == null ? null : announcement.ToString()}};
			const string url = "api/v1/Announcement/ListForBulletin";
							return _client.SendAsync<IEnumerable<model.Announcement>>(true, url, routeParamValues, httpHeaders, announcement);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.AnnouncementPositionType>>> ListPositionTypes( Guid announcementId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"announcementId", announcementId == null ? null : announcementId.ToString()}};
			const string url = "api/v1/Announcement/ListUserTypes/{announcementId:guid}";
							return _client.SendAsync<IEnumerable<model.AnnouncementPositionType>>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ApplicationSurveyAnswerService: Service, IApplicationSurveyAnswerService
		 {
			public ApplicationSurveyAnswerService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result> Modify( model.InsertSurveyAnswer model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-answer/Modify";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyAnswer>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-answer/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurveyAnswer>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyAnswer>>> List( model.ApplicationSurveyAnswerListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-answer/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyAnswer>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class ApplicationSurveyParticipantService: Service, IApplicationSurveyParticipantService
		 {
			public ApplicationSurveyParticipantService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ApplicationSurveyParticipant>> Add( model.ApplicationSurveyParticipant model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-participant/Add";
							return _client.SendAsync<model.ApplicationSurveyParticipant>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyParticipant>> Edit( model.ApplicationSurveyParticipant model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-participant/Edit";
							return _client.SendAsync<model.ApplicationSurveyParticipant>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyParticipant>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-participant/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurveyParticipant>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyParticipant>>> List( model.ApplicationSurveyParticipantListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-participant/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyParticipant>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class ApplicationSurveyQuestionChoiceService: Service, IApplicationSurveyQuestionChoiceService
		 {
			public ApplicationSurveyQuestionChoiceService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Add( model.ApplicationSurveyQuestionChoice model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question-choice/Add";
							return _client.SendAsync<model.ApplicationSurveyQuestionChoice>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Edit( model.ApplicationSurveyQuestionChoice model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question-choice/Edit";
							return _client.SendAsync<model.ApplicationSurveyQuestionChoice>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyQuestionChoice>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-question-choice/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurveyQuestionChoice>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestionChoice>>> List( model.ApplicationSurveyQuestionChoiceListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question-choice/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyQuestionChoice>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-question-choice/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ApplicationSurveyQuestionService: Service, IApplicationSurveyQuestionService
		 {
			public ApplicationSurveyQuestionService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ApplicationSurveyQuestion>> Add( model.ApplicationSurveyQuestion model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question/Add";
							return _client.SendAsync<model.ApplicationSurveyQuestion>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyQuestion>> Edit( model.ApplicationSurveyQuestion model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question/Edit";
							return _client.SendAsync<model.ApplicationSurveyQuestion>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyQuestion>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-question/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurveyQuestion>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> List( model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyQuestion>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ListQuestionAndChoice( model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question/ListQuestionAndChoice";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyQuestion>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyQuestion>>> ReportQuestion( model.ApplicationSurveyQuestionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-question/ReportQuestion";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyQuestion>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-question/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ApplicationSurveyGroupService: Service, IApplicationSurveyGroupService
		 {
			public ApplicationSurveyGroupService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ApplicationSurveyGroup>> Add( model.ApplicationSurveyGroup model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-group/Add";
							return _client.SendAsync<model.ApplicationSurveyGroup>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyGroup>> Edit( model.ApplicationSurveyGroup model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-group/Edit";
							return _client.SendAsync<model.ApplicationSurveyGroup>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurveyGroup>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-group/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurveyGroup>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> List( model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-group/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyGroup>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ListGroupAndQuestion( model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-group/ListGroupAndQuestion";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyGroup>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurveyGroup>>> ReportGroup( model.ApplicationSurveyGroupListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey-group/ReportGroup";
							return _client.SendAsync<IEnumerable<model.ApplicationSurveyGroup>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey-group/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ContactDetailService: Service, IContactDetailService
		 {
			public ContactDetailService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ContactDetail>> Add( model.ContactDetail model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ContactDetail/Add";
							return _client.SendAsync<model.ContactDetail>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ContactDetail>> Edit( model.ContactDetail model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ContactDetail/Edit";
							return _client.SendAsync<model.ContactDetail>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/ContactDetail/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ContactInfoService: Service, IContactInfoService
		 {
			public ContactInfoService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ContactInfo>> Add( model.ContactInfo model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ContactInfo/Add";
							return _client.SendAsync<model.ContactInfo>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ContactInfo>> Edit( model.ContactInfo model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ContactInfo/Edit";
							return _client.SendAsync<model.ContactInfo>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/ContactInfo/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.ContactInfo>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/ContactInfo/Get/{id:guid}";
							return _client.SendAsync<model.ContactInfo>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ContactInfo>>> List( Guid parentId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"parentId", parentId == null ? null : parentId.ToString()}};
			const string url = "api/v1/ContactInfo/List/{parentId:guid}";
							return _client.SendAsync<IEnumerable<model.ContactInfo>>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ApplicationSurveyService: Service, IApplicationSurveyService
		 {
			public ApplicationSurveyService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.ApplicationSurvey>> Add( model.ApplicationSurvey model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey/Add";
							return _client.SendAsync<model.ApplicationSurvey>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurvey>> Edit( model.ApplicationSurvey model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey/Edit";
							return _client.SendAsync<model.ApplicationSurvey>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.ApplicationSurvey>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey/Get/{Id:guid}";
							return _client.SendAsync<model.ApplicationSurvey>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.ApplicationSurvey>>> List( model.ApplicationSurveyListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/application-survey/List";
							return _client.SendAsync<IEnumerable<model.ApplicationSurvey>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/application-survey/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class NotificationConditionService: Service, INotificationConditionService
		 {
			public NotificationConditionService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.NotificationCondition>> Add( model.NotificationCondition model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/NotificationCondition/Add";
							return _client.SendAsync<model.NotificationCondition>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.NotificationCondition>> Edit( model.NotificationCondition model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/NotificationCondition/Edit";
							return _client.SendAsync<model.NotificationCondition>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/NotificationCondition/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.NotificationCondition>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/NotificationCondition/Get/{id:guid}";
							return _client.SendAsync<model.NotificationCondition>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.NotificationCondition>>> List( model.NotificationConditionsListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/NotificationCondition/List";
							return _client.SendAsync<IEnumerable<model.NotificationCondition>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class NotificationService: Service, INotificationService
		 {
			public NotificationService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Notification>> Add( model.Notification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Notification/Add";
							return _client.SendAsync<model.Notification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Notification>> Edit( model.Notification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Notification/Edit";
							return _client.SendAsync<model.Notification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Notification/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> Archive( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Notification/Archive/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> Send( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Notification/Send/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.Notification>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Notification/Get/{id:guid}";
							return _client.SendAsync<model.Notification>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Notification>>> List( model.NotificationsListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Notification/List";
							return _client.SendAsync<IEnumerable<model.Notification>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Notification>>> ListByPosition( model.NotificationListByPositionVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Notification/ListByPosition";
							return _client.SendAsync<IEnumerable<model.Notification>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.NotificationPosition>>> ListPositions( model.NotificationPositionsListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Notification/ListPositions";
							return _client.SendAsync<IEnumerable<model.NotificationPosition>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class TicketService: Service, ITicketService
		 {
			public TicketService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Ticket>> Add( model.Ticket model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/Add";
							return _client.SendAsync<model.Ticket>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Ticket>> Edit( model.Ticket model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/Edit";
							return _client.SendAsync<model.Ticket>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Ticket>> SetTicketOwner( model.Ticket model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/SetTicketOwner";
							return _client.SendAsync<model.Ticket>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Ticket>> Rating( model.Ticket model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/Rating";
							return _client.SendAsync<model.Ticket>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Ticket/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.Ticket>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Ticket/Get/{id:guid}";
							return _client.SendAsync<model.Ticket>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Ticket>>> List( model.TicketListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/List";
							return _client.SendAsync<IEnumerable<model.Ticket>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Ticket>>> Report( model.TicketReportListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Ticket/Report";
							return _client.SendAsync<IEnumerable<model.Ticket>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class TicketSequenceService: Service, ITicketSequenceService
		 {
			public TicketSequenceService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.TicketSequence>> Add( model.TicketSequence model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSequence/Add";
							return _client.SendAsync<model.TicketSequence>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.TicketSequence>> Edit( model.TicketSequence model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSequence/Edit";
							return _client.SendAsync<model.TicketSequence>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSequence/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.TicketSequence>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSequence/Get/{id:guid}";
							return _client.SendAsync<model.TicketSequence>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.TicketSequence>>> List( model.TicketSequenceListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSequence/List";
							return _client.SendAsync<IEnumerable<model.TicketSequence>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.TicketSequence>> SetReadDate( model.TicketSequence model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSequence/SetReadDate";
							return _client.SendAsync<model.TicketSequence>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class TicketSubjectService: Service, ITicketSubjectService
		 {
			public TicketSubjectService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.TicketSubject>> Add( model.TicketSubject model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubject/Add";
							return _client.SendAsync<model.TicketSubject>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.TicketSubject>> Edit( model.TicketSubject model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubject/Edit";
							return _client.SendAsync<model.TicketSubject>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSubject/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.TicketSubject>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSubject/Get/{id:guid}";
							return _client.SendAsync<model.TicketSubject>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.TicketSubject>>> List( model.TicketSubjectListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubject/List";
							return _client.SendAsync<IEnumerable<model.TicketSubject>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class TicketSubjectUserService: Service, ITicketSubjectUserService
		 {
			public TicketSubjectUserService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.TicketSubjectUser>> Add( model.TicketSubjectUser model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubjectUser/Add";
							return _client.SendAsync<model.TicketSubjectUser>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.TicketSubjectUser>> Edit( model.TicketSubjectUser model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubjectUser/Edit";
							return _client.SendAsync<model.TicketSubjectUser>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSubjectUser/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.TicketSubjectUser>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/TicketSubjectUser/Get/{id:guid}";
							return _client.SendAsync<model.TicketSubjectUser>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.TicketSubjectUser>>> List( model.TicketSubjectUserListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/TicketSubjectUser/List";
							return _client.SendAsync<IEnumerable<model.TicketSubjectUser>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class DynamicPermissionService: Service, IDynamicPermissionService
		 {
			public DynamicPermissionService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.DynamicPermission>> Add( model.DynamicPermission model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/DynamicPermission/Add";
							return _client.SendAsync<model.DynamicPermission>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.DynamicPermission>> Edit( model.DynamicPermission model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/DynamicPermission/Edit";
							return _client.SendAsync<model.DynamicPermission>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( model.DynamicPermission model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/DynamicPermission/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.DynamicPermission>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/DynamicPermission/Get/{id:guid}";
							return _client.SendAsync<model.DynamicPermission>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.DynamicPermission>>> List( model.DynamicPermissionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/DynamicPermission/List";
							return _client.SendAsync<IEnumerable<model.DynamicPermission>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Position>>> ListPositionsAsync( model.DynamicPermissionListPositionsVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/DynamicPermission/ListPositions";
							return _client.SendAsync<IEnumerable<model.Position>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Model>>> ListObjectsByPositionAsync( Guid positionId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"positionId", positionId == null ? null : positionId.ToString()}};
			const string url = "api/v1/DynamicPermission/ListObjectsByPosition";
							return _client.SendAsync<IEnumerable<model.Model>>(true, url, routeParamValues, httpHeaders, positionId);
						}

            		 }
  
		 partial class LoginService: Service, ILoginService
		 {
			public LoginService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result> Logout( Guid RefreshTokenID, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"RefreshTokenID", RefreshTokenID == null ? null : RefreshTokenID.ToString()}};
			const string url = "api/v1/Login/logout/{RefreshTokenID:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class WebServiceUserService: Service, IWebServiceUserService
		 {
			public WebServiceUserService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.WebServiceUser>> Add( model.WebServiceUser model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/WebServiceUser/Add";
							return _client.SendAsync<model.WebServiceUser>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.WebServiceUser>> Edit( model.WebServiceUser model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/WebServiceUser/edit";
							return _client.SendAsync<model.WebServiceUser>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/WebServiceUser/delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.WebServiceUser>>> List( model.WebServiceUserListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/WebServiceUser/List";
							return _client.SendAsync<IEnumerable<model.WebServiceUser>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.WebServiceUser>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/WebServiceUser/Get/{id:guid}";
							return _client.SendAsync<model.WebServiceUser>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.WebServiceUser>> Get( model.WebServiceUserGetVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/WebServiceUser/Get";
							return _client.SendAsync<model.WebServiceUser>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class AttachmentService: Service, IAttachmentService
		 {
			public AttachmentService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Attachment>> Add( model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Add";
							return _client.SendAsync<model.Attachment>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Attachment>> Edit( model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Edit";
							return _client.SendAsync<model.Attachment>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Attachment>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Attachment/Get/{id:guid}";
							return _client.SendAsync<model.Attachment>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Attachment>>> List( Guid compalintId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"compalintId", compalintId == null ? null : compalintId.ToString()}};
			const string url = "api/v1/Attachment/List/{compalintId:guid}";
							return _client.SendAsync<IEnumerable<model.Attachment>>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class CommandService: Service, ICommandService
		 {
			public CommandService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Command>> Add( model.Command model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Command/Add";
							return _client.SendAsync<model.Command>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Command>> Edit( model.Command model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Command/Edit";
							return _client.SendAsync<model.Command>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Command/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Command>>> List( model.CommandListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Command/List";
							return _client.SendAsync<IEnumerable<model.Command>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Command>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Command/Get/{id:guid}";
							return _client.SendAsync<model.Command>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class ContactService: Service, IContactService
		 {
			public ContactService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Contact>> Add( model.Contact contact, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"contact", contact == null ? null : contact.ToString()}};
			const string url = "api/v1/Contact/Add";
							return _client.SendAsync<model.Contact>(true, url, routeParamValues, httpHeaders, contact);
						}

                        public virtual Task<AppCore.Result<model.Contact>> SetArchive( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Contact/SetArchive";
							return _client.SendAsync<model.Contact>(true, url, routeParamValues, httpHeaders, id);
						}

                        public virtual Task<AppCore.Result<model.Contact>> SetUnArchive( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Contact/SetUnArchive";
							return _client.SendAsync<model.Contact>(true, url, routeParamValues, httpHeaders, id);
						}

                        public virtual Task<AppCore.Result<model.Contact>> SetNote( model.Contact contact, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"contact", contact == null ? null : contact.ToString()}};
			const string url = "api/v1/Contact/SetNote";
							return _client.SendAsync<model.Contact>(true, url, routeParamValues, httpHeaders, contact);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Contact>>> List( model.ContactListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Contact/List";
							return _client.SendAsync<IEnumerable<model.Contact>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Contact>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/Contact/Get/{Id:guid}";
							return _client.SendAsync<model.Contact>(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class FAQService: Service, IFAQService
		 {
			public FAQService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.FAQ>> Add( model.FAQ model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/FAQ/Add";
							return _client.SendAsync<model.FAQ>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.FAQ>> Edit( model.FAQ model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/FAQ/Edit";
							return _client.SendAsync<model.FAQ>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.FAQ>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/FAQ/Get/{Id:guid}";
							return _client.SendAsync<model.FAQ>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.FAQ>>> List( model.FAQListVM faqListVm, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"faqListVm", faqListVm == null ? null : faqListVm.ToString()}};
			const string url = "api/v1/FAQ/List";
							return _client.SendAsync<IEnumerable<model.FAQ>>(true, url, routeParamValues, httpHeaders, faqListVm);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/FAQ/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class FAQGroupService: Service, IFAQGroupService
		 {
			public FAQGroupService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.FAQGroup>> Add( model.FAQGroup model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/FAQGroup/Add";
							return _client.SendAsync<model.FAQGroup>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.FAQGroup>> Edit( model.FAQGroup model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/FAQGroup/Edit";
							return _client.SendAsync<model.FAQGroup>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.FAQGroup>> Get( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/FAQGroup/Get/{Id:guid}";
							return _client.SendAsync<model.FAQGroup>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.FAQGroup>>> List( model.FAQGroupListVM faqGroupListVM, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"faqGroupListVM", faqGroupListVM == null ? null : faqGroupListVM.ToString()}};
			const string url = "api/v1/FAQGroup/List";
							return _client.SendAsync<IEnumerable<model.FAQGroup>>(true, url, routeParamValues, httpHeaders, faqGroupListVM);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.FAQGroup>>> ListWithFAQs( model.FAQGroupListVM faqGroupListVM, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"faqGroupListVM", faqGroupListVM == null ? null : faqGroupListVM.ToString()}};
			const string url = "api/v1/FAQGroup/ListWithFAQs";
							return _client.SendAsync<IEnumerable<model.FAQGroup>>(true, url, routeParamValues, httpHeaders, faqGroupListVM);
						}

                        public virtual Task<AppCore.Result> Delete( Guid Id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"Id", Id == null ? null : Id.ToString()}};
			const string url = "api/v1/FAQGroup/Delete/{Id:guid}";
							return _client.SendAsync(false, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class MessageService: Service, IMessageService
		 {
			public MessageService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Message>> Add( model.Message model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Message/Add";
							return _client.SendAsync<model.Message>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Message>> Edit( model.Message model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Message/Edit";
							return _client.SendAsync<model.Message>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Message/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> PermanentDelete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Message/PermanentDelete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> Seen( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Message/Seen/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> Send( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Message/Send/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.Message>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Message/Get/{id:guid}";
							return _client.SendAsync<model.Message>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Message>>> ListInBox( model.InboxMessageListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Message/ListInBox";
							return _client.SendAsync<IEnumerable<model.Message>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Message>>> ListOutBox( model.OutboxMessageListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Message/ListOutBox";
							return _client.SendAsync<IEnumerable<model.Message>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Message>>> ListDraft( model.DraftMessageListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Message/ListDraft";
							return _client.SendAsync<IEnumerable<model.Message>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class PositionTypeService: Service, IPositionTypeService
		 {
			public PositionTypeService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.PositionTypeModel>> Add( model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/PositionType/Add";
							return _client.SendAsync<model.PositionTypeModel>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.PositionTypeModel>> Edit( model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/PositionType/Edit";
							return _client.SendAsync<model.PositionTypeModel>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SetRoles( model.PositionTypeModel model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/PositionType/SetRoles";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.PositionTypeModel>>> List( IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{};
			const string url = "api/v1/PositionType/List";
							return _client.SendAsync<IEnumerable<model.PositionTypeModel>>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.PositionTypeModel>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/PositionType/Get";
							return _client.SendAsync<model.PositionTypeModel>(true, url, routeParamValues, httpHeaders, id);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Role>>> GetRoles( model.PositionType positionType, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"positionType", positionType == null ? null : positionType.ToString()}};
			const string url = "api/v1/PositionType/GetRoles/{positionType}";
							return _client.SendAsync<IEnumerable<model.Role>>(true, url, routeParamValues, httpHeaders, positionType);
						}

            		 }
  
		 partial class ApplicationService: Service, IApplicationService
		 {
			public ApplicationService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Application>> Add( model.Application model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Application/Add";
							return _client.SendAsync<model.Application>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Application>> Edit( model.Application model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Application/Edit";
							return _client.SendAsync<model.Application>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Application>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Application/Get/{id:guid}";
							return _client.SendAsync<model.Application>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Application/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Application>>> List( model.ApplicationListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Application/List";
							return _client.SendAsync<IEnumerable<model.Application>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class DepartmentService: Service, IDepartmentService
		 {
			public DepartmentService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Department>> Add( model.Department model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Department/Add";
							return _client.SendAsync<model.Department>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Department>> Edit( model.Department model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Department/Edit";
							return _client.SendAsync<model.Department>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Department/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Department>>> List( model.DepartmentListVM department, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"department", department == null ? null : department.ToString()}};
			const string url = "api/v1/Department/list";
							return _client.SendAsync<IEnumerable<model.Department>>(true, url, routeParamValues, httpHeaders, department);
						}

                        public virtual Task<AppCore.Result<model.Department>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Department/Get/{id:guid}";
							return _client.SendAsync<model.Department>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class PlaceService: Service, IPlaceService
		 {
			public PlaceService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/place/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.Place>> Add( model.Place model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/place/Add";
							return _client.SendAsync<model.Place>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Place>> Edit( model.Place model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/place/Edit";
							return _client.SendAsync<model.Place>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Place>>> List( model.PlaceListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/place/list";
							return _client.SendAsync<IEnumerable<model.Place>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Place>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/place/get/{id:guid}";
							return _client.SendAsync<model.Place>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class PositionService: Service, IPositionService
		 {
			public PositionService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Position>> Add( model.Position model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/Add";
							return _client.SendAsync<model.Position>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Position>> Edit( model.Position model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/Edit";
							return _client.SendAsync<model.Position>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Position/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> SetDefault( Guid positionId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"positionId", positionId == null ? null : positionId.ToString()}};
			const string url = "api/v1/Position/SetDefault/{positionId:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result> RemoveUser( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Position/RemoveUser/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> List( model.PositionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/List";
							return _client.SendAsync<IEnumerable<model.Position<model.PositionType>>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> ListCurrentUserPositions( IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{};
			const string url = "api/v1/Position/ListCurrentUserPositions";
							return _client.SendAsync<IEnumerable<model.Position<model.PositionType>>>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Position<model.PositionType>>>> ListInAllApplications( model.PositionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/ListInAllApplications";
							return _client.SendAsync<IEnumerable<model.Position<model.PositionType>>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Position>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Position/get/{id:guid}";
							return _client.SendAsync<model.Position>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.GetOnlineUsersAndPositionsCountVM>> GetOnlineCount( IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{};
			const string url = "api/v1/Position/GetOnlineCount";
							return _client.SendAsync<model.GetOnlineUsersAndPositionsCountVM>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<Byte[]>> ListExcel( model.PositionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/ListExcel";
							return _client.SendAsync<Byte[]>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Byte[]>> ListExcelWithRole( model.PositionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Position/ListExcelWithRole";
							return _client.SendAsync<Byte[]>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Object>>> GetPermissions( Guid positionId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"positionId", positionId == null ? null : positionId.ToString()}};
			const string url = "api/v1/Position/GetPermissions/{positionId:guid}";
							return _client.SendAsync<IEnumerable<Object>>(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<Boolean>> CheckPermission( Guid commandId, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"commandId", commandId == null ? null : commandId.ToString()}};
			const string url = "api/v1/Position/CheckPermission/commandId";
							return _client.SendAsync<Boolean>(true, url, routeParamValues, httpHeaders, commandId);
						}

            		 }
  
		 partial class RoleService: Service, IRoleService
		 {
			public RoleService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.Role>> Add( model.Role model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Role/Add";
							return _client.SendAsync<model.Role>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Role>> Edit( model.Role model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Role/Edit";
							return _client.SendAsync<model.Role>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( model.Role model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Role/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.Role>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/Role/Get/{id:guid}";
							return _client.SendAsync<model.Role>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.Role>>> List( model.RoleListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Role/List";
							return _client.SendAsync<IEnumerable<model.Role>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class UserService: Service, IUserService
		 {
			public UserService(IOrganizationClient client)
			{
				_client = client;
			}
			readonly IOrganizationClient _client;

			            public virtual Task<AppCore.Result<model.User>> Add( model.User model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/Add";
							return _client.SendAsync<model.User>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.User>> Edit( model.User model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/edit";
							return _client.SendAsync<model.User>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/User/delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.User>> EditProfile( model.UserProfileVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/EditProfile";
							return _client.SendAsync<model.User>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> VerifyCellPhone( model.VerifyCellPhoneVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/VerifyCellPhone";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> VerifyEmail( model.VerifyEmailVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/VerifyEmail";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SendSecurityCodeBySms( model.User model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/SendSecurityCodeBySms";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SendSecurityCodeByEmail( model.User model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/SendSecurityCodeByEmail";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> ResetPassword( model.User model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/ResetPassword";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SetPassword( model.SetPasswordVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/SetPassword";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SetPasswordWithSecuriyStamp( model.SetPasswordWithSecuriyStampVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/SetPasswordWithSecuriyStamp";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SaveSetting( model.UserSetting model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/SaveSetting";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<model.User>>> List( model.UserListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/User/List";
							return _client.SendAsync<IEnumerable<model.User>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<model.User>> Get( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/User/Get/{id:guid}";
							return _client.SendAsync<model.User>(false, url, routeParamValues, httpHeaders);
						}

                        public virtual Task<AppCore.Result<model.User>> Get( String username, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"username", username == null ? null : username.ToString()}};
			const string url = "api/v1/User/Get/{username}";
							return _client.SendAsync<model.User>(false, url, routeParamValues, httpHeaders, username);
						}

                        public virtual Task<AppCore.Result<model.User>> GetByNationalCode( String nationalCode, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"nationalCode", nationalCode == null ? null : nationalCode.ToString()}};
			const string url = "api/v1/User/GetByNationalCode/{nationalCode}";
							return _client.SendAsync<model.User>(true, url, routeParamValues, httpHeaders, nationalCode);
						}

                        public virtual Task<AppCore.Result<model.User>> GetByEmail( String email, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"email", email == null ? null : email.ToString()}};
			const string url = "api/v1/User/GetByEmail/{email}";
							return _client.SendAsync<model.User>(true, url, routeParamValues, httpHeaders, email);
						}

                        public virtual Task<AppCore.Result<model.UserSetting>> GetSetting( IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{};
			const string url = "api/v1/User/GetSetting";
							return _client.SendAsync<model.UserSetting>(true, url, routeParamValues, httpHeaders);
						}

            		 }
  }