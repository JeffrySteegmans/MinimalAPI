namespace MinimalAPI.Swagger.SessionService.Requests;

public record GetSessionsForCustomerByTypeRequest(Guid customerId, string sessionType);
